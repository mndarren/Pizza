using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaModels.Models;
using PizzaRepository.ListClass;
using PizzaController.Controllers;

namespace PizzaController.Tests.Controllers
{
    [TestClass]
    public class ManageAccountControllerTest
    {
        [TestMethod]
        [TestCategory("ManageAccountController")]
        public void AddMember()
        {   
            var adminList = new AdminList();
            var memberList = new MemberList();
            var providerList = new ProviderList();
            var managerList = new ManagerList();
            var member = new Member();

            var controller = new ManageAccountController(adminList,managerList,memberList,providerList);
            var result = controller.AddMember(member);

            Assert.IsTrue(result);

        }

    }
}
