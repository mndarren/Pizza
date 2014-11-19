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
            var serviceRecord = new ServiceRecord();
            var result = list.InsertServiceRecord(serviceRecord);
            Assert.IsFalse(result);
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
            int memberID;
            var list = new
        }

        [TestMethod]
        [TestCategory("ServiceRecordList")]
        public void GetAllServiceRecordForProvider()
        {

        }

    }
}
