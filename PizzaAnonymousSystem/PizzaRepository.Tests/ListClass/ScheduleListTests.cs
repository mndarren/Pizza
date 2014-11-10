using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaModels.Models;
using PizzaRepository.ListClass;

namespace PizzaRepository.Tests.ListClass
{
    [TestClass]
    public class ScheduleListTests
    {
        [TestMethod]
        [TestCategory("ScheduleList")]
        public void AddSchedule()
        {
            var repository = new ScheduleList();
            var testReportType = 99;

            var newSchedule = new Schedule(testReportType, 5, new TimeSpan(12, 59, 59));
            var success = repository.AddSchedule(newSchedule);
            var schedule = repository.GetSchedule(testReportType);

            Assert.IsTrue(success         , "addition fail");
            Assert.IsTrue(null != schedule, "returned schedule does not exist");

            Assert.AreEqual(newSchedule.ReportType, schedule.ReportType, "report types are not equal");
            Assert.AreEqual(newSchedule.Time, schedule.Time            , "times are not equal");
            Assert.AreEqual(newSchedule.Week, schedule.Week            , "weeks are not equal");

            success = repository.DeleteSchedule(testReportType);
        }

        [TestMethod]
        [TestCategory("ScheduleList")]
        public void GetSchedule()
        {
            var repository = new ScheduleList();
            var testReportType = ReportType.MemberReportType;

            var schedule = repository.GetSchedule(testReportType);

            Assert.IsTrue(null != schedule, "returned schedule does not exist");
            Assert.AreEqual(schedule.ReportType, testReportType, "report types are not equal");
        }

        [TestMethod]
        [TestCategory("ScheduleList")]
        public void UpdateSchedule()
        {
            var repository = new ScheduleList();
            var testReportType = 99;

            var newSchedule = new Schedule(testReportType, 5, new TimeSpan(12, 59, 59));
            var success = repository.AddSchedule(newSchedule);

            var updatedSchedule = new Schedule(testReportType, 6, new TimeSpan(10, 59, 59));
        }

        [TestMethod]
        [TestCategory("ScheduleList")]
        public void DeleteSchedule()
        {
            Assert.Fail("not implemented yet");
        }
    }
}
