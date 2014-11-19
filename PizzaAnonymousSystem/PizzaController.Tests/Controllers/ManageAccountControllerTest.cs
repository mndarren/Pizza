using System;
using PizzaRepository.ListClass;
using PizzaController.Controllers;
using PizzaModels.Report;
using PizzaModels.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PizzaController.Tests.Controllers
{
    [TestClass]
    public class ManageAccountControllerTest
    {

        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void AddMember()
        {
            var account = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());
            Member m = new Member();
            var result = account.AddMember(m);
            Assert.IsTrue(result,"Failed to add a new member.");
        }

        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void DeleteMember()
        {
            var account = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());
            Member m = new Member();
            int memberId = 0;
            var result = account.DeleteMember(memberId);
            Assert.IsTrue(result, "Failed to delete a new member.");
        }

        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void UpdateMember()
        {
            var account = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());
            Member m = new Member();
            
            var result = account.UpdateMember(m);
            Assert.IsNull(result, "Failed to update a member.");
        }


        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void AddProvider()
        {
            var account = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());
            Provider p = new Provider();

            var result = account.AddProvider(p);
            Assert.IsNull(result, "Failed to add a provider.");
        }

        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void DeleteProvider()
        {
            var account = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());
            int providerId = 0;

            var result = account.DeleteProvider(providerId);
            Assert.IsNull(result, "Failed to delete a provider.");
        }

        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void UpdateProvider()
        {
            var account = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());
            Provider p = new Provider();

            var result = account.UpdateProvider(p);
            Assert.IsNull(result, "Failed to update a provider.");
        }

        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void AddManager()
        {
            var account = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());
            Manager m = new Manager();

            var result = account.AddManager(m);
            Assert.IsNull(result, "Failed to add a manager.");
        }

        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void DeleteManager()
        {
            var account = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());
            int managerID = 0;
            var result = account.DeleteManager(managerID);
            Assert.IsNull(result, "Failed to delete a manager.");
        }

        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void UpdateManager()
        {
            var account = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());
            Manager m = new Manager();
            var result = account.UpdateManager(m);
            Assert.IsNull(result, "Failed to delete a manager.");
        }

        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void addAdmin()
        {
            var account = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());
            Admin a = new Admin();
            var result = account.addAdmin(a);
            Assert.IsNull(result, "Failed to add an admin.");
        }

        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void DeleteAdmin()
        {
            var account = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());
            int adminID = 0;
            var result = account.DeleteAdmin(adminID);
            Assert.IsNull(result, "Failed to delete an admin.");
        }

        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void UpdateAdmin()
        {
            var account = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());
            Admin a = new Admin();
            var result = account.UpdateAdmin(a);
            Assert.IsNull(result, "Failed to delete an admin.");
        }

        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void ValidateMember()
        {
            var account = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());
            int memberId = 0;
            var result = account.ValidateMember(memberId);
            Assert.IsNull(result, "Failed to validate a member.");
        }

        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void GetMember()
        {
            var controller = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());
            int memberId = 1001;
            var member = controller.GetMember(memberId);
            Assert.IsTrue(null != member, "member not found");
        }

        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void GetProvider()
        {
            var controller = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());
            int providerId = 101;
            var provider = controller.GetProvider(providerId);
            Assert.IsTrue(null != provider, "provider not found");
        }

        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void GetManager()
        {
            var controller = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());
            int managerId = 11;
            var manager = controller.GetManager(managerId);
            Assert.IsTrue(null != manager, "manager not found");
        }

        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void GetAdmin()
        {
            var controller = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());
            int adminId = 1;
            var admin = controller.GetAdmin(adminId);
            Assert.IsTrue(null != admin, "admin not found");
        }
    }
}
