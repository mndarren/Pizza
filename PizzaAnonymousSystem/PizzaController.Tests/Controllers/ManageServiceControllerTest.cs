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
            DateTime timeEx = new DateTime()
            var result = report.AddServiceRecord(new ServiceRecord(123456,DateTime.Now, DateTime.Today, 10005,2009, "NoComment"));

        }
    }
}
