using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaRepository.ListClass;
using PizzaModels.Models;

namespace PizzaRepository.Tests.ListClass
{
    [TestClass]
    public class AdminListTests
    {
        [TestMethod]
        [TestCategory("AdminList")]
        public void AddAdmin()
        {
            var repository = new AdminList();

            var newAdmin = new Admin() 
            {
                Name = "Jimi Hendrix",
                StreetAddress = "12th Ave",
                City = "Minneapolis",
                State = "MN",
                ZipCode = "12446"
            };
            var newAdminId = repository.AddAdmin(newAdmin);

            Assert.IsTrue(null != newAdminId, "addition fail");

            var admin = repository.GetAdmin(newAdminId.Value);

            Assert.IsTrue(null != admin, "get new admin failed.");

            Assert.AreEqual(newAdmin.Name, admin.Name,                   "name are not equal.");
            Assert.AreEqual(newAdmin.StreetAddress, admin.StreetAddress, "address are not equal.");
            Assert.AreEqual(newAdmin.City, admin.City,                   "city are not equal.");
            Assert.AreEqual(newAdmin.State, admin.State,                 "state are not equal.");
            Assert.AreEqual(newAdmin.ZipCode, admin.ZipCode,             "zip code are not equal.");
        }

        [TestMethod]
        [TestCategory("AdminList")]
        public void GetAdmin()
        {
            var repository = new AdminList();
            var adminId = 1;

            var admin = repository.GetAdmin(adminId);

            Assert.IsTrue(null != admin, "get admin failed");

            Assert.AreEqual(admin.ID, adminId, "id are not equal");
        }

        [TestMethod]
        [TestCategory("AdminList")]
        public void UpdateAdmin()
        {
            Assert.Fail("not implemented yet");
        }

        [TestMethod]
        [TestCategory("AdminList")]
        public void DeleteAdmin()
        {
            Assert.Fail("not implemented yet");
        }
    }
}
