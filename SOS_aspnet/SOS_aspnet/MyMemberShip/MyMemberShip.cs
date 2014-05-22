using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;
using SOS.BusinessEntities;
using SOS.DataProcessingLayer;

namespace SOS.MyMemberShip
{
    public class MyMembershipProvider : MembershipProvider
    {
        #region Fields

        private bool _enablePasswordReset;
        private const bool _enablePasswordRetrieval = false;
        private const bool _RequiresQuestionAndAnswer = false;
        private const bool _RequiresUniqueEmail = true;
        private int _maxInvalidPasswordAttempts;
        private int _passwordAttemptWindow;
        private int _minRequiredPasswordLength;
        private int _minRequiredNonalphanumericCharacters;
        private string _passwordStrengthRegularExpression;
        private const MembershipPasswordFormat _PasswordFormat = MembershipPasswordFormat.Hashed;

        #endregion

        #region Properties
        public override int MaxInvalidPasswordAttempts
        {
            get
            {
                return _maxInvalidPasswordAttempts;
            }
        }
        public override int MinRequiredNonAlphanumericCharacters
        {
            get
            {
                return _minRequiredNonalphanumericCharacters;
            }
        }
        public override int MinRequiredPasswordLength
        {
            get
            {
                return _minRequiredPasswordLength;
            }
        }

        public override int PasswordAttemptWindow
        {
            get
            {
                return _passwordAttemptWindow;
            }
        }
        public override MembershipPasswordFormat PasswordFormat
        {
            get
            {
                return _PasswordFormat;
            }
        }
        public override string PasswordStrengthRegularExpression
        {
            get
            {
                return _passwordStrengthRegularExpression;
            }
        }
        public override bool RequiresQuestionAndAnswer
        {
            get
            {
                return _RequiresQuestionAndAnswer;
            }
        }
        public override bool RequiresUniqueEmail
        {
            get
            {
                return _RequiresUniqueEmail;
            }
        }

        public override bool EnablePasswordReset
        {
            get
            {
                return _enablePasswordReset;
            }
        }
        public override bool EnablePasswordRetrieval
        {
            get
            {
                return _enablePasswordRetrieval;
            }
        }



        #endregion


        public override void Initialize(string name, NameValueCollection config)
        {
            if (config == null)
                throw new ArgumentNullException("config");
            if (string.IsNullOrEmpty(name))
                name = "CustomMembershipProvider";
            if (String.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "Custom Membership Provider");
            }
            base.Initialize(name, config);
            GetConfigValue(config["applicationName"],
                System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
            _maxInvalidPasswordAttempts = Convert.ToInt32(
                            GetConfigValue(config["maxInvalidPasswordAttempts"], "5"));
            _passwordAttemptWindow = Convert.ToInt32(
                            GetConfigValue(config["passwordAttemptWindow"], "10"));
            _minRequiredNonalphanumericCharacters = Convert.ToInt32(
                            GetConfigValue(config["minRequiredNonalphanumericCharacters"], "1"));
            _minRequiredPasswordLength = Convert.ToInt32(
                            GetConfigValue(config["minRequiredPasswordLength"], "6"));
            _enablePasswordReset = Convert.ToBoolean(
                            GetConfigValue(config["enablePasswordReset"], "true"));
            _passwordStrengthRegularExpression = Convert.ToString(
                            GetConfigValue(config["passwordStrengthRegularExpression"], ""));
        }

        private string GetConfigValue(string configValue, string defaultValue)
        {
            if (string.IsNullOrEmpty(configValue))
                return defaultValue;
            return configValue;
        }

        //public MyMemberShip(string _strconn)
        //{
        //    //string connstr = (string)ConfigurationManager.ConnectionStrings["SOSDB"].ToString();
        //    
        //}

        public override string ApplicationName
        { get; set; }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            var proc = new DataProcessing();
            if (IsUserExistsWithNickName(username))
            {
                return proc.ChangePassword(username, oldPassword, GetMd5Hash(newPassword));
            }
            return false;
        }



        public MembershipUser CreateUser(string username, string name, string password, string email, out MembershipCreateStatus status)
        {
            MembershipUser created;
            var proc = new DataProcessing();
            var args =
           new ValidatePasswordEventArgs(username, password, true);
            OnValidatingPassword(args);

            if (args.Cancel)
            {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }

            if (RequiresUniqueEmail && GetUserNameByEmail(email) != string.Empty)
            {
                status = MembershipCreateStatus.DuplicateEmail;
                return null;
            }
            if (!IsUserExistsWithEmail(email) && !IsUserExistsWithNickName(username))
            {
                var userObj = new User
                {
                    Username = username,
                    Email = email,
                    Welcome = name,
                    Guid = Guid.NewGuid().ToString()
                };
                proc.AddUser(userObj);
                status = MembershipCreateStatus.Success;
                 created = new MembershipUser(
                    Membership.Provider.Name,
                    userObj.Username,
                    userObj.Guid,
                    userObj.Email,
                    string.Empty,
                    string.Empty,
                    true,
                    false,
                    DateTime.Now,
                    DateTime.Now,
                    DateTime.Now,
                    DateTime.Now,
                    DateTime.Now);
            }
            else
            {
                status = MembershipCreateStatus.DuplicateUserName;
                created = null;
            }
                return created;
        }


        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            var proc = new DataProcessing();

            var user = proc.GetUserByNickName(username);
            return new MembershipUser(
                   Membership.Provider.Name,
                   user.Username,
                   user.Guid,
                   user.Email,
                   string.Empty,
                   string.Empty,
                   true,
                   false,
                   DateTime.Now,
                   DateTime.Now,
                   DateTime.Now,
                   DateTime.Now,
                   DateTime.Now);
        }

        public override string GetUserNameByEmail(string email)
        {
            var proc = new DataProcessing();

            string nickname;

            if (IsUserExistsWithEmail(email))
            {
                nickname = proc.GetUserNameByEmail(email);
            }
            else
            {
                return string.Empty;
            }

            return nickname;
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            var proc = new DataProcessing();

            //var md5Pswd = GetMd5Hash(password);

            return proc.VerifyUser(username, password);
        }

        public bool IsUserExistsWithEmail(string email)
        {
            var proc = new DataProcessing();

            return proc.IsUserExistsWithEmail(email);
        }

        public bool IsUserExistsWithNickName(string nickname)
        {
            var proc = new DataProcessing();

            return proc.IsUserExistsWithNickName(nickname);
        }

        public static string GetMd5Hash(string value)
        {
            var md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));
            var sBuilder = new StringBuilder();
            foreach (var t in data)
            {
                sBuilder.Append(t.ToString("x2"));
            }
            return sBuilder.ToString();
        }

        #region NotOverrided Methods
        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            return false;
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }


        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }
        #endregion



    }
}