using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfService1;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void hfhg()
        {
            Console.WriteLine("Yfxfkj ntcnf");
        }

        [TestMethod]
        public void AddCompetitionTest()
        {
            var service = new Service1();
            var CompetitionCountPre = service.SelectCompetition().Count;

            Service1.Competition Competition = new Service1.Competition
            {
                Name = "TestCompetition",
                Description = "TestDesc",
                Prize = 43,
                MinValue = 2,
                ApplicationDeadline = DateTime.Today
            };
            service.AddCompetition(Competition);
            var CompetitionCountPost = service.SelectCompetition().Count;
            Assert.AreEqual(CompetitionCountPre + 1, CompetitionCountPost);
        }

        [TestMethod]
        public void AddUserTest()
        {
            var service = new Service1();
            var UsersCountPre = service.SelectUsers().Count;

            Service1.Users Users = new Service1.Users
            {
                Login = "tttt",
                Password = "tttte",
                FIO = "TestCompetition",
                Phone = "8985395839",
                Email = "asdjpas",
                Admin = false
            };
            service.AddUsers(Users);
            var UsersCountPost = service.SelectUsers().Count;
            Assert.AreEqual(UsersCountPre + 1, UsersCountPost);
        }
        [TestMethod]
        public void AddRequestTest()
        {
            var service = new Service1();
            var RequestCountPre = service.SelectRequest().Count;

            Service1.Request Request = new Service1.Request
            {
                ProjectName = "stest",
                Competition_ID = 3
            };
            service.AddRequest(Request);
            var RequestCountPost = service.SelectRequest().Count;
            Assert.AreEqual(RequestCountPre + 1, RequestCountPost);
        }
        [TestMethod]
        public void AddExpertTest()
        {
            var service = new Service1();
            var ExpertCountPre = service.SelectExperts().Count;

            Service1.Experts Expert = new Service1.Experts
            {
                FIO = "Test test test"
            };
            service.AddExpert(Expert);
            var ExpertCountPost = service.SelectExperts().Count;
            Assert.AreEqual(ExpertCountPre + 1, ExpertCountPost);
        }
        [TestMethod]
        public void DeleteExpertTest()
        {
            var service = new Service1();
            var ExpertCountPre = service.SelectExperts().Count;
            service.DeleteExpert(5);
            var ExpertCountPost = service.SelectExperts().Count;
            Assert.AreEqual(ExpertCountPre -1, ExpertCountPost);
        }
        [TestMethod]
        public void DeleteRequestTest()
        {
            var service = new Service1();
            var RequestCountPre = service.SelectRequest().Count;
            service.DeleteRequest(12);
            var RequestCountPost = service.SelectRequest().Count;
            Assert.AreEqual(RequestCountPre -1, RequestCountPost);
        }
        [TestMethod]
        public void DeleteUserTest()
        {
            var service = new Service1();
            var UserCountPre = service.SelectUsers().Count;
            service.DeleteUser(1004);
            var UserCountPost = service.SelectUsers().Count;
            Assert.AreEqual(UserCountPre - 1, UserCountPost);
        }
        [TestMethod]
        public void SelectUsersTest()
        {
            var service = new Service1();
            var UserCount = service.SelectUsers().Count;
            Assert.IsNotNull(UserCount);
        }
        [TestMethod]
        public void SelectRequestTest()
        {
            var service = new Service1();
            var RequestCount = service.SelectRequest().Count;
            Assert.IsNotNull(RequestCount);
        }
         [TestMethod]
        public void SelectExpertsTest()
        {
            var service = new Service1();
            var ExpertsCount = service.SelectExperts().Count;
            Assert.IsNotNull(ExpertsCount);
        }
        [TestMethod]
        public void FindByIDUsersTest()
         {
             var Service = new Service1();
             var User = Service.FindByIDUsers(1).FIO;
             Assert.AreEqual(User, Service.FindByIDUsers(1).FIO);

         }
        [TestMethod]
        public void AddExpertNull()
        {
            string FIO = "Test";
            var service = new Service1();
            bool expected = true; Service1.Experts Expert = new Service1.Experts
            {
                FIO = "Test test test"
            };
            service.AddExpert(Expert);
            Assert.AreEqual(expected,service.MoreThanNull );
        }
        [TestMethod]
        public void AddCompetitionNull()
        {
            string Name = "Test";
            var service = new Service1();
            bool expected = true; Service1.Competition comp = new Service1.Competition
            {
                Name = "Test"
            };
            service.AddCompetition(comp);
            Assert.AreEqual(expected, service.MoreThanNull);
        }
        [TestMethod]
        public void AddRequestNull()
        {
            string ProjectName = "Test";
            var service = new Service1();
            bool expected = true; Service1.Request req = new Service1.Request
            {
                ProjectName = "Test"
            };
            service.AddRequest(req);
            Assert.AreEqual(expected, service.MoreThanNull);
        }
    }

}
