using System;
using PizzaRepository.ListClass;
using PizzaController.Controllers;
using PizzaModels.Report;

using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
