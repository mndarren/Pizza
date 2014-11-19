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
            var serviceRecord = new ServiceRecord(1231,DateTime.Now, DateTime.Today,100,1001,"Hello, This is a Test!");

            var newServiceRecordId = list.InsertServiceRecord(serviceRecord);
            
            Assert.IsTrue(null != newServiceRecordId, "Insert Fail");

            Assert.IsTrue(null != newServiceRecordId, "insert service record failed.");

        }

        [TestMethod]
        [TestCategory("ServiceRecordList")]
        public void GetServiceRecord()
        {
            var list = new ServiceRecordList();
            var serviceRecord = new ServiceRecord(1231, DateTime.Now, DateTime.Today, 100, 1001, "Hello, This is a Test!");
            var newServiceRecordId = list.InsertServiceRecord(serviceRecord);

            Assert.IsTrue(null != newServiceRecordId, "Adding Fail");

            var result = list.GetServiceRecord(newServiceRecordId.Value);

            Assert.IsTrue(null != result,"Get Record Fail");
        }

        [TestMethod]
        [TestCategory ("ServiceRecordList")]
        public void GetAllServiceRecordForMember()
        {
            var memberlist = new MemberList();
            var member = new Member();
            member.Name = "Zhao";
            member.StreetAddress = "123 77th Ave S";
            member.State = "MN";
            member.City = "Saint Cloud";
            member.ZipCode = "12345";

            var newMemberId = memberlist.InsertMember(member);
            Assert.IsTrue(null != newMemberId, "Adding member Fail!");

            var list = new ServiceRecordList();
            var serviceRecord = new ServiceRecord(1231, DateTime.Now, DateTime.Today, 100, newMemberId.Value, "Hello, This is a Test!");
            var serviceRecord2 = new ServiceRecord(1231, DateTime.Now, DateTime.Today, 100, newMemberId.Value, "Hello, This is a Test!");
            Assert.IsTrue(null != serviceRecord, "Adding Fail!");
            Assert.IsTrue(null != serviceRecord2, "Adding Fail!");

            var result = list.GetAllServiceRecordForMember(newMemberId.Value);

            Assert.IsTrue(null != result, "Get list Fail!");
        }

        [TestMethod]
        [TestCategory("ServiceRecordList")]
        public void GetAllServiceRecordForProvider()
        {
            var providerList = new ProviderList();
            var provider = new Provider();
            provider.Name = "Zhao";
            provider.StreetAddress = "123 77th Ave S";
            provider.State = "MN";
            provider.City = "Saint Cloud";
            provider.ZipCode = "12345";

            var newId = providerList.AddProvider(provider);
            Assert.IsTrue(null != newId, "Adding member Fail!");

            var list = new ServiceRecordList();
            var serviceRecord = new ServiceRecord(1231, DateTime.Now, DateTime.Today, newId.Value, 1001, "Hello, This is a Test!");
            var serviceRecord2 = new ServiceRecord(1231, DateTime.Now, DateTime.Today, newId.Value, 1001, "Hello, This is a Test!");
            Assert.IsTrue(null != serviceRecord, "Adding Fail!");
            Assert.IsTrue(null != serviceRecord2, "Adding Fail!");

            var result = list.GetAllServiceRecordForProvider(newId.Value);

            Assert.IsTrue(null != result, "Get list Fail!");
        }

        [TestMethod]
        [TestCategory("ServiceRecordList")]
        public void VerifyServiceRecords()
        {
            Assert.Fail("not implemented yet");
        }

    }
}
