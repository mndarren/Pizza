using System;
using System.Linq;
using PizzaRepository.ListClass;
using PizzaController.Controllers;
using PizzaModels.Report;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaModels.Models;
using PizzaModels.Constants;

namespace PizzaController.Tests.Controllers
{
    [TestClass]
    public class ManageReportControllerTest
    {

        [TestMethod]
        [TestCategory("ManageReportController")]
        public void TestOneMemberReport()
        {
            var report = new ManageReportController(new MemberList(), new ProviderList(), new ProviderDirectory(), new ScheduleList(), new ServiceRecordList());
            int memberID = 1016;
            int result = report.GetWeeklyOneMemberReport(memberID);
            Assert.IsTrue((result == 0), "Successfully generate one member report.");
            Assert.IsTrue((result == 1), "fail to generate one member report because a member is null.");
            Assert.IsTrue((result == 2), "fail to generate one member report because a service list is null.");
        }

        [TestMethod]
        [TestCategory("ManageReportController")]
        public void TestMemberReport()
        {
            var report = new ManageReportController(new MemberList(), new ProviderList(), new ProviderDirectory(), new ScheduleList(), new ServiceRecordList());
            int result = report.GetWeeklyMemberReports();
            Assert.IsTrue((result == 0), "Successfully generate all members report.");
            Assert.IsTrue((result == 1), "fail to generate members report because members is null.");
            Assert.IsTrue((result == 2), "fail to generate members report because service list is null.");
        }

        //sync
        [TestMethod]
        [TestCategory("ManageReportController")]
        public void TestProviderReport()
        {
            var report = new ManageReportController(new MemberList(), new ProviderList(), new ProviderDirectory(), new ScheduleList(), new ServiceRecordList());
            int result = report.GetWeeklyProviderReports();
            Assert.IsTrue((result == 0), "Successfully generate all providers report.");
            Assert.IsTrue((result == 1), "fail to generate providers report because providers is null.");
            Assert.IsTrue((result == 2), "fail to generate providers report because service list is null.");
        }


        [TestMethod]
        [TestCategory("ManageReportController")]
        public void TestEFTReport()
        {
            var report = new ManageReportController(new MemberList(), new ProviderList(), new ProviderDirectory(), new ScheduleList(), new ServiceRecordList());
            int result = report.GetWeeklyEFTReports();
            Assert.IsTrue((result == 0), "Successfully generate the EFT report.");
            Assert.IsTrue((result == 1), "fail to generate providers report because providers is null.");
            Assert.IsTrue((result == 2), "fail to generate providers report because service list is null.");
            Assert.IsTrue((result == 3), "fail to generate EFT report because service is null.");

        }

        [TestMethod]
        [TestCategory("ManageReportController")]
        public void TestUpdateMemberReportSchedule()
        {
            var report = new ManageReportController(new MemberList(), new ProviderList(), new ProviderDirectory(), new ScheduleList(), new ServiceRecordList());
            TimeSpan ts = new TimeSpan(2, 14, 0);
            report.UpdateMemberReportSchedule(2,ts);
        }


        [TestMethod]
        [TestCategory("ManageReportController")]
        public void TestUpdateProviderReportSchedule()
        {
            var report = new ManageReportController(new MemberList(), new ProviderList(), new ProviderDirectory(), new ScheduleList(), new ServiceRecordList());
            TimeSpan ts = new TimeSpan(2, 14, 0);
            report.UpdateProviderReportSchedule(2, ts);
        }

        [TestMethod]
        [TestCategory("ManageReportController")]
        public void TestUpdateEFTReportSchedule()
        {
            var report = new ManageReportController(new MemberList(), new ProviderList(), new ProviderDirectory(), new ScheduleList(), new ServiceRecordList());
            TimeSpan ts = new TimeSpan(2, 14, 0);
            report.UpdateEFTReportSchedule(2, ts);
        }

        [TestMethod]
        [TestCategory("ManageReportController")]
        public void TestVerifyProviderReportServices()
        {
            var accountController = new ManageAccountController(new AdminList(), 
                new ManagerList(), new MemberList(), new ProviderList());
            var serviceController = new ManageServiceController(new MemberList(), new ProviderList(), 
                new ProviderDirectory(), new ServiceRecordList());
            var reportController = new ManageReportController(new MemberList(), new ProviderList(), 
                new ProviderDirectory(), new ScheduleList(), new ServiceRecordList());

            var newMember = new Member()
            {
                Name = "John Deere",
                City = "Maple Grove",
                State = "MN",
                StreetAddress = "11 st 25",
                ZipCode = "12345",
                Status = MemberStatus.ACCEPTED
            };

            var newProvider = new Provider()
            {
                Name = "John Deere",
                City = "Maple Grove",
                State = "MN",
                StreetAddress = "11 st 25",
                ZipCode = "12345",
                BankAccount = 1234567890
            };
            
            var newMemberId = accountController.AddMember(newMember);
            var newProviderId = accountController.AddProvider(newProvider);

            Assert.IsTrue(newMemberId.HasValue,   "unable to add new member");
            Assert.IsTrue(newProviderId.HasValue, "unable to add new provider");

            var services = serviceController.GetAllServices();
            var serviceCode = null != services && services.Any() ? services.First().ServiceCode : new int?();

            Assert.IsTrue(serviceCode.HasValue, "unable to get service code");

            var newServiceRecord = new ServiceRecord(serviceCode.Value, 
                DateTime.Now, DateTime.Today, newProviderId.Value, newMemberId.Value, "test");

            var newServiceRecordId = serviceController.AddServiceRecord(newServiceRecord);

            Assert.IsTrue(newServiceRecordId.HasValue, "unable to add service record");

            var serviceVerified = true;
            var success = reportController.VerifyProviderReportServices(newProviderId.Value, DateTime.Today.AddDays(-2), DateTime.Today.AddDays(1));

            var serviceRecord = serviceController.GetServiceRecord(newServiceRecordId.Value);

            Assert.IsTrue(null != serviceRecord, "unable to get service record");

            Assert.AreEqual(serviceRecord.ServiceVerified, serviceVerified, "service verified are not equal");
        }

        [TestMethod]
        [TestCategory("ManageReportController")]
        public void TestVerifyProviderReportFees()
        {
            var accountController = new ManageAccountController(new AdminList(),
                new ManagerList(), new MemberList(), new ProviderList());
            var serviceController = new ManageServiceController(new MemberList(), new ProviderList(),
                new ProviderDirectory(), new ServiceRecordList());
            var reportController = new ManageReportController(new MemberList(), new ProviderList(),
                new ProviderDirectory(), new ScheduleList(), new ServiceRecordList());

            var newMember = new Member()
            {
                Name = "John Deere",
                City = "Maple Grove",
                State = "MN",
                StreetAddress = "11 st 25",
                ZipCode = "12345",
                Status = MemberStatus.ACCEPTED
            };

            var newProvider = new Provider()
            {
                Name = "John Deere",
                City = "Maple Grove",
                State = "MN",
                StreetAddress = "11 st 25",
                ZipCode = "12345",
                BankAccount = 1234567890
            };

            var newMemberId = accountController.AddMember(newMember);
            var newProviderId = accountController.AddProvider(newProvider);

            Assert.IsTrue(newMemberId.HasValue, "unable to add new member");
            Assert.IsTrue(newProviderId.HasValue, "unable to add new provider");

            var services = serviceController.GetAllServices();
            var serviceCode = null != services && services.Any() ? services.First().ServiceCode : new int?();

            Assert.IsTrue(serviceCode.HasValue, "unable to get service code");

            var newServiceRecord = new ServiceRecord(serviceCode.Value,
                DateTime.Now, DateTime.Today, newProviderId.Value, newMemberId.Value, "test");

            var newServiceRecordId = serviceController.AddServiceRecord(newServiceRecord);

            Assert.IsTrue(newServiceRecordId.HasValue, "unable to add service record");

            var feeVerified = true;
            var success = reportController.VerifyProviderReportFees(newProviderId.Value, DateTime.Today.AddDays(-2), DateTime.Today.AddDays(1));

            var serviceRecord = serviceController.GetServiceRecord(newServiceRecordId.Value);

            Assert.IsTrue(null != serviceRecord, "unable to get service record");

            Assert.AreEqual(serviceRecord.FeeVerified, feeVerified, "service verified are not equal");
        }
    }
}
