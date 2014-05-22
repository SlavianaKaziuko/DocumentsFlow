using System;
using System.Net;
using System.Web;
using System.Web.UI.WebControls;
using SOS.DataProcessingLayer;

namespace SOS.Pages
{
    public partial class Main : System.Web.UI.Page
    {
        private readonly DataProcessing _proc = new DataProcessing();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            var user = _proc.GetUserByNickName(HttpContext.Current.User.Identity.Name);
            if (Master != null)
                GVIndivJournal.DataSource = _proc.GetIndivJournalByStaffSet(user.PersonId);
            DataBind();
        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVIndivJournal.PageIndex = e.NewPageIndex;
            GVIndivJournal.DataBind();
        }

        protected void JournalExport(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}