using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SOS.BusinessEntities;
using SOS.DataProcessingLayer;

namespace SOS.Pages
{
    public partial class Main : Page
    {
        private readonly DataProcessing _proc = new DataProcessing();
        private User _curUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated == false)
            {
                Response.Redirect("~/Pages/LoginPage.aspx");
            }
            else
            {
                if (IsPostBack) return;
                _curUser = _proc.GetUserByNickName(HttpContext.Current.User.Identity.Name);
                GVSpecJournal.DataSource = _proc.GetSpecJournalSet(0);
                GVSpecJournal.DataBind();

                var cfsjournal = _proc.GetIndivCfsJournalByStaffSet(_curUser.PersonId);
                GVIndivCfsJournal.DataSource = cfsjournal;
                GVIndivCfsJournal.DataBind();
                var pfsjournal = _proc.GetIndivPfsJournalByStaffSet(_curUser.PersonId);
                GVIndivPfsJournal.DataSource = pfsjournal;
                GVIndivPfsJournal.DataBind();

                selCfsConsult.DataSource = cfsjournal;
                selCfsConsult.DataTextField = "ID";
                selCfsConsult.DataValueField = "ID";
                selCfsConsult.DataBind();

                selPfsConsult.DataSource = pfsjournal;
                selPfsConsult.DataTextField = "ID";
                selPfsConsult.DataValueField = "ID";
                selPfsConsult.DataBind();

                switch (_curUser.Role)
                {
                    case "Super":
                        divUser.Visible = false;
                        break;
                    case "User":
                        divSuper.Visible = false;
                        break;
                }
            }
        }

        protected void CFSgridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVIndivCfsJournal.PageIndex = e.NewPageIndex;
            GVIndivCfsJournal.DataBind();
        }

        protected void PFSgridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVIndivPfsJournal.PageIndex = e.NewPageIndex;
            GVIndivPfsJournal.DataBind();
        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVSpecJournal.PageIndex = e.NewPageIndex;
            GVSpecJournal.DataBind();
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

        protected void Sorting(object sender, GridViewSortEventArgs e)
        {
        }

        protected void ViewCfsConsult(object sender, EventArgs e)
        {
            Response.Redirect("CFSConsult.aspx?consultid=" + selCfsConsult.SelectedValue);
        }

        protected void ViewPfsConsult(object sender, EventArgs e)
        {
            Response.Redirect("PFSConsult.aspx?consultid=" + selPfsConsult.SelectedValue);
        }
    }
}