using System;
using System.Globalization;
using System.Web;
using System.Web.UI.HtmlControls;
using SOS.BusinessEntities;
using SOS.DataProcessingLayer;

namespace SOS.Pages
{
    public partial class PFSConsult : System.Web.UI.Page
    {
        private readonly DataProcessing _proc = new DataProcessing();
        private SaveExport _save;

        protected void Page_Load(object sender, EventArgs e)
        {
            _save = new SaveExport(Server.MapPath("~"));
            if (!Page.IsPostBack)
            {
                selParent.DataSource = _proc.GetPfsList();
                selParent.DataTextField = "FIO";
                selParent.DataValueField = "Id";
                selParent.DataBind();
                SelContent.DataSource = _proc.GetContentTypes("PFS");
                SelContent.DataTextField = "TypeName";
                SelContent.DataValueField = "Id";
                SelContent.DataBind();
                SelForm.DataSource = _proc.GetFormTypes("PFS");
                SelForm.DataTextField = "TypeName";
                SelForm.DataValueField = "Id";
                SelForm.DataBind();

            }
            if (Request.QueryString.HasKeys())
            {
                consultId.InnerText = Request.QueryString["consultid"];
                var consult = _proc.GetPfsConsult(Convert.ToInt32(consultId.InnerText));
                selParent.Value = consult.ClientId.ToString(CultureInfo.InvariantCulture);
                SelContent.Value = consult.ContentType.ToString(CultureInfo.InvariantCulture);
                SelForm.Value = consult.FormType.ToString(CultureInfo.InvariantCulture);
                txtProblem.Text = consult.ProblemDiscription;
                txtConversation.Text = consult.ConversDiscription;
                txtResults.Text = consult.ConversResults;
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
                    consultId.InnerText = _proc.SavePfsConsult(new PfsConsult
                    {
                        ClientId = Convert.ToInt32(selParent.Value),
                        Date = Convert.ToDateTime(calendar.GetDate()),
                        ContentType = Convert.ToInt32(SelContent.Value),
                        FormType = Convert.ToInt32(SelForm.Value),
                        ProblemDiscription = txtProblem.Text,
                        ConversDiscription = txtConversation.Text,
                        ConversResults = txtResults.Text,
                        LocalSpecialistId =
                            Convert.ToInt32(((HtmlGenericControl) Master.FindControl("lblId")).InnerText),
                        NextSessionDate = Convert.ToDateTime(calendar.GetDate()),
                        StcConsultation = chbConsulting.Checked,
                        StcGivingInformation = chbInform.Checked,
                        StcPsychodiagnost = chbPsyhoDiagn.Checked,
                        StcTerrapevtSession = chbTerapetSession.Checked,
                        StcAnother = txtAnotherType.Text,
                        StpScheduled = rbIsPlanned.Checked,
                        StpAnother = txtAnotherPlanned.Text
                    }).ToString(CultureInfo.InvariantCulture);
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                btnExport.Visible = true;
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
                    _proc.UpdatePfsConsult(new PfsConsult
                    {
                        Id = Convert.ToInt32(consultId.InnerText),
                        ClientId = Convert.ToInt32(selParent.Value),
                        Date = Convert.ToDateTime(calendar.GetDate()),
                        ContentType = Convert.ToInt32(SelContent.Value),
                        FormType = Convert.ToInt32(SelForm.Value),
                        ProblemDiscription = txtProblem.Text,
                        ConversDiscription = txtConversation.Text,
                        ConversResults = txtResults.Text,
                        LocalSpecialistId =
                            Convert.ToInt32(((HtmlGenericControl) Master.FindControl("lblId")).InnerText),
                        NextSessionDate = Convert.ToDateTime(calendar.GetDate()),
                        StcConsultation = chbConsulting.Checked,
                        StcGivingInformation = chbInform.Checked,
                        StcPsychodiagnost = chbPsyhoDiagn.Checked,
                        StcTerrapevtSession = chbTerapetSession.Checked,
                        StcAnother = txtAnotherType.Text,
                        StpScheduled = rbIsPlanned.Checked,
                        StpAnother = txtAnotherPlanned.Text
                    });
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
            _save.PrintPfsConsult(Convert.ToInt32(consultId.InnerText), _proc.GetPfsConsult(Convert.ToInt32(consultId.InnerText)));
        }
    }
}