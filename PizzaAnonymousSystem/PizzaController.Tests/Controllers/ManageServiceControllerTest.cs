using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaController.Controllers;
using PizzaModels.Models;
using PizzaRepository.ListClass;
using PizzaModels.Constants;


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
            var serviceRecord = new ServiceRecord(123456, DateTime.Now, DateTime.Today, 10005, 2009, "NoComment");

            var result = report.AddServiceRecord(serviceRecord);
            
            Assert.IsTrue(null != result, "Failed to add a new service record.");
        }

        [TestMethod]
        [TestCategory("ManageServiceController")]
        public void TestAddService()
        {
            var report = new ManageServiceController(new MemberList(), new ProviderList(), new ProviderDirectory(), new ServiceRecordList());
            var result = report.AddService(new Service(222233, "handHealth", 150m));
            Assert.IsTrue(result!=null, "Failed to add a new service");
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
        public void TestDeleteService() 
        {
            var report = new ManageServiceController(new MemberList(), new ProviderList(), new ProviderDirectory(), new ServiceRecordList());
            var serviceCode = 222244;
            var newService = new Service(serviceCode, "Consult", 50.50m);

            var success = report.AddService(newService);
            Assert.IsTrue(success!=null, "add service failed.");

            var success1 = report.DeleteService(serviceCode);
            Assert.IsTrue(success1, "delete service failed.");
        }

        [TestMethod]
        [TestCategory("ManageServiceController")]
        public void TestGetServiceRecord()
        {
            var serviceController = new ManageServiceController(new MemberList(), new ProviderList(), new ProviderDirectory(), new ServiceRecordList());
            var accountConroller = new ManageAccountController(new AdminList(), new ManagerList(), new MemberList(), new ProviderList());

            var serviceCode = 222255;
            var newService = new Service(serviceCode, "Hypno Thrpy", 55.50m);

            var newMember = new Member()
            {
                Name = "Jonas Bros",
                StreetAddress = "21 Jump Street",
                City = "St. Paul",
                State = "MN",
                ZipCode = "12345",
                Status = MemberStatus.ACCEPTED
            };

            var newProvider = new Provider()
            {
                Name = "Mario Bros",
                StreetAddress = "22 Jump Street",
                City = "Minneapolis",
                State = "MN",
                ZipCode = "54321"
            };

            var success = serviceController.AddService(newService);
            var memberId = accountConroller.AddMember(newMember);
            var providerId = accountConroller.AddProvider(newProvider);

            Assert.IsTrue(success!=null,  "add service failed");
            Assert.IsTrue(memberId.HasValue,   "add member failed");
            Assert.IsTrue(providerId.HasValue, "add provider failed");
            
            var newServiceRecord = new ServiceRecord(serviceCode, 
                DateTime.Now, DateTime.Today, providerId.Value, memberId.Value, "all green");

            var newServiceRecordId = serviceController.AddServiceRecord(newServiceRecord);

            Assert.IsTrue(newServiceRecordId.HasValue, "add service record failed");

            var serviceRecord = serviceController.GetServiceRecord(newServiceRecordId.Value);

            Assert.AreEqual(serviceRecord.ServiceCode, newServiceRecord.ServiceCode,       "service code does not match");
            Assert.AreEqual(serviceRecord.MemberNumber, newServiceRecord.MemberNumber,     "member number does not match");
            Assert.AreEqual(serviceRecord.ProviderNumber, newServiceRecord.ProviderNumber, "provider number does not match");
            Assert.AreEqual(serviceRecord.DateProvided, newServiceRecord.DateProvided,     "date provided does not match");
            Assert.AreEqual(serviceRecord.TimeStamp, newServiceRecord.TimeStamp,           "timestamp does not match");
            Assert.AreEqual(serviceRecord.Comments, newServiceRecord.Comments,             "comments does not match");
        }
    }
}
