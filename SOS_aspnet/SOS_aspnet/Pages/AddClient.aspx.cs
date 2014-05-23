using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

namespace SOS.Pages
{
    public partial class AddClient : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            selType.DataSource = new List<string> {"CFS", "PFS"};
            selType.DataBind();
        }


        protected void SaveClient_Click(object sender, EventArgs e)
        {
            switch (selType.SelectedIndex)
            {
                case 0:
                    Response.Redirect("CFSConsult.aspx");
                    break;
                case 1:
                    Response.Redirect("PFSConsult.aspx");
                    break;
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
    }
}