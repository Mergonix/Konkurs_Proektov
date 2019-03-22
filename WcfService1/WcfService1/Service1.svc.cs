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


        public class Auth
        {
            public bool error;
            public string error_message;
            public int id_user;
            public bool admin;
        }
        public bool CheckLoginUser(string login)
        {
            using (KonkursProektovEntities db = new KonkursProektovEntities())
            {
                Users u = db.Users
                           .Where(s => s.Login == login)
                           .FirstOrDefault();
                if (u != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public Auth Authorisation(string Login, string Password)
        {
            Auth auth = new Auth();

            if (CheckLoginUser(Login))
            {

                using (KonkursProektovEntities db = new KonkursProektovEntities())
                {
                    Users u = db.Users
                        .Where(s => s.Login == Login)
                        .Where(s => s.Password == Password)
                        .FirstOrDefault();

                    if (u != null)
                    {

                        auth.error = false;
                        auth.error_message = null;
                        auth.id_user = u.ID_Users;
                        auth.admin = Convert.ToBoolean(u.Admin);
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
        
            public Competition AddCompetition(Competition competition)
            {
                using (KonkursProektovEntities db = new KonkursProektovEntities())
                {
                        db.Competition.Add(competition);
                        db.SaveChanges();
                    
                }
                return competition;
            }

            public bool MoreThanNull = false;
            public Experts AddExpert(Experts Expert)
            {
                using (KonkursProektovEntities db = new KonkursProektovEntities())
                {
                    db.Experts.Add(Expert);
                    db.SaveChanges();

                }
                return Expert;
            }
            public Evalulation AddEvalulation(Evalulation Evalulation)
            {
                using (KonkursProektovEntities db = new KonkursProektovEntities())
                {
                    db.Evalulation.Add(Evalulation);
                    db.SaveChanges();

                }
                return Evalulation;
            }
            public Request AddRequest(Request Request)
            {
                using (KonkursProektovEntities db = new KonkursProektovEntities())
                {
                    db.Request.Add(Request);
                    db.SaveChanges();

                }
                return Request;
            }
        public Users AddUsers(Users Users)
            {
                using (KonkursProektovEntities db = new KonkursProektovEntities())
                {
                    db.Users.Add(Users);
                    db.SaveChanges();

                }
                return Users;
            }
        public Users_Request AddUsersRequest(Users_Request Users_Request)
        {
            using (KonkursProektovEntities db = new KonkursProektovEntities())
            {
                db.Users_Request.Add(Users_Request);
                db.SaveChanges();

            }
            return Users_Request;
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
            using (KonkursProektovEntities db = new KonkursProektovEntities())
            {
                Users us = db.Users
                    .Where(o => o.ID_Users == user.ID_Users)
                    .FirstOrDefault();
                us.FIO = user.FIO;
                us.Login = user.Login;
                us.Password = user.Password;
                us.Phone = user.Phone;
                us.Email = user.Email;

                db.SaveChanges();
            }
        }
        public void UpdateRequest(Request request)
        {
            using (KonkursProektovEntities db = new KonkursProektovEntities())
            {
                Request req = db.Request
                    .Where(o => o.ID_Request == request.ID_Request)
                    .FirstOrDefault();
                req.ProjectName = request.ProjectName;
                req.Competition_ID = request.Competition_ID;

                db.SaveChanges();
            }
        }
        public void UpdateExperts(Experts experts)
        {
            using (KonkursProektovEntities db = new KonkursProektovEntities())
            {
                Experts ex = db.Experts
                    .Where(o => o.ID_Experts == experts.ID_Experts)
                    .FirstOrDefault();
                ex.FIO = experts.FIO;

                db.SaveChanges();
            }
        }
        public void UpdateEvaluation(Evalulation evaluation)
        {
            using (KonkursProektovEntities db = new KonkursProektovEntities())
            {
                Evalulation ev = db.Evalulation
                    .Where(o => o.Expert_ID == evaluation.Expert_ID && o.Request_ID == evaluation.Request_ID)
                    .FirstOrDefault();
                ev.Name = evaluation.Name;
                ev.EvalulationNum = evaluation.EvalulationNum;

                db.SaveChanges();
            }
        }
        public void UpdateCompetition(Competition competition)
        {
            using (KonkursProektovEntities db = new KonkursProektovEntities())
            {
               Competition comp = db.Competition
                    .Where(o => o.ID_Competition == competition.ID_Competition)
                    .FirstOrDefault();
               comp.Name = competition.Name;
               comp.Description = competition.Description;
               comp.MinValue = competition.MinValue;
               comp.Prize = competition.Prize;
               comp.ApplicationDeadline = competition.ApplicationDeadline;

                db.SaveChanges();
            }
        }
        public void DeleteCompetition(int id)
        {
            using (KonkursProektovEntities db = new KonkursProektovEntities())
            {
                Competition comp = db.Competition
                            .Where(o => o.ID_Competition == id)
                            .FirstOrDefault();
                db.Competition.Remove(comp);
                db.SaveChanges();
            }
        }
        public void DeleteEvaluation(int id_Request,int id_Expert)
        {
            using (KonkursProektovEntities db = new KonkursProektovEntities())
            {
                Evalulation ev = db.Evalulation
                            .Where(o => o.Expert_ID == id_Expert && o.Request_ID==id_Request)
                            .FirstOrDefault();
                db.Evalulation.Remove(ev);
                db.SaveChanges();
            }
        }
        public void DeleteExpert(int id)
        {
            using (KonkursProektovEntities db = new KonkursProektovEntities())
            {
                Experts Ex = db.Experts
                            .Where(o => o.ID_Experts == id)
                            .FirstOrDefault();
                db.Experts.Remove(Ex);
                db.SaveChanges();
            }
        }
        public void DeleteRequest(int id)
        {
            using (KonkursProektovEntities db = new KonkursProektovEntities())
            {
                Request req = db.Request
                            .Where(o => o.ID_Request == id)
                            .FirstOrDefault();
                db.Request.Remove(req);
                db.SaveChanges();
            }
        }
        public void DeleteUser(int id)
        {
            using (KonkursProektovEntities db = new KonkursProektovEntities())
            {
                Users us = db.Users
                            .Where(o => o.ID_Users == id)
                            .FirstOrDefault();
                db.Users.Remove(us);
                db.SaveChanges();
            }
        }
        public void DeleteUR(int id_User,int id_Request)
        {
            using (KonkursProektovEntities db = new KonkursProektovEntities())
            {
                Users_Request ur = db.Users_Request
                            .Where(o => o.Users_ID == id_User && o.Request_ID==id_Request)
                            .FirstOrDefault();
                db.Users_Request.Remove(ur);
                db.SaveChanges();
            }
        }
        }

    }


