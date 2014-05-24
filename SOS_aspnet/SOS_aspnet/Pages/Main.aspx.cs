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
                _curUser = _proc.GetUserByNickName(HttpContext.Current.User.Identity.Name);
                var stuffjournal = _proc.GetIndivJournalByStaffSet(_curUser.PersonId);
                GVSpecJournal.DataSource = _proc.GetSpecJournalSet(0);
                GVSpecJournal.DataBind();
                GVIndivJournal.DataSource = stuffjournal;
                selConsult.DataSource = stuffjournal;
                selConsult.DataTextField = "ID";
                selConsult.DataValueField = "ID";
                selConsult.DataBind();

                GVIndivJournal.DataBind();
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

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVIndivJournal.PageIndex = e.NewPageIndex;
            GVIndivJournal.DataBind();
        }

        protected void JournalExport(object sender, EventArgs e)
        {

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

        protected void ViewConsult(object sender, EventArgs e)
        {
            Response.Redirect("CFSConsult.aspx?consultid=" + selConsult.SelectedValue);
        }
    }
}