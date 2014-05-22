using System;
using System.Globalization;

namespace SOS.UserControls
{
    public partial class Calendar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack) return;
            date.InnerText = DateTime.Today.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture); //"2014/09/02" 
        }

        public string GetDate()
        {
            return date.InnerText;
        }
    }
}