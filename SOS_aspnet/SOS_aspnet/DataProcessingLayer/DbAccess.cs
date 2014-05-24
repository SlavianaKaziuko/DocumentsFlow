using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using SOS.BusinessEntities;
using Type = SOS.BusinessEntities.Type;

namespace SOS.DataProcessingLayer
{
    public class DataProcessing
    {
        public User Thisuser;
        private readonly SqlConnection _connection;

        public DataProcessing()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SOSDB"].ConnectionString);
        }

        public bool Authorize(string username, string password)
        {
            User user = null;
            var command = new SqlCommand("exec [authorization] @Username, @Password", _connection);
            command.Parameters.Add("@Username", SqlDbType.NVarChar, 20).Value = username;
            command.Parameters.Add("@Password", SqlDbType.NVarChar, 20).Value = password;
            try
            {
                _connection.Open();
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    user = new User
                    {
                        Username = username,
                        PersonId = Convert.ToInt32(dr["PersonID"].ToString()),
                        Welcome = dr["Welcome"].ToString(),
                        Role = dr["Role"].ToString()
                    };
                }
            }
            catch (SqlException exp)
            {
                throw new Exception(exp.Message);
            }
            finally
            {
                _connection.Close();
            }
            Thisuser = user;
            return user != null;
        }

        public void AddUser(User user)
        {

        }

        public void AddClient(Client client)
        {
            var command = client.Type == "PFS"
                ? new SqlCommand("exec addPFS @Surname, @Name,@FartherName,@Sex,@DateOFB", _connection)
                : new SqlCommand("exec addCFS @Surname, @Name,@FartherName,@Sex,@DateOFB", _connection);
            command.Parameters.Add("@Surname", SqlDbType.NVarChar, 30).Value = client.Surname;
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 30).Value = client.Name;
            command.Parameters.Add("@FartherName", SqlDbType.NVarChar, 30).Value = client.FathersName;
            command.Parameters.Add("@Sex", SqlDbType.Char, 1).Value = client.Sex;
            command.Parameters.Add("@DateOFB", SqlDbType.DateTime).Value = client.DateOfBirth;
            try
            {
                _connection.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException exp)
            {
                throw new Exception(exp.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        #region Pfs

        public int SavePfsConsult(PfsConsult consult)
        {
            _connection.Open();
            int id;
            var command =
                new SqlCommand(
                    "exec addPFSConsult @ClientID,@SpecialistID,@Datetime,@STCGivingInformation,@STCConsultation,@STCPsychodiagnost,@STCTerrapevtSession,"
                    +
                    "@STCAnother,@STPScheduled,@STPAnother,@FormTypeID,@ContentTypeID,@ProblemDiscription,@ConversDiscription,@ConversResults,@NextSessionDate",
                    _connection);
            command.Parameters.Add("@ClientID", SqlDbType.Int).Value = consult.ClientId;
            command.Parameters.Add("@SpecialistID", SqlDbType.Int).Value = consult.LocalSpecialistId;
            command.Parameters.Add("@Datetime", SqlDbType.DateTime).Value = consult.Date;
            command.Parameters.Add("@STCGivingInformation", SqlDbType.Char, 1).Value = consult.StcGivingInformation
                ? "Y"
                : "N";
            command.Parameters.Add("@STCConsultation", SqlDbType.Char, 1).Value = consult.StcConsultation ? "Y" : "N";
            command.Parameters.Add("@STCPsychodiagnost", SqlDbType.Char, 1).Value = consult.StcPsychodiagnost
                ? "Y"
                : "N";
            command.Parameters.Add("@STCTerrapevtSession", SqlDbType.Char, 1).Value = consult.StcTerrapevtSession
                ? "Y"
                : "N";
            command.Parameters.Add("@STCAnother", SqlDbType.NVarChar, 40).Value = consult.StcAnother ?? "";
            command.Parameters.Add("@STPScheduled", SqlDbType.Char, 1).Value = consult.StpScheduled ? "Y" : "N";
            command.Parameters.Add("@STPAnother", SqlDbType.NVarChar, 40).Value = consult.StpAnother ?? "";
            command.Parameters.Add("@FormTypeID", SqlDbType.Int).Value = consult.FormType;
            command.Parameters.Add("@ContentTypeID", SqlDbType.Int).Value = consult.ContentType;
            command.Parameters.Add("@ProblemDiscription", SqlDbType.NVarChar, 300).Value = consult.ProblemDiscription;
            command.Parameters.Add("@ConversDiscription", SqlDbType.NVarChar, -1).Value = consult.ConversDiscription;
            command.Parameters.Add("@ConversResults", SqlDbType.NVarChar, -1).Value = consult.ConversResults;
            command.Parameters.Add("@NextSessionDate", SqlDbType.DateTime).Value = consult.NextSessionDate;
            try
            {
                id = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (SqlException exp)
            {
                throw new Exception(exp.Message);
            }
            finally
            {
                _connection.Close();
            }
            return id;
        }

        public void UpdatePfsConsult(PfsConsult consult)
        {
            var command =
                new SqlCommand(
                    "exec updatePFSConsult @ID,@ClientID,@SpecialistID,@Datetime,@STCGivingInformation,@STCConsultation,@STCPsychodiagnost,@STCTerrapevtSession,"
                    +
                    "@STCAnother,@STPScheduled,@STPAnother,@FormTypeID,@ContentTypeID,@ProblemDiscription,@ConversDiscription,@ConversResults,@NextSessionDate",
                    _connection);
            command.Parameters.Add("@ID", SqlDbType.Int).Value = consult.Id;
            command.Parameters.Add("@ClientID", SqlDbType.Int).Value = consult.ClientId;
            command.Parameters.Add("@SpecialistID", SqlDbType.Int).Value = consult.LocalSpecialistId;
            command.Parameters.Add("@Datetime", SqlDbType.DateTime).Value = consult.Date;
            command.Parameters.Add("@STCGivingInformation", SqlDbType.Char, 1).Value = consult.StcGivingInformation
                ? "Y"
                : "N";
            command.Parameters.Add("@STCConsultation", SqlDbType.Char, 1).Value = consult.StcConsultation ? "Y" : "N";
            command.Parameters.Add("@STCPsychodiagnost", SqlDbType.Char, 1).Value = consult.StcPsychodiagnost
                ? "Y"
                : "N";
            command.Parameters.Add("@STCTerrapevtSession", SqlDbType.Char, 1).Value = consult.StcTerrapevtSession
                ? "Y"
                : "N";
            command.Parameters.Add("@STCAnother", SqlDbType.NVarChar, 40).Value = consult.StcAnother ?? "";
            command.Parameters.Add("@STPScheduled", SqlDbType.Char, 1).Value = consult.StpScheduled ? "Y" : "N";
            command.Parameters.Add("@STPAnother", SqlDbType.NVarChar, 40).Value = consult.StpAnother ?? "";
            command.Parameters.Add("@FormTypeID", SqlDbType.Int).Value = consult.FormType;
            command.Parameters.Add("@ContentTypeID", SqlDbType.Int).Value = consult.ContentType;
            command.Parameters.Add("@ProblemDiscription", SqlDbType.NVarChar, 300).Value = consult.ProblemDiscription;
            command.Parameters.Add("@ConversDiscription", SqlDbType.NVarChar, -1).Value = consult.ConversDiscription;
            command.Parameters.Add("@ConversResults", SqlDbType.NVarChar, -1).Value = consult.ConversResults;
            command.Parameters.Add("@NextSessionDate", SqlDbType.DateTime).Value = consult.NextSessionDate;
            try
            {
                _connection.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException exp)
            {
                throw new Exception(exp.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public PfsConsult GetPfsConsult(int id)
        {
            var consult = new PfsConsult {Id = id};
            var command = new SqlCommand("exec [getOnePFSConsult] @ConsultID", _connection);
            command.Parameters.Add("@ConsultID", SqlDbType.Int).Value = id;
            try
            {
                _connection.Open();
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    consult.Specialist = dr["Специалист"].ToString();
                    consult.Date = Convert.ToDateTime(dr["Дата проведения"].ToString());
                    consult.Client = dr["ФИО клиента"].ToString();
                    consult.Age = Convert.ToInt32(dr["Возраст клиента"].ToString());
                    consult.Form = dr["Тип формы"].ToString();
                    consult.Content = dr["Тип содержания"].ToString();
                    consult.StcGivingInformation = dr["Предоставление информации"].ToString() == "Y";
                    consult.StcConsultation = dr["Консультация"].ToString() == "Y";
                    consult.StcPsychodiagnost = dr["Психодиагностика"].ToString() == "Y";
                    consult.StcTerrapevtSession = dr["Терапевтическая сессия"].ToString() == "Y";
                    consult.StcAnother = dr["Другая"].ToString();
                    consult.StpScheduled = dr["По расписанию"].ToString() == "Y";
                    consult.StpAnother = dr["Другое"].ToString();
                    consult.ProblemDiscription = dr["Описание проблемы, запрос"].ToString();
                    consult.ConversDiscription = dr["Основные моменты разговора"].ToString();
                    consult.ConversResults = dr["Результаты"].ToString();
                    consult.ClientId = Convert.ToInt32(dr["ClientID"].ToString());
                    consult.FormType = Convert.ToInt32(dr["FormID"].ToString());
                    consult.ContentType = Convert.ToInt32(dr["ContentID"].ToString());
                }
            }
            catch (SqlException exp)
            {
                throw new Exception(exp.Message);
            }
            finally
            {
                _connection.Close();
            }
            return consult;

        }

        #endregion

        #region Cfs

        public int SaveCfsConsult(CfsConsult consult)
        {
            int id;
            var command =
                new SqlCommand(
                    "exec addCFSConsult @ClientID,@SpecialistID,@Datetime,@FormTypeID,@ContentTypeID,@ProblemDiscription,@ConversDiscription,"
                    + "@ConversResults,@NextSessionDate", _connection);
            command.Parameters.Add("@ClientID", SqlDbType.Int).Value = consult.ClientId;
            command.Parameters.Add("@SpecialistID", SqlDbType.Int).Value = consult.LocalSpecialistId;
            command.Parameters.Add("@Datetime", SqlDbType.DateTime).Value = consult.Date;
            command.Parameters.Add("@FormTypeID", SqlDbType.Int).Value = consult.FormType;
            command.Parameters.Add("@ContentTypeID", SqlDbType.Int).Value = consult.ContentType;
            command.Parameters.Add("@ProblemDiscription", SqlDbType.NVarChar, 300).Value = consult.ProblemDiscription;
            command.Parameters.Add("@ConversDiscription", SqlDbType.NVarChar, -1).Value = consult.ConversDiscription;
            command.Parameters.Add("@ConversResults", SqlDbType.NVarChar, -1).Value = consult.ConversResults;
            command.Parameters.Add("@NextSessionDate", SqlDbType.DateTime).Value = consult.NextSessionDate;
            try
            {
                _connection.Open();
                id = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (SqlException exp)
            {
                throw new Exception(exp.Message);
            }
            finally
            {
                _connection.Close();
            }
            return id;
        }

        public void UpdateCfsConsult(CfsConsult consult)
        {
            var command =
                new SqlCommand(
                    "exec updateCFSConsult @ID,@ClientID,@SpecialistID,@Datetime,@FormTypeID,@ContentTypeID,@ProblemDiscription,@ConversDiscription,@ConversResults,"
                    + "@NextSessionDate", _connection);
            command.Parameters.Add("@ID", SqlDbType.Int).Value = consult.Id;
            command.Parameters.Add("@ClientID", SqlDbType.Int).Value = consult.ClientId;
            command.Parameters.Add("@SpecialistID", SqlDbType.Int).Value = consult.LocalSpecialistId;
            command.Parameters.Add("@Datetime", SqlDbType.DateTime).Value = consult.Date;
            command.Parameters.Add("@FormTypeID", SqlDbType.Int).Value = consult.FormType;
            command.Parameters.Add("@ContentTypeID", SqlDbType.Int).Value = consult.ContentType;
            command.Parameters.Add("@ProblemDiscription", SqlDbType.NVarChar, 300).Value = consult.ProblemDiscription;
            command.Parameters.Add("@ConversDiscription", SqlDbType.NVarChar, -1).Value = consult.ConversDiscription;
            command.Parameters.Add("@ConversResults", SqlDbType.NVarChar, -1).Value = consult.ConversResults;
            command.Parameters.Add("@NextSessionDate", SqlDbType.DateTime).Value = consult.NextSessionDate;
            try
            {
                _connection.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException exp)
            {
                throw new Exception(exp.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public CfsConsult GetCfsConsult(int id)
        {
            var consult = new CfsConsult {Id = id};
            var command = new SqlCommand("exec [getOneCFSConsult] @ConsultID", _connection);
            command.Parameters.Add("@ConsultID", SqlDbType.Int).Value = id;
            try
            {
                _connection.Open();
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    consult.Specialist = dr["Специалист"].ToString();
                    consult.Date = Convert.ToDateTime(dr["Дата проведения"].ToString());
                    consult.Client = dr["ФИО клиента"].ToString();
                    consult.Age = Convert.ToInt32(dr["Возраст клиента"].ToString());
                    consult.Form = dr["Тип формы"].ToString();
                    consult.Content = dr["Тип содержания"].ToString();
                    consult.ProblemDiscription = dr["Описание проблемы, запрос"].ToString();
                    consult.ConversDiscription = dr["Основные моменты разговора"].ToString();
                    consult.ConversResults = dr["Результаты"].ToString();
                    consult.ClientId = Convert.ToInt32(dr["ClientID"].ToString());
                    consult.FormType = Convert.ToInt32(dr["FormID"].ToString());
                    consult.ContentType = Convert.ToInt32(dr["ContentID"].ToString());
                }
            }
            catch (SqlException exp)
            {
                throw new Exception(exp.Message);
            }
            finally
            {
                _connection.Close();
            }
            return consult;
        }

        #endregion

        #region GetJournals

        public List<Period> GetPeriods()
        {
            var results = new List<Period>();
            var command = new SqlCommand("SELECT ID, Name FROM [dbo].[periods_full]", _connection);
            try
            {
                _connection.Open();
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    var period = new Period {Id = dr.GetInt32(0), Name = dr["Name"].ToString()};
                    results.Add(period);
                }
            }
            catch (SqlException exp)
            {
                throw new Exception(exp.Message);
            }
            finally
            {
                _connection.Close();
            }
            return results;
        }

        public List<SpecJournal> GetSpecJournal(int periodId)
        {
            var results = new List<SpecJournal>();
            var command = new SqlCommand("exec [GetSpecJournal] @periodId", _connection);
            command.Parameters.Add("@periodId", SqlDbType.Int).Value = periodId;
            try
            {
                _connection.Open();
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    var sj = new SpecJournal(dr.FieldCount - 1) {Specialist = dr["Специалист"].ToString()};
                    for (var i = 0; i < sj.Counts.Length; i++)
                    {
                        sj.Counts[i] = dr.GetInt32(i + 1);
                    }
                    results.Add(sj);
                }
            }
            catch (SqlException exp)
            {
                throw new Exception(exp.Message);
            }
            finally
            {
                _connection.Close();
            }
            return results;
        }

        public List<PfsJournal> GetPfsJournal(int periodId)
        {
            var results = new List<PfsJournal>();
            var command = new SqlCommand("exec [GetPFSJournal] @periodId", _connection);
            command.Parameters.Add("@periodId", SqlDbType.Int).Value = periodId;
            try
            {
                _connection.Open();
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    var sj = new PfsJournal(dr.FieldCount - 1) {Client = dr["ФИО матери"].ToString()};
                    for (var i = 0; i < sj.Counts.Length; i++)
                    {
                        sj.Counts[i] = dr.GetInt32(i + 1);
                    }
                    results.Add(sj);
                }
            }
            catch (SqlException exp)
            {
                throw new Exception(exp.Message);
            }
            finally
            {
                _connection.Close();
            }
            return results;
        }

        public List<CfsJournal> GetCfsJournal(int periodId)
        {
            var results = new List<CfsJournal>();
            var command = new SqlCommand("exec [GetCFSJournal] @periodId", _connection);
            command.Parameters.Add("@periodId", SqlDbType.Int).Value = periodId;
            try
            {
                _connection.Open();
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    var sj = new CfsJournal(dr.FieldCount - 1) {Client = dr["ФИ ребёнка"].ToString()};
                    for (var i = 0; i < sj.Counts.Length; i++)
                    {
                        sj.Counts[i] = dr.GetInt32(i + 1);
                    }
                    results.Add(sj);
                }
            }
            catch (SqlException exp)
            {
                throw new Exception(exp.Message);
            }
            finally
            {
                _connection.Close();
            }
            return results;
        }

        public DataSet GetCfsJournalSet(int periodId)
        {
            var da = new SqlDataAdapter();
            var ds = new DataSet();
            var command = new SqlCommand("exec [GetCFSJournal] @periodId", _connection);
            command.Parameters.Add("@periodId", SqlDbType.Int).Value = periodId;
            try
            {
                da.SelectCommand = command;
                _connection.Open();
                da.Fill(ds);
            }
            catch (SqlException exp)
            {
                throw new Exception(exp.Message);
            }
            finally
            {
                _connection.Close();
            }
            return ds;
        }

        public DataSet GetPfsJournalSet(int periodId)
        {
            var da = new SqlDataAdapter();
            var ds = new DataSet();
            var command = new SqlCommand("exec [GetPFSJournal] @periodId", _connection);
            command.Parameters.Add("@periodId", SqlDbType.Int).Value = periodId;
            try
            {
                da.SelectCommand = command;
                _connection.Open();
                da.Fill(ds);
            }
            catch (SqlException exp)
            {
                throw new Exception(exp.Message);
            }
            finally
            {
                _connection.Close();
            }
            return ds;
        }

        public DataSet GetSpecJournalSet(int periodId)
        {
            var da = new SqlDataAdapter();
            var ds = new DataSet();
            var command = new SqlCommand("exec [GetSpecJournal] @periodId", _connection);
            command.Parameters.Add("@periodId", SqlDbType.Int).Value = periodId;
            try
            {
                da.SelectCommand = command;
                _connection.Open();
                da.Fill(ds);
            }
            catch (SqlException exp)
            {
                throw new Exception(exp.Message);
            }
            finally
            {
                _connection.Close();
            }
            return ds;
        }

        #endregion


        public bool VerifyUser(string username, string password)
        {

            const string commandText = @"Select Count(*) from users Where [UserName]=@username And  [Password]=@pass";
            var cmd = new SqlCommand(commandText, _connection);

            cmd.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = username;

            cmd.Parameters.Add("@pass", SqlDbType.NVarChar, 50).Value = password;
            int i;
            try
            {
                _connection.Open();
                i = (int) cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
            finally
            {
                _connection.Close();
            }
            var flag = i != 0;

            return flag;
        }

        public bool IsUserExistsWithEmail(string email)
        {
            throw new NotImplementedException();
        }

        public bool IsUserExistsWithNickName(string nickname)
        {
            throw new NotImplementedException();
        }

        public User GetUserByNickName(string username)
        {
            const string commandText =
                @"Select [Username],[Password],[Email],[Welcome],[PersonID],[Role],[Guid] from users Where [UserName]=@username";

            var command = new SqlCommand(commandText, _connection);
            User user = null;
            command.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = username;
            try
            {
                _connection.Open();
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    user = new User
                    {
                        Email = dr["Email"].ToString(),
                        Username = dr["Username"].ToString(),
                        Welcome = dr["Welcome"].ToString(),
                        Role = dr["Role"].ToString(),
                        PersonId = Convert.ToInt32(dr["PersonID"])
                    };
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
            finally
            {
                _connection.Close();
            }

            return user;
        }

        public bool ChangePassword(string username, string oldPassword, string p)
        {
            throw new NotImplementedException();
        }

        public string GetUserNameByEmail(string email)
        {
            const string commandText = @"Select [Username] from users Where [Email]=@email";

            var command = new SqlCommand(commandText, _connection);
            string username;
            command.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = email;
            try
            {
                _connection.Open();
                username = (string) command.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
            finally
            {
                _connection.Close();
            }

            return username;
        }

        public List<Client> GetCfsList()
        {
            var resultList = new List<Client>();
            var commandText =
                @"Select [ID],[Surname],[Name],[FatherName],[Sex],[DateOfBirth] from [dbo].[children_of_FS] ";
            var command = new SqlCommand(commandText, _connection);
            try
            {
                _connection.Open();
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    var user = new Client("CFS")
                    {
                        Id = Convert.ToInt32(dr["ID"].ToString()),
                        Surname = dr["Surname"].ToString(),
                        Name = dr["Name"].ToString(),
                        FathersName = dr["FatherName"].ToString(),
                        Sex = dr["Sex"].ToString(),
                        DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"].ToString()),
                    };
                    user.FIO = user.Surname + " " + user.Name + " " + user.FathersName;
                    resultList.Add(user);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
            finally
            {
                _connection.Close();
            }

            return resultList;
        }

        public List<Type> GetContentTypes(string clientType)
        {
            var resultList = new List<Type>();

            const string commandText = @"Select [ID],[Content] from [dbo].[indiv_content_type] Where [Relates]=@Relates";

            var command = new SqlCommand(commandText, _connection);
            command.Parameters.Add("@Relates", SqlDbType.NVarChar, 50).Value = clientType;

            try
            {
                _connection.Open();
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    var type = new Type()
                    {
                        Id = Convert.ToInt32(dr["ID"].ToString()),
                        TypeName = dr["Content"].ToString(),
                    };
                    resultList.Add(type);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
            finally
            {
                _connection.Close();
            }

            return resultList;
        }

        public List<Type> GetFormTypes(string clientType)
        {
            var resultList = new List<Type>();
            const string commandText = @"Select [ID],[Form] from [dbo].[indiv_form_type] Where [Relates]=@Relates";

            var command = new SqlCommand(commandText, _connection);
            command.Parameters.Add("@Relates", SqlDbType.NVarChar, 50).Value = clientType;
            try
            {
                _connection.Open();
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    var type = new Type()
                    {
                        Id = Convert.ToInt32(dr["ID"].ToString()),
                        TypeName = dr["Form"].ToString(),
                    };
                    resultList.Add(type);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
            finally
            {
                _connection.Close();
            }
            return resultList;
        }

        public List<Client> GetPfsList()
        {
            var resultList = new List<Client>();
            const string commandText =
                @"Select [ID],[Surname],[Name],[FatherName],[Sex],[DateOfBirth] from [dbo].[parents_of_FS] ";
            var command = new SqlCommand(commandText, _connection);
            try
            {
                _connection.Open();
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    var user = new Client("PFS")
                    {
                        Id = Convert.ToInt32(dr["ID"].ToString()),
                        Surname = dr["Surname"].ToString(),
                        Name = dr["Name"].ToString(),
                        FathersName = dr["FatherName"].ToString(),
                        Sex = dr["Sex"].ToString(),
                        DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"].ToString()),
                    };
                    user.FIO = user.Surname + " " + user.Name + " " + user.FathersName;
                    resultList.Add(user);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
            finally
            {
                _connection.Close();
            }

            return resultList;
        }

        public List<JournalByStaff> GetIndivJournalByStaff(int specID)
        {
            var results = new List<JournalByStaff>();
            var command = new SqlCommand("exec [consults_by_staff] @specialistID", _connection);
            command.Parameters.Add("@specialistID", SqlDbType.Int).Value = specID;
            try
            {
                _connection.Open();
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    results.Add(new JournalByStaff()
                    {
                        Relates = dr["Клиент (тип)"].ToString(),
                        Surname = dr["Фамилия"].ToString(),
                        Name = dr["Имя"].ToString(),
                        FarthersName = dr["Отчество"].ToString(),
                        Form = dr["Форма"].ToString(),
                        Content = dr["Содержание"].ToString(),
                        Date = Convert.ToDateTime(dr["Дата"].ToString())
                    });
                }
            }
            catch (SqlException exp)
            {
                throw new Exception(exp.Message);
            }
            finally
            {
                _connection.Close();
            }
            return results;
        }
        public DataSet GetIndivJournalByStaffSet(int specID)
        {
            var da = new SqlDataAdapter();
            var ds = new DataSet();
            var command = new SqlCommand("exec [consults_by_staff] @specialistID", _connection);
            command.Parameters.Add("@specialistID", SqlDbType.Int).Value = specID;
            try
            {
                da.SelectCommand = command;
                _connection.Open();
                da.Fill(ds);
            }
            catch (SqlException exp)
            {
                throw new Exception(exp.Message);
            }
            finally
            {
                _connection.Close();
            }
            return ds;
        }

    }

}
