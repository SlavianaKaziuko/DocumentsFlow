using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GemBox.Spreadsheet;
using SOS.DataProcessingLayer;

namespace SOS.Pages
{
    public partial class JournalsPage : Page
    {
        readonly DataProcessing _proc = new DataProcessing();
        private SaveExport _save;

        protected void Page_Load(object sender, EventArgs e)
        {
            _save = new SaveExport(Server.MapPath("~"));
            if (!Page.IsPostBack)
            {
                periods_dropdown.DataSource = _proc.GetPeriods();

                periods_dropdown.DataTextField = "Name";
                periods_dropdown.DataValueField = "ID";
                periods_dropdown.DataBind();

            }
            GVCfsJournal.DataSource = _proc.GetCfsJournalSet(Convert.ToInt32(periods_dropdown.SelectedValue));
            GVPfsJournal.DataSource = _proc.GetPfsJournalSet(Convert.ToInt32(periods_dropdown.SelectedValue));
            GVSpecJournal.DataSource = _proc.GetSpecJournalSet(Convert.ToInt32(periods_dropdown.SelectedValue));
            SetJournal();
            GVCfsJournal.DataBind();
            GVPfsJournal.DataBind();
            GVSpecJournal.DataBind();
        }

        protected void GetJournal_Click(object sender, EventArgs e)
        {

            GVCfsJournal.DataSource = _proc.GetCfsJournalSet(Convert.ToInt32(periods_dropdown.SelectedValue));
            GVPfsJournal.DataSource = _proc.GetPfsJournalSet(Convert.ToInt32(periods_dropdown.SelectedValue));
            GVSpecJournal.DataSource = _proc.GetSpecJournalSet(Convert.ToInt32(periods_dropdown.SelectedValue));
            SetJournal();
            DataBind();
        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVCfsJournal.PageIndex = e.NewPageIndex;
            GVCfsJournal.DataBind();
            GVPfsJournal.PageIndex = e.NewPageIndex;
            GVPfsJournal.DataBind();
            GVSpecJournal.PageIndex = e.NewPageIndex;
            GVSpecJournal.DataBind();
        }

        private void SetJournal()
        {
            var page = Request.QueryString["page"];
            if (string.Equals(page, "vPfsJournal"))
            {
                Journals.SetActiveView(vPfsJournal);
                aPfsJournal.Attributes["class"] = "active";
            }
            else if (string.Equals(page, "vSpecJournal"))
            {
                Journals.SetActiveView(vSpecJournal);
                aSpecJournal.Attributes["class"] = "active";
            }
            else
            {
                Journals.SetActiveView(vCfsJournal);
                aCfsJournal.Attributes["class"] = "active";
            }
        }

        protected void SpecJournalExport(object sender, EventArgs e)
        {
            try
            {
                var book = _save.SavePrintSpecJournal(Convert.ToInt32(periods_dropdown.SelectedValue), periods_dropdown.SelectedItem.Text, _proc.GetSpecJournal(Convert.ToInt32(periods_dropdown.SelectedValue)));
                Response.Clear();
                Response.ClearHeaders();
                book.Save(Response, Path.ChangeExtension(@"ОтчетСотрудники_" + periods_dropdown.SelectedItem.Text, ".xlsx"));
                Response.End();
            }
            catch (Exception error)
            {
                lblerror.InnerText = error.Message;
            }
        }
        protected void CfsJournalExport(object sender, EventArgs e)
        {
            try
            {
                var book = _save.SavePrintCfsJournal(Convert.ToInt32(periods_dropdown.SelectedValue), periods_dropdown.SelectedItem.Text, _proc.GetCfsJournal(Convert.ToInt32(periods_dropdown.SelectedValue)));
                Response.Clear();
                Response.ClearHeaders();
                book.Save(Response, Path.ChangeExtension(@"ОтчетИндивКонсультДети_" + periods_dropdown.SelectedItem.Text, ".xlsx"));
                Response.End();
            }
            catch (Exception error)
            {
                lblerror.InnerText = error.Message;
            }
        }
        protected void PfsJournalExport(object sender, EventArgs e)
        {
            try
            {
                var book = _save.SavePrintPfsJournal(Convert.ToInt32(periods_dropdown.SelectedValue), periods_dropdown.SelectedItem.Text, _proc.GetPfsJournal(Convert.ToInt32(periods_dropdown.SelectedValue)));
                Response.Clear();
                Response.ClearHeaders();
                book.Save(Response, Path.ChangeExtension(@"ОтчетИндивКонсультВзр_" + periods_dropdown.SelectedItem.Text, ".xlsx"));
                Response.End();
            }
            catch (Exception error)
            {
                lblerror.InnerText = error.Message;
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

        protected void GVSpecJournal_Sorting(object sender, GridViewSortEventArgs e)
        {
        }


    }
}