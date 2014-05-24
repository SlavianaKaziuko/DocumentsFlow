using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;
using System.Web.UI;
using SOS.BusinessEntities;
using SOS.DataProcessingLayer;

namespace SOS.Pages
{
    public partial class AddClient : Page
    {
        private readonly DataProcessing _proc = new DataProcessing();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            selType.DataSource = new List<string> {"CFS", "PFS"};
            selType.DataBind();
        }


        protected void SaveClient_Click(object sender, EventArgs e)
        {
            _proc.AddClient(new Client(selType.SelectedItem.Text)
            {
                Surname = txtSurname.Text,
                Name = txtName.Text,
                FathersName = txtFarthersName.Text,
                DateOfBirth = Convert.ToDateTime(txtBirthDate.Value,CultureInfo.InvariantCulture),
                Sex = rbMale.SelectedValue == "Мужской" ? "M" : "F"
            });
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