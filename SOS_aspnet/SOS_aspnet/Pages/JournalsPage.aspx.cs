using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SOS.BusinessEntities;
using SOS.DataProcessingLayer;

namespace SOS.Pages
{
    public partial class JournalsPage : Page
    {
        readonly DataProcessing _proc = new DataProcessing();
        readonly SaveExport _save = new SaveExport();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                periods_dropdown.DataSource = _proc.GetPeriods();

                periods_dropdown.DataTextField = "Name";
                periods_dropdown.DataValueField = "ID";
                DataBind();

            }
            GVCfsJournal.DataSource = _proc.GetCfsJournalSet(Convert.ToInt32(periods_dropdown.SelectedValue));
            //GVCfsJournal.DataSource = db.GetPfsJournal(0);
            GVSpecJournal.DataSource = _proc.GetSpecJournalSet(Convert.ToInt32(periods_dropdown.SelectedValue));
            SetJournal();
            DataBind();
        }

        protected void GetCfsJournal_Click(object sender, EventArgs e)
        {

            GVCfsJournal.DataSource = _proc.GetCfsJournalSet(Convert.ToInt32(periods_dropdown.SelectedValue));
            //GVCfsJournal.DataSource = db.GetPfsJournal(0);
            GVSpecJournal.DataSource = _proc.GetSpecJournalSet(Convert.ToInt32(periods_dropdown.SelectedValue));
            SetJournal();
            DataBind();
        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVCfsJournal.PageIndex = e.NewPageIndex;
            GVCfsJournal.DataBind();
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
                _save.SavePrintSpecJournal(Convert.ToInt32(periods_dropdown.SelectedValue), periods_dropdown.Text, (List<SpecJournal>)GVSpecJournal.DataSource);
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
                _save.SavePrintCfsJournal(Convert.ToInt32(periods_dropdown.SelectedValue), periods_dropdown.Text, (List<CfsJournal>)GVSpecJournal.DataSource);
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
                _save.SavePrintPfsJournal(Convert.ToInt32(periods_dropdown.SelectedValue), periods_dropdown.Text, (List<PfsJournal>)GVSpecJournal.DataSource);
            }
            catch (Exception error)
            {
                lblerror.InnerText = error.Message;
            }
        }
    }
}