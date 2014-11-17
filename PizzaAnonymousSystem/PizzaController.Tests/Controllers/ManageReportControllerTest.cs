using System;
using PizzaRepository.ListClassFake;
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
            var report = new ManageReportController(new MemberListFake(), new ProviderListFake(), new ProviderDirectoryFake(), new ScheduleListFake(), new ServiceRecordListFake());
            var result = report.GetWeeklyMemberReports();
            Assert.IsFalse(null != result);
        }
    }
}
