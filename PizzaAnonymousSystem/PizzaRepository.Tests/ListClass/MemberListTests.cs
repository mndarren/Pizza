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

            var result = list.InsertMember(member);
            var tempmember = list.GetMember(member.ID);

            Assert.IsTrue(result,"Adding Fail");
            Assert.IsTrue(null != tempmember, "Return member does not exist");

            Assert.AreEqual(member.Name, tempmember.Name, "Name are not equal");
            Assert.AreEqual(member.StreetAddress, member.StreetAddress, "StreetAddress are not the same");
            Assert.AreEqual(member.State, tempmember.State, "State are not the same");
            Assert.AreEqual(member.City, tempmember.City, "City are not the same");
            Assert.AreEqual(member.ZipCode, tempmember.ZipCode, "ZIPCode are not the same");

            result = list.DeleteMember(member.ID);
            Assert.IsTrue(result, "Delete Fail");

        }

        [TestMethod]
        [TestCategory("MemberList")]
        public void GetMember()
        {
            var list = new MemberList();
            int memberID = 1001;
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

            result = list.InsertMember(member);

            Assert.IsTrue(result, "Adding Fail");
        }

        [TestMethod]
        [TestCategory("MemberList")]
        public void UpdateMember()
        {
            var list = new MemberList();
            var member = new Member();
            string name = "cheng";
            string streetAddress = "379 4th Ave S";
            string city = "Saint Cloud";
            string state = "MN";
            string ZIPcode = "56301";

            member.Name = name;
            member.StreetAddress = streetAddress;
            member.City = city;
            member.State = state;
            member.ZipCode = ZIPcode;

            var success = list.InsertMember(member);

            Assert.IsTrue(success, "Adding Fail");

            var result = list.UpdateMember(name, memberID, streetAddress,
                                     city,state,ZIPcode,member.Status);

            Assert.IsTrue(null!=result,"update fail");
        }
    }
}
