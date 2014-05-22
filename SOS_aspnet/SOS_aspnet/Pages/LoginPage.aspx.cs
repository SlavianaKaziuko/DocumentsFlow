using System;
using System.Web.Security;
using SOS.DataProcessingLayer;
using SOS.MyMemberShip;

namespace SOS.Pages
{
    public partial class LoginPage : System.Web.UI.Page
    {
        readonly DataProcessing _proc = new DataProcessing();
        private MyMembershipProvider _membership;
        protected void Page_Load(object sender, EventArgs e)
        {
            _membership = new MyMembershipProvider();
            FormsAuthentication.SignOut();

        }


        #region ILogin Members

        private string Account
        { get; set; }

        private string Password
        { get; set; }


        protected void LoginUser(object sender, EventArgs e)
        {
            //ShowErrorMessage("You enter wrong Nickname or Password");
            if (username.Value != string.Empty)
            {
                if (password.Value != string.Empty)
                {

                    Account = username.Value;
                    Password = password.Value;
                    if (_membership.ValidateUser(Account, Password))
                    {
                        //mvLogin.SetActiveView(vWelcome);
                        //lblUser.Text = Account;
                        _proc.Authorize(Account, Password);
                        FormsAuthentication.SetAuthCookie(Account, false);
                        Response.Redirect("~/Pages/Main.aspx");
                    }
                    else
                    {
                        errormessage.InnerText = "Имя пользователя или пароль введены неправильно";
                        errormessage.Visible = true;
                        //ShowErrorMessage("You enter wrong Nickname or Password");
                    }
                }
                else
                {
                    errormessage.InnerText = "Вы не ввели пароль";
                    errormessage.Visible = true;
                    //ShowErrorMessage("You did not enter Password");
                }
            }
            else
            {
                errormessage.InnerText = "Вы не ввели имя пользователя";
                errormessage.Visible = true;
                //ShowErrorMessage("You did not enter NickName");
            }
        }

        public void GoToPasswordRestoringPage(object sender, EventArgs e)
        {
            //mvLogin.SetActiveView(vWait);
            Response.Redirect("~/Pages/PasswordRestoringPage.aspx");
        }

        public void ShowErrorMessage(string message)
        {
            Response.Write("<script>alert('" + message + "')</script>");
        }

        #endregion

    }
}