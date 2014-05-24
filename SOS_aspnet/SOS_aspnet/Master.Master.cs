using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using SOS.BusinessEntities;
using SOS.DataProcessingLayer;

namespace SOS
{
    public partial class Master : System.Web.UI.MasterPage
    {
        private readonly DataProcessing _proc = new DataProcessing();
        private User _user;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated == false)
            {
                Response.Redirect("~/Pages/LoginPage.aspx");
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    _user = _proc.GetUserByNickName(HttpContext.Current.User.Identity.Name);
                    var lblName = (HtmlGenericControl) this.FindControl("lblUserWelcome");
                    lblName.InnerHtml = _user.Welcome;
                    var lblId = (HtmlGenericControl) this.FindControl("lblId");
                    lblId.InnerHtml = _user.PersonId.ToString(CultureInfo.InvariantCulture);
                    if (_user.Role == "Super")
                    {
                        ((HtmlAnchor)FindControl("linkCfsConsult")).Visible = false;
                        ((HtmlAnchor)FindControl("linkPfsConsult")).Visible = false;
                    }
                    else
                    {
                        ((HtmlAnchor)FindControl("linkJournals")).Visible = false;
                    }
                }
            }
            SetPage();
        }

        private void SetPage()
        {
            var links = new List<HtmlAnchor>
            {
                (HtmlAnchor) FindControl("linkJournals"),
                (HtmlAnchor) FindControl("linkCfsConsult"),
                (HtmlAnchor) FindControl("linkPfsConsult")
            };

            var page = Request.Url.LocalPath;
            if (string.Equals(page, "/Pages/JournalsPage.aspx"))
            {
                links[0].Attributes["class"] = "active";
            }
            else if (string.Equals(page, "/Pages/CFSConsult.aspx"))
            {
                links[1].Attributes["class"] = "active";
            }
            else if (string.Equals(page, "/Pages/PFSConsult.aspx"))
            {
                links[2].Attributes["class"] = "active";
            }

        }


        protected void LogoutUser(object sender, EventArgs e)
        {

            FormsAuthentication.SignOut();

            Response.Redirect("~/Pages/LoginPage.aspx");
        }

        public void ShowErrorMessage(string message)
        {
            Page.ClientScript.RegisterStartupScript(
                        this.GetType(),
                        "mail failed",
                        "<script>alert('" + message + "')</script>");
        }

        protected override void OnError(EventArgs e)
        {
            // At this point we have information about the error
            var ctx = HttpContext.Current;

            ctx.Response.Redirect("~/Pages/error.aspx");

            // --------------------------------------------------
            // To let the page finish running we clear the error
            // --------------------------------------------------
            ctx.Server.ClearError();

            base.OnError(e);
        }


        protected void OnConfirm(object sender, EventArgs e)
        {
            var confirmValue = Request.Form["confirm_value"];
            if (confirmValue != "Yes") return;
            FormsAuthentication.SignOut();
            Response.Redirect("~/Pages/LoginPage.aspx");
        }

    }
}