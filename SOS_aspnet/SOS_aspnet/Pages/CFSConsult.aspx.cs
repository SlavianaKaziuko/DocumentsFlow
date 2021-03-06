﻿using System;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.UI.HtmlControls;
using SOS.BusinessEntities;
using SOS.DataProcessingLayer;

namespace SOS.Pages
{
    public partial class CFSConsult : System.Web.UI.Page
    {
        private readonly DataProcessing _proc = new DataProcessing();
        private SaveExport _save;


        protected void Page_Load(object sender, EventArgs e)
        {
            _save = new SaveExport(Server.MapPath("~"));

            if (Page.IsPostBack) return;
            selChild.DataSource = _proc.GetCfsList();
            selChild.DataTextField = "FIO";
            selChild.DataValueField = "Id";
            selChild.DataBind();
            SelContent.DataSource = _proc.GetContentTypes("CFS");
            SelContent.DataTextField = "TypeName";
            SelContent.DataValueField = "Id";
            SelContent.DataBind();
            SelForm.DataSource = _proc.GetFormTypes("CFS");
            SelForm.DataTextField = "TypeName";
            SelForm.DataValueField = "Id";
            SelForm.DataBind();
            if (Request.QueryString.HasKeys())
            {
                consultId.InnerText = Request.QueryString["consultid"];
                var consult = _proc.GetCfsConsult(Convert.ToInt32(consultId.InnerText));
                selChild.Value = consult.ClientId.ToString(CultureInfo.InvariantCulture);
                txtDate.Value = consult.Date.ToString("d", CultureInfo.InvariantCulture);
                SelContent.Value = consult.ContentType.ToString(CultureInfo.InvariantCulture);
                SelForm.Value = consult.FormType.ToString(CultureInfo.InvariantCulture);
                txtProblem.Text = consult.ProblemDiscription;
                txtConversation.Text = consult.ConversDiscription;
                txtResults.Text = consult.ConversResults;
                txtNextDate.Value = consult.NextSessionDate.ToString("d", CultureInfo.InvariantCulture);
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                btnExport.Visible = true;

            }
            else
            {
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnExport.Visible = false;
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            if (consultId.InnerText != "")
            {
                errormessage.InnerText = "Произошла ошабка!";
                errormessage.Visible = true;
            }
            else
            {
                if (Master != null)
                {
                    consultId.InnerText = _proc.SaveCfsConsult(new CfsConsult
                    {
                        ClientId = Convert.ToInt32(selChild.Value),
                        Date = Convert.ToDateTime(txtDate.Value, CultureInfo.InvariantCulture),
                        ContentType = Convert.ToInt32(SelContent.Value),
                        FormType = Convert.ToInt32(SelForm.Value),
                        ProblemDiscription = txtProblem.Text,
                        ConversDiscription = txtConversation.Text,
                        ConversResults = txtResults.Text,
                        LocalSpecialistId =
                            Convert.ToInt32(((HtmlGenericControl) Master.FindControl("lblId")).InnerText),
                        NextSessionDate =
                            Convert.ToDateTime(txtNextDate.Value, CultureInfo.InvariantCulture)
                    }).ToString(CultureInfo.InvariantCulture);
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnExport.Visible = true;
                    message.InnerText = "Запись сохранена!";
                }
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            if (consultId.InnerText == "")
            {
                errormessage.InnerText = "Произошла ошабка!";
                errormessage.Visible = true;
            }
            else
            {
                if (Master != null)
                {
                    _proc.UpdateCfsConsult(new CfsConsult
                    {
                        Id = Convert.ToInt32(consultId.InnerText),
                        ClientId = Convert.ToInt32(selChild.Value),
                        Date = Convert.ToDateTime(txtDate.Value, CultureInfo.InvariantCulture),
                        ContentType = Convert.ToInt32(SelContent.Value),
                        FormType = Convert.ToInt32(SelForm.Value),
                        ProblemDiscription = txtProblem.Text,
                        ConversDiscription = txtConversation.Text,
                        ConversResults = txtResults.Text,
                        LocalSpecialistId =
                            Convert.ToInt32(((HtmlGenericControl) Master.FindControl("lblId")).InnerText),
                        NextSessionDate =
                            Convert.ToDateTime(txtNextDate.Value, CultureInfo.InvariantCulture)
                    });
                
                message.InnerText = "Запись обновлена!";
            }
        }
        }


        protected override void OnError(EventArgs e)
        {
            // At this point we have information about the error
            var ctx = HttpContext.Current;

            ctx.Response.Redirect("error.aspx");

            // --------------------------------------------------
            // To let the page finish running we clear the error
            // --------------------------------------------------
            ctx.Server.ClearError();

            base.OnError(e);
        }


        protected void btnExport_OnClick(object sender, EventArgs e)
        {
            try
            {
                var book = _save.PrintCfsConsult(Convert.ToInt32(consultId.InnerText), _proc.GetCfsConsult(Convert.ToInt32(consultId.InnerText)));
                Response.Clear();
                Response.ClearHeaders();
                book.Save(Response, Path.ChangeExtension(@"Консультация_" + consultId.InnerText, ".xlsx"));
                Response.End();
            }
            catch (Exception error)
            {
                lblerror.InnerText = error.Message;
            }

        }
    }
}