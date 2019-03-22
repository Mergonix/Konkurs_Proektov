using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        WcfService1.Service1.Auth Authorisation(string Login, string Password);
        [OperationContract]
        Competition AddCompetition(Competition competition);
        [OperationContract]
        Experts AddExpert(Experts Expert);
        [OperationContract]
        Evalulation AddEvalulation(Evalulation Evalulation);
        [OperationContract]
        Request AddRequest(Request Request);
        //[OperationContract]
        //void AddUsers(WcfService1.Service1.Users Users);
        [OperationContract]
        Users_Request AddUsersRequest(Users_Request Users_Request);
        [OperationContract]
        List<Competition> SelectCompetition();
        [OperationContract]
        List<Evalulation> SelectEvalulation();
        [OperationContract]
        List<Experts> SelectExperts();
        [OperationContract]
        List<Request> SelectRequest();
        [OperationContract]
        List<Users> SelectUsers();
        [OperationContract]
        List<Users_Request> SelectUsersRequest();
        //[OperationContract]
        //WcfService1.Service1.Users FindByIDUsers(int id);
        [OperationContract]
        Request FindByIdRequest(int id);
        [OperationContract]
        Competition FindByIdCompetition(int id);
        [OperationContract]
        Experts FindByIdExperts(int id);
        //[OperationContract]
        //void UpdateUsers(WcfService1.Service1.Users user);
        [OperationContract]
        void UpdateRequest(Request request);
        [OperationContract]
        void UpdateExperts(Experts experts);
        [OperationContract]
        void UpdateEvaluation(Evalulation evaluation);
        [OperationContract]
        void UpdateCompetition(Competition competition);
        [OperationContract]
        void DeleteCompetition(int id);
        [OperationContract]
        void DeleteEvaluation(int id_Request, int id_Expert);
        [OperationContract]
        void DeleteExpert(int id);
        [OperationContract]
        void DeleteRequest(int id);
        [OperationContract]
        void DeleteUser(int id);
        [OperationContract]
        void DeleteUR(int id_User, int id_Request);
        // TODO: Добавьте здесь операции служб
    }


    // Используйте контракт данных, как показано в примере ниже, чтобы добавить составные типы к операциям служб.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
