using System;
using APILibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System.Linq;
using APILibrary.Model;

namespace Tests
{
    [TestClass]
    public class UsersTests: BaseTest
    {
        [TestMethod]
        public void GetAllUsers()
        {
            UserSetDTO result = manager.GetAllUsers("api/users?page = 2");
            Assert.AreEqual(result.Data.Any(), true);
            Assert.AreEqual(result.Data.Count, result.Per_page);
            Assert.AreEqual(result.Data.FirstOrDefault(x => x.Id == 7).First_name, "Michael");
            Assert.AreNotEqual(result.Data.FirstOrDefault(x => x.Id == 7).First_name, "Michaellllllll");


        }

        [DeploymentItem("TestData\\TestData.csv"), DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV","TestData.csv", 
            "TestData#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void CreateUserTest()
        {
            CreateUserRequest cur = new CreateUserRequest();
            cur.Name = TestContext.DataRow["name"].ToString();
            cur.Job = TestContext.DataRow["job"].ToString();
            CreateUserDTO result = manager.CreateUser("api/users", cur);
            Assert.AreEqual(TestContext.DataRow["name"], result.Name);
            Assert.AreEqual(TestContext.DataRow["job"], result.Job);

            

        }
    }
}
