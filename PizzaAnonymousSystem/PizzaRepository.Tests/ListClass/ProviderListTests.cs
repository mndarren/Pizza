using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaModels.Models;
using PizzaRepository.ListClass;

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

            var newProvider = new Provider("Zhao Xie", "397 4th Ave S", "MN", "St. Cloud", "56301",100000023434);
            var success = repository.AddProvider(newProvider);
            var schedule = repository.GetProvider(testReportType);

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
