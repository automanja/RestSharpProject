using System;
using APILibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BaseTest
    {
        public UserManager manager;
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void SetUp()
        {
             manager = new UserManager();
        }
    }
}
