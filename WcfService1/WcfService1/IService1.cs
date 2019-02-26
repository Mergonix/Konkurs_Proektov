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
        void  AddCompetition(WcfService1.Service1.Competition competition);
        [OperationContract]
        void AddExpert(WcfService1.Service1.Experts Expert);
        [OperationContract]
        void AddEvalulation(WcfService1.Service1.Evalulation Evalulation);
        [OperationContract]
        void AddRequest(WcfService1.Service1.Request Request);
        [OperationContract]
        void AddUsers(WcfService1.Service1.Users Users);
        [OperationContract]
        void AddUsersRequest(WcfService1.Service1.Users_Request Users_Request);
        [OperationContract]
        List<WcfService1.Service1.Competition> SelectCompetition();
        [OperationContract]
        List<WcfService1.Service1.Evalulation> SelectEvalulation();
        [OperationContract]
        List<WcfService1.Service1.Experts> SelectExperts();
        [OperationContract]
        List<WcfService1.Service1.Request> SelectRequest();
        [OperationContract]
        List<WcfService1.Service1.Users> SelectUsers();
        [OperationContract]
        List<WcfService1.Service1.Users_Request> SelectUsersRequest();
        [OperationContract]
        WcfService1.Service1.Users FindByIDUsers(int id);
        [OperationContract]
        WcfService1.Service1.Request FindByIdRequest(int id);
        [OperationContract]
        WcfService1.Service1.Competition FindByIdCompetition(int id);
        [OperationContract]
        WcfService1.Service1.Experts FindByIdExperts(int id);
        [OperationContract]
        void UpdateUsers(WcfService1.Service1.Users user);
        [OperationContract]
        void UpdateRequest(WcfService1.Service1.Request request);
        [OperationContract]
        void UpdateExperts(WcfService1.Service1.Experts experts);
        [OperationContract]
        void UpdateEvaluation(WcfService1.Service1.Evalulation evaluation);
        [OperationContract]
        void UpdateCompetition(WcfService1.Service1.Competition competition);
        [OperationContract]
        void DeleteCompetition(int id);
        [OperationContract]
        void DeleteEvaluation(int id_Request,int id_Expert);
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
