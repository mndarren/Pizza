using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaModels.Models;
using PizzaRepository.ListClass;

namespace PizzaRepository.Tests.ListClass
{
    [TestClass]
    public class ManagerListTests
    {
        [TestMethod]
        [TestCategory("ManagerList")]
        public void InsertManager()
        {
            var list = new ManagerList();

            var manager = new Manager();
            manager.Name = "manager01";
            manager.StreetAddress = "123 77th Ave S";
            manager.State = "MN";
            manager.City = "Saint Cloud";
            manager.ZipCode = "12345";

            var result = list.InsertManager(manager);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("ManagerList")]
        public void GetManager()
        {
            var list = new ManagerList();
            int managerID = 0;
            var result = list.GetManager(managerID);

            Assert.IsNull(result);

        }

        [TestMethod]
        [TestCategory("ManagerList")]
        public void DeleteManager()
        {
            var list = new ManagerList();
            int managerID = 1007;
            var result = list.DeleteManager(managerID);
            Assert.IsFalse(result);
        }

        [TestMethod]
        [TestCategory("ManagerList")]
        public void UpdateManager()
        {
            var list = new ManagerList();
            int managerID = 1, status = 0;
            string name = "manager2";
            string streetAddress = "379 4th Ave S";
            string city = "Saint Cloud";
            string state = "MN";
            string ZIPcode = "56301";

            var result = list.UpdateManager(name, managerID, streetAddress,
                                     city,state,ZIPcode);

            Assert.IsNull(result);
        }
        
    }
}
