using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaModels.Models;
using PizzaRepository.ListClass;

namespace PizzaRepository.Tests.ListClass
{
    [TestClass]
    public class ServiceRecordListTests
    {
        [TestMethod]
        [TestCategory ("ServiceRecordList")]
        public void InsertServiceRecord()
        {
            var list = new ServiceRecordList();
            var serviceRecord = new ServiceRecord(1231,DateTime.Now, DateTime.Today,);

            var newServiceRecordId = list.InsertServiceRecord(serviceRecord);
            Assert.IsTrue(null != newServiceRecordId, "insert service record failed.");
        }

        [TestMethod]
        [TestCategory("ServiceRecordList")]
        public void GetServiceRecord()
        {
            var list = new ServiceRecordList();
            int ID = 1;
            var result = list.GetServiceRecord(ID);
            Assert.IsNull(result);
        }

        [TestMethod]
        [TestCategory ("ServiceRecordList")]
        public void GetAllServiceRecordForMember()
        {
        }

        [TestMethod]
        [TestCategory("ServiceRecordList")]
        public void GetAllServiceRecordForProvider()
        {

        }

    }
}
