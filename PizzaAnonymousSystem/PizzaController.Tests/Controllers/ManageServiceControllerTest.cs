using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaController.Controllers;
using PizzaModels.Models;
using PizzaRepository.ListClass;


namespace PizzaController.Tests.Controllers
{
    [TestClass]
    public class ManageServiceControllerTest
    {
        [TestMethod]
        [TestCategory("ManageServiceController")]
        public void TestAddServiceRecord()
        {
            var report = new ManageServiceController(new MemberList(),new ProviderList(),new ProviderDirectory(), new ServiceRecordList());
            var result = report.AddServiceRecord(new ServiceRecord(123456,DateTime.Now, DateTime.Today, 10005,2009, "NoComment"));
            Assert.IsTrue(result, "Failed to add a new service record.");
        }
        [TestMethod]
        [TestCategory("ManageServiceController")]
        public void TestAddService()
        {
            var report = new ManageServiceController(new MemberList(), new ProviderList(), new ProviderDirectory(), new ServiceRecordList());
            var result = report.AddService(new Service(222233, "handHealth", 150m));
            Assert.IsTrue(result, "Failed to add a new service");
        }
        [TestMethod]
        [TestCategory("ManageServiceController")]
        public void TestUpdateService()
        {
            var report = new ManageServiceController(new MemberList(), new ProviderList(), new ProviderDirectory(), new ServiceRecordList());
            var newService = new Service(222233,"Wash hair",45m);
            var updatedService = report.UpdateService(newService);
            Assert.IsTrue(updatedService != null, "Failed to update a service");
        }
        [TestMethod]
        [TestCategory("ManageServiceController")]
        public void TestUpdateService() 
        {
           
        }
    }
}
