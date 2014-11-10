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
            Assert.IsTrue(result);
        }

        //[TestMethod]
        //[TestCategory("ServiceRecordList")]
        //public void GetServiceRecord()
        //{
        //    var list = new ServiceRecordList();
        //    var result = list.GetServiceRecord();
        //    Assert.IsNotNull(result);
        //}

    }
}
