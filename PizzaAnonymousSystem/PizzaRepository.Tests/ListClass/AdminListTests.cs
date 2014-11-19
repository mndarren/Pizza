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

            var success = repository.DeleteAdmin(newAdminId.Value);

            Assert.IsTrue(success, "delete admin failed.");
        }

        [TestMethod]
        [TestCategory("AdminList")]
        public void GetAdmin()
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

            var success = repository.DeleteAdmin(newAdminId.Value);

            Assert.IsTrue(success, "delete admin failed.");
        }

        [TestMethod]
        [TestCategory("AdminList")]
        public void UpdateAdmin()
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

            newAdmin.ID = newAdminId.Value;
            newAdmin.Name = "Johnny Hendrix";
            newAdmin.StreetAddress = "13th Ave";
            newAdmin.City = "Chicago";
            newAdmin.State = "IL";
            newAdmin.ZipCode = "64421";

            admin = repository.UpdateAdmin(newAdmin.Name, newAdmin.ID, 
                newAdmin.StreetAddress, newAdmin.City, newAdmin.State, newAdmin.ZipCode);

            Assert.IsTrue(null != admin, "update admin failed.");

            Assert.AreEqual(newAdmin.Name, admin.Name,                   "name are not equal.");
            Assert.AreEqual(newAdmin.StreetAddress, admin.StreetAddress, "address are not equal.");
            Assert.AreEqual(newAdmin.City, admin.City,                   "city are not equal.");
            Assert.AreEqual(newAdmin.State, admin.State,                 "state are not equal.");
            Assert.AreEqual(newAdmin.ZipCode, admin.ZipCode,             "zip code are not equal.");

            var success = repository.DeleteAdmin(newAdminId.Value);

            Assert.IsTrue(success, "delete admin failed.");
        }

        [TestMethod]
        [TestCategory("AdminList")]
        public void DeleteAdmin()
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

            var success = repository.DeleteAdmin(newAdminId.Value);

            Assert.IsTrue(success, "delete admin failed.");
        }
    }
}
