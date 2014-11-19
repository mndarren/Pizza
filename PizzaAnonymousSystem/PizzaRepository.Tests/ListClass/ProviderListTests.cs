using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using 

namespace PizzaRepository.Tests.ListClass
{
    [TestClass]
    public class ProviderListTests
    {
        [TestMethod]
        [TestCategory("ProviderList")]
        public void AddProvider()
        {
            var repository = new ProviderList();
            var testReportType = 99;

            var newSchedule = new Schedule(testReportType, 5, new TimeSpan(12, 59, 59));
            var success = repository.AddSchedule(newSchedule);
            var schedule = repository.GetSchedule(testReportType);

            Assert.IsTrue(success, "addition fail");
            Assert.IsTrue(null != schedule, "returned schedule does not exist");

            Assert.AreEqual(newSchedule.ReportType, schedule.ReportType, "report types are not equal");
            Assert.AreEqual(newSchedule.Time, schedule.Time, "times are not equal");
            Assert.AreEqual(newSchedule.Week, schedule.Week, "weeks are not equal");

            success = repository.DeleteSchedule(testReportType);
            Assert.IsTrue(success, "delete fail");
        }

        [TestMethod]
        [TestCategory("ProviderList")]
        public void GetProvider()
        {
            Assert.Fail("not implemented yet");
        }

        [TestMethod]
        [TestCategory("ProviderList")]
        public void UpdateProvider()
        {
            Assert.Fail("not implemented yet");
        }

        [TestMethod]
        [TestCategory("ProviderList")]
        public void DeleteProvider()
        {
            Assert.Fail("not implemented yet");
        }
    }
}
