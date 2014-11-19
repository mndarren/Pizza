using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaModels.Models;
using PizzaRepository.ListClass;

namespace PizzaRepository.Tests.ListClass
{
    [TestClass]
    public class MemberListTests
    {
        [TestMethod]
        [TestCategory("MemberList")]
        public void InsertMember()
        {
            var list = new MemberList();
            var member = new Member();
            member.Name = "Cheng luo";
            member.StreetAddress = "123 77th Ave S";
            member.State = "MN";
            member.City = "Saint Cloud";
            member.ZipCode = "12345";

            var newMemberId = list.InsertMember(member);
            var tempmember = list.GetMember(member.ID);

            Assert.IsTrue(null != newMemberId,"Adding Fail");
            Assert.IsTrue(null != tempmember, "Return member does not exist");

            Assert.AreEqual(member.Name, tempmember.Name, "Name are not equal");
            Assert.AreEqual(member.StreetAddress, member.StreetAddress, "StreetAddress are not the same");
            Assert.AreEqual(member.State, tempmember.State, "State are not the same");
            Assert.AreEqual(member.City, tempmember.City, "City are not the same");
            Assert.AreEqual(member.ZipCode, tempmember.ZipCode, "ZIPCode are not the same");

            var deleteSuccess = list.DeleteMember(newMemberId.Value);
            Assert.IsTrue(deleteSuccess, "Delete Fail");

        }

        [TestMethod]
        [TestCategory("MemberList")]
        public void GetMember()
        {
            var list = new MemberList();
            int memberID = 1000;
            var result = list.GetMember(memberID);

            Assert.IsTrue(null != result, "Returned member does not exist");

        }

        [TestMethod]
        [TestCategory("MemberList")]
        public void GetAllMembers()
        {
            var list = new MemberList();
            
            var result = list.GetAllMembers();

            Assert.IsTrue(null != result,"return list not exist");

        }

        [TestMethod]
        [TestCategory("MemberList")]
        public void DeleteMember()
        {
            var list = new MemberList();
            int memberID = 1000;
            var member = list.GetMember(memberID);
            var result = list.DeleteMember(memberID);

            Assert.IsTrue(result,"Delete Fail");

            var newMemberId = list.InsertMember(member);

            Assert.IsTrue(null != newMemberId, "Adding Fail");
        }

        [TestMethod]
        [TestCategory("MemberList")]
        public void UpdateMember()
        {
            var list = new MemberList();
            int memberID = 1, status = 0;
            string name = "cheng";
            string streetAddress = "379 4th Ave S";
            string city = "Saint Cloud";
            string state = "MN";
            string ZIPcode = "56301";

            var result = list.UpdateMember(name, memberID, streetAddress,
                                     city,state,ZIPcode,status);

            Assert.IsTrue(null!=result,"update fail");
        }
    }
}
