using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace WcfService1
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class Service1 : IService1
    {
        readonly string connectionString = @"Data Source=DESKTOP-1A81USP\SQLEXPRESS;Initial Catalog=KonkursProektov;Integrated Security=True";

        public class Competition
        {
            public int ID_Competition;
            public string Name;
            public string Description;
            public double Prize;
            public double MinValue;
            public DateTime ApplicationDeadline;
        }
        public class Evalulation
        {
            public int Request_ID;
            public int Expert_ID;
            public string Name;
            public double EvalulationNum;
        }
        public class Experts
        {
            public int ID_Experts;
            public string FIO;
        }
        public class Request
        {
            public int ID_Request;
            public string ProjectName;
            public int Competition_ID;
        }
        public class Users
        {
            public int ID_Users;
            public string Login;
            public string Password;
            public string FIO;
            public string Phone;
            public string Email;
            public bool Admin;
        }
        public class Users_Request
        {
            public int Users_ID;
            public int Request_ID;
            public string TeamName;
        }

        public class Auth
        {
            public bool error;
            public string error_message;
            public int id_user;
            public bool admin;
        }
        public Auth Authorisation(string Login, string Password)
        {
            Auth auth = new Auth();

            if (FindByLoginUsers(Login, Password))
            {
                string sqlExpression = "Authentication";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    SqlParameter LoginParam = new SqlParameter
                    {
                        ParameterName = "@Login",
                        Value = Login
                    };
                    command.Parameters.Add(LoginParam);

                    SqlParameter PasswordParam = new SqlParameter
                    {
                        ParameterName = "@Password",
                        Value = Password
                    };
                    command.Parameters.Add(PasswordParam);

                    var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            auth.error = false;
                            auth.error_message = null;
                            auth.id_user = id;

                        }
                        return auth;
                    }
                    else
                    {
                        auth.error = true;
                        auth.error_message = "Неверное имя пользователя или пароль";
                        return auth;
                    }
                }
            }
            else
            {
                auth.error = true;
                auth.error_message = "Неверное имя пользователя или пароль";
                return auth;
            }
        }

            public bool FindByLoginUsers(string Login, string Password)
            {
                string FindByLoginUsers = "Authentication";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(FindByLoginUsers, connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    SqlParameter LoginParam = new SqlParameter
                    {
                        ParameterName = "@Login",
                        Value = Login
                    };
                    command.Parameters.Add(LoginParam);

                    SqlParameter PasswordParam = new SqlParameter
                    {
                        ParameterName = "@Password",
                        Value = Password
                    };
                    command.Parameters.Add(PasswordParam);

                    var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
        
            public void AddCompetition(Competition competition)
            {
                string sqlExpression = "AddCompetition";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    
                    connection.Open();
                    SqlCommand command1 = new SqlCommand("Select count(*) From Competition where Name=@Name", connection);
                    command1.Parameters.AddWithValue("@Name", competition.Name);
                    int Name_Exp = (int)command1.ExecuteScalar();
                    if (Name_Exp == 0)
                    {
                        MoreThanNull = false;
                        SqlCommand command = new SqlCommand(sqlExpression, connection)
                        {
                            CommandType = System.Data.CommandType.StoredProcedure
                        };

                        SqlParameter CompetitionNameParamet = new SqlParameter
                        {
                            ParameterName = "@Name",
                            Value = competition.Name
                        };
                        SqlParameter CompetitionDescParamet = new SqlParameter
                        {
                            ParameterName = "@Description",
                            Value = competition.Description
                        };
                        SqlParameter CompetitionPrizeParamet = new SqlParameter
                        {
                            ParameterName = "@Prize",
                            Value = competition.Prize
                        };
                        SqlParameter CompetitionMinValueParamet = new SqlParameter
                        {
                            ParameterName = "@MinValue",
                            Value = competition.MinValue
                        };
                        SqlParameter CompetitionApplicationDeadlineParamet = new SqlParameter
                        {
                            ParameterName = "@ApplicationDeadline",
                            Value = competition.ApplicationDeadline
                        };
                        command.Parameters.Add(CompetitionNameParamet);

                        command.Parameters.Add(CompetitionDescParamet);
                        command.Parameters.Add(CompetitionPrizeParamet);
                        command.Parameters.Add(CompetitionMinValueParamet);
                        command.Parameters.Add(CompetitionApplicationDeadlineParamet);

                        var result = command.ExecuteScalar();
                        connection.Close();
                    }
                    else
                    {
                        MoreThanNull = true;
                        connection.Close();
                    }
                }
            }

            public bool MoreThanNull = false;
            public void AddExpert(Experts Expert)
            {
                string sqlExpression = "AddExpert";
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    SqlCommand command1 = new SqlCommand("Select count(*) From Experts where FIO=@FIO", connection);
                    command1.Parameters.AddWithValue("FIO", Expert.FIO);
                    int FIO_EXP = (int)command1.ExecuteScalar();
                    if (FIO_EXP == 0)
                    {
                        MoreThanNull = false;
                        SqlCommand command = new SqlCommand(sqlExpression, connection)
                        {
                            CommandType = System.Data.CommandType.StoredProcedure
                        };

                        SqlParameter ExpertFIOParamet = new SqlParameter
                        {
                            ParameterName = "@FIO",
                            Value = Expert.FIO
                        };

                        command.Parameters.Add(ExpertFIOParamet);

                        var result = command.ExecuteScalar();

                        connection.Close();
                    }
                    else
                    {
                        MoreThanNull = true;
                        connection.Close();
                    }
                }
            }
            public void AddEvalulation(Evalulation Evalulation)
            {
                string sqlExpression = "AddEvaluation";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    SqlParameter EvalulationRequestParamet = new SqlParameter
                    {
                        ParameterName = "@Request_ID",
                        Value = Evalulation.Request_ID
                    };

                    command.Parameters.Add(EvalulationRequestParamet);
                    SqlParameter EvalulationExpertParamet = new SqlParameter
                    {
                        ParameterName = "@Expert_ID",
                        Value = Evalulation.Expert_ID
                    };

                    command.Parameters.Add(EvalulationExpertParamet);
                    SqlParameter EvalulationNameParamet = new SqlParameter
                    {
                        ParameterName = "@Name",
                        Value = Evalulation.Name
                    };

                    command.Parameters.Add(EvalulationNameParamet);
                    SqlParameter EvalulationEvalulationNumParamet = new SqlParameter
                    {
                        ParameterName = "@EvalulationNum",
                        Value = Evalulation.EvalulationNum
                    };

                    command.Parameters.Add(EvalulationEvalulationNumParamet);

                    var result = command.ExecuteScalar();
                    connection.Close();
                }
            }
            public void AddRequest(Request Request)
            {
                string sqlExpression = "AddRequest";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command1 = new SqlCommand("Select count(*) From Request where ProjectName=@ProjectName", connection);
                    command1.Parameters.AddWithValue("@ProjectName", Request.ProjectName);
                    int Req_Exp = (int)command1.ExecuteScalar();
                    if (Req_Exp == 0)
                    {
                        MoreThanNull = false;
                        SqlCommand command = new SqlCommand(sqlExpression, connection)
                        {
                            CommandType = System.Data.CommandType.StoredProcedure
                        };

                        SqlParameter RequestExpertParamet = new SqlParameter
                        {
                            ParameterName = "@ProjectName",
                            Value = Request.ProjectName
                        };
                        SqlParameter RequestNameParamet = new SqlParameter
                        {
                            ParameterName = "@Competition",
                            Value = Request.Competition_ID
                        };

                        command.Parameters.Add(RequestExpertParamet);
                        command.Parameters.Add(RequestNameParamet);

                        var result = command.ExecuteScalar();
                        connection.Close();
                    }
                    else
                    {
                        MoreThanNull = true;
                        connection.Close();
                    }
                }
            }
        public void AddUsers(Users Users)
            {
                string sqlExpression = "AddUsers";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    SqlParameter UsersLoginParamet = new SqlParameter
                    {
                        ParameterName = "@Login",
                        Value = Users.Login
                    };
                    SqlParameter UsersPasswordParamet = new SqlParameter
                    {
                        ParameterName = "@Password",
                        Value = Users.Password
                    };
                    SqlParameter UsersFIOParamet = new SqlParameter
                    {
                        ParameterName = "@FIO",
                        Value = Users.FIO
                    };
                    SqlParameter UsersPhoneParamet = new SqlParameter
                    {
                        ParameterName = "@Phone",
                        Value = Users.Phone
                    };
                    SqlParameter UsersEmailParamet = new SqlParameter
                    {
                        ParameterName = "@Email",
                        Value = Users.Email
                    };
                    SqlParameter UsersAdminParamet = new SqlParameter
                    {
                        ParameterName = "@Admin",
                        Value = Users.Admin
                    };
                    command.Parameters.Add(UsersLoginParamet);

                    command.Parameters.Add(UsersPasswordParamet);
                    command.Parameters.Add(UsersFIOParamet);
                    command.Parameters.Add(UsersPhoneParamet);
                    command.Parameters.Add(UsersEmailParamet);
                    command.Parameters.Add(UsersAdminParamet);

                    var result = command.ExecuteScalar();
                    connection.Close();
                }
            }
        public void AddUsersRequest(Users_Request Users_Request)
        {
            string sqlExpression = "AddUsersRequest";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter Users_RequestUsersParamet = new SqlParameter
                {
                    ParameterName = "@Users_ID",
                    Value = Users_Request.Users_ID
                };
                SqlParameter Users_RequestRequestParamet = new SqlParameter
                {
                    ParameterName = "@Request_ID",
                    Value = Users_Request.Request_ID
                };
                SqlParameter TeamNameParamet = new SqlParameter
                {
                    ParameterName = "@TeamName",
                    Value = Users_Request.TeamName
                };
                command.Parameters.Add(Users_RequestUsersParamet);

                command.Parameters.Add(Users_RequestRequestParamet);
                command.Parameters.Add(TeamNameParamet);

                var result = command.ExecuteScalar();
                connection.Close();
            }
        }
        public List<Competition> SelectCompetition()
        {
            using (KonkursProektovEntities db = new KonkursProektovEntities())
            {
                List<Competition> competition = db.Competition.ToList();
                return competition;
            }
        }
        public List<Evalulation> SelectEvalulation()
        {
            using (KonkursProektovEntities db = new KonkursProektovEntities())
            {
                List<Evalulation> evaluation = db.Evalulation.ToList();
                return evaluation;
            }
        }
        public List<Experts> SelectExperts()
        {
            using (KonkursProektovEntities db = new KonkursProektovEntities())
            {
                List<Experts> experts = db.Experts.ToList();
                return experts;
            }
        }
        public List<Request> SelectRequest()
        {
            using (KonkursProektovEntities db = new KonkursProektovEntities())
            {
                List<Request> request = db.Request.ToList();
                return request;
            }
        }
        public List<Users> SelectUsers()
        {
            using (KonkursProektovEntities db = new KonkursProektovEntities())
            {
                List<Users> users = db.Users.ToList();
                return users;
            }
        }
        public List<Users_Request> SelectUsersRequest()
        {
            using (KonkursProektovEntities db = new KonkursProektovEntities())
            {
                List<Users_Request> UR = db.Users_Request.ToList();
                return UR;
            }
        }
        public Users FindByIDUsers(int id)
        {
            using (KonkursProektovEntities db = new KonkursProektovEntities())
            {
                Users users = db.Users
                            .Where(o => o.ID_Users == id)
                            .FirstOrDefault();
                return users;
            }
        }
        public Request FindByIdRequest(int id)
        {
            using (KonkursProektovEntities db = new KonkursProektovEntities())
            {
                Request Request = db.Request
                            .Where(o => o.ID_Request == id)
                            .FirstOrDefault();
                return Request;
            }
        }
        public Competition FindByIdCompetition(int id)
        {
            using (KonkursProektovEntities db = new KonkursProektovEntities())
            {
                Competition competition = db.Competition
                            .Where(o => o.ID_Competition == id)
                            .FirstOrDefault();
                return competition;
            }
        }
        public Experts FindByIdExperts(int id)
        {
            using (KonkursProektovEntities db = new KonkursProektovEntities())
            {
                Experts experts = db.Experts
                            .Where(o => o.ID_Experts == id)
                            .FirstOrDefault();
                return experts;
            }
        }
        public void UpdateUsers(Users user)
        {
            string sqlExpression = "UpdateUsers";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                SqlParameter IDParam = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = user.ID_Users
                };
                command.Parameters.Add(IDParam);

                SqlParameter EmailParam = new SqlParameter
                {
                    ParameterName = "@Email",
                    Value = user.Email
                };
                command.Parameters.Add(EmailParam);

                SqlParameter PasswordParam = new SqlParameter
                {
                    ParameterName = "@Password",
                    Value = user.Password
                };
                command.Parameters.Add(PasswordParam);

                SqlParameter FirstNameParam = new SqlParameter
                {
                    ParameterName = "@FIO",
                    Value = user.FIO
                };
                command.Parameters.Add(FirstNameParam);


                SqlParameter TelephoneParam = new SqlParameter
                {
                    ParameterName = "@Phone",
                    Value = user.Phone
                };
                command.Parameters.Add(TelephoneParam);


                SqlParameter Role_IDParam = new SqlParameter
                {
                    ParameterName = "@Admin",
                    Value = user.Admin
                };
                command.Parameters.Add(Role_IDParam);
                SqlParameter Login = new SqlParameter
                {
                    ParameterName = "@Login",
                    Value = user.Login
                };
                command.Parameters.Add(Login);

                var result = command.ExecuteScalar();
                connection.Close();
            }
        }
        public void UpdateRequest(Request request)
        {
            string sqlExpression = "UpdateRequest";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                SqlParameter IDParam = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = request.ID_Request
                };
                command.Parameters.Add(IDParam);

                SqlParameter ProjectName = new SqlParameter
                {
                    ParameterName = "@ProjectName",
                    Value = request.ProjectName
                };
                command.Parameters.Add(ProjectName);

                SqlParameter Competition = new SqlParameter
                {
                    ParameterName = "@Competition",
                    Value = request.Competition_ID
                };
                command.Parameters.Add(Competition);

                var result = command.ExecuteScalar();
                connection.Close();
            }
        }
        public void UpdateExperts(Experts experts)
        {
            string sqlExpression = "UpdateExpert";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                SqlParameter IDParam = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = experts.ID_Experts
                };
                command.Parameters.Add(IDParam);

                SqlParameter FIO = new SqlParameter
                {
                    ParameterName = "@FIO",
                    Value = experts.FIO
                };
                command.Parameters.Add(FIO);

                
                var result = command.ExecuteScalar();
                connection.Close();
            }
        }
        public void UpdateEvaluation(Evalulation evaluation)
        {
            string sqlExpression = "UpdateEvalulation";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                SqlParameter IDParam = new SqlParameter
                {
                    ParameterName = "@Id1",
                    Value = evaluation.Expert_ID
                };
                command.Parameters.Add(IDParam);

                SqlParameter IDParamS = new SqlParameter
                {
                    ParameterName = "@Id2",
                    Value = evaluation.Request_ID
                };
                command.Parameters.Add(IDParamS);

                SqlParameter Name = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = evaluation.Name
                };
                command.Parameters.Add(Name);
                SqlParameter Evaluation = new SqlParameter
                {
                    ParameterName = "@Evaluation",
                    Value = evaluation.EvalulationNum
                };
                command.Parameters.Add(Evaluation);
                var result = command.ExecuteScalar();
                connection.Close();
            }
        }
        public void UpdateCompetition(Competition competition)
        {
            string sqlExpression = "UpdateCompetition";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                SqlParameter IDParam = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = competition.ID_Competition
                };
                command.Parameters.Add(IDParam);

                SqlParameter Name = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = competition.Name
                };
                command.Parameters.Add(Name);
                SqlParameter Description = new SqlParameter
                {
                    ParameterName = "@Description",
                    Value = competition.Description
                };
                command.Parameters.Add(Description);
                SqlParameter Prize = new SqlParameter
                {
                    ParameterName = "@Prize",
                    Value = competition.Prize
                };
                command.Parameters.Add(Prize);
                SqlParameter MinValue = new SqlParameter
                {
                    ParameterName = "@MinValue",
                    Value = competition.MinValue
                };
                command.Parameters.Add(MinValue);
                SqlParameter ApplicationDeadline = new SqlParameter
                {
                    ParameterName = "@ApplicationDeadline",
                    Value = competition.ApplicationDeadline
                };
                command.Parameters.Add(ApplicationDeadline);
                var result = command.ExecuteScalar();
                connection.Close();
            }
        }
        public void DeleteCompetition(int id)
        {
            string sqlExpression = "DeleteCompetition";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                SqlParameter IDParam = new SqlParameter
                {
                    ParameterName = "@ID_Competition",
                    Value = id
                };
                command.Parameters.Add(IDParam);
                var result = command.ExecuteScalar();
                connection.Close();
            }
        }
        public void DeleteEvaluation(int id_Request,int id_Expert)
        {
            string sqlExpression = "DeleteEvaluation";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                SqlParameter IDParam = new SqlParameter
                {
                    ParameterName = "@ID_Request",
                    Value = id_Request
                };
                command.Parameters.Add(IDParam);
                SqlParameter IDParamS = new SqlParameter
                {
                    ParameterName = "@ID_Expert",
                    Value = id_Expert
                };
                command.Parameters.Add(IDParamS);
                var result = command.ExecuteScalar();
                connection.Close();
            }
        }
        public void DeleteExpert(int id)
        {
            string sqlExpression = "DeleteExpert";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                SqlParameter IDParam = new SqlParameter
                {
                    ParameterName = "@Id_Expert",
                    Value = id
                };
                command.Parameters.Add(IDParam);
                var result = command.ExecuteScalar();
                connection.Close();
            }
        }
        public void DeleteRequest(int id)
        {
            string sqlExpression = "DeleteRequest";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                SqlParameter IDParam = new SqlParameter
                {
                    ParameterName = "@Id_Request",
                    Value = id
                };
                command.Parameters.Add(IDParam);
                var result = command.ExecuteScalar();
                connection.Close();
            }
        }
        public void DeleteUser(int id)
        {
            string sqlExpression = "DeleteUser";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                SqlParameter IDParam = new SqlParameter
                {
                    ParameterName = "@Id_User",
                    Value = id
                };
                command.Parameters.Add(IDParam);
                var result = command.ExecuteScalar();
                connection.Close();
            }
        }
        public void DeleteUR(int id_User,int id_Request)
        {
            string sqlExpression = "DeleteUserRequest";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                SqlParameter IDParam = new SqlParameter
                {
                    ParameterName = "@Id_User",
                    Value = id_User
                };
                command.Parameters.Add(IDParam);
               SqlParameter IDParamS = new SqlParameter
                {
                    ParameterName = "@Id_Request",
                    Value = id_Request
                };
                command.Parameters.Add(IDParamS);
                var result = command.ExecuteScalar();
                connection.Close();
            }
        }
        }

    }


