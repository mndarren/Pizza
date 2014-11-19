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
        public void TestMemberReport()
        {
            var report = new ManageReportController(new MemberList(), new ProviderList(), new ProviderDirectory(), new ScheduleList(), new ServiceRecordList());
            report.GetWeeklyMemberReports();
        }

        //sync
        [TestMethod]
        [TestCategory("ManageReportController")]
        public void TestProviderReport()
        {
            var report = new ManageReportController(new MemberList(), new ProviderList(), new ProviderDirectory(), new ScheduleList(), new ServiceRecordList());
            report.GetWeeklyProviderReports();
        }


        [TestMethod]
        [TestCategory("ManageReportController")]
        public void TestEFTReport()
        {
            var report = new ManageReportController(new MemberList(), new ProviderList(), new ProviderDirectory(), new ScheduleList(), new ServiceRecordList());
            report.GetWeeklyEFTReports();
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
