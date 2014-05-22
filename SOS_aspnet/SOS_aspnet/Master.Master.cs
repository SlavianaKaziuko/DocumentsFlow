using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using SOS.DataProcessingLayer;

namespace SOS
{
    public partial class Master : System.Web.UI.MasterPage
    {
        private readonly DataProcessing _proc = new DataProcessing();
        
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
                    var user = _proc.GetUserByNickName(HttpContext.Current.User.Identity.Name);
                    var lblName = (HtmlGenericControl) this.FindControl("lblUserWelcome");
                    lblName.InnerHtml = user.Welcome;
                    var lblId = (HtmlGenericControl) this.FindControl("lblId");
                    lblId.InnerHtml = user.PersonId.ToString(CultureInfo.InvariantCulture);
                    if (user.Role == "Super")
                    {

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
    }
}