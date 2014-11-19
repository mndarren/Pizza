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


        }

        [TestMethod]
        [TestCategory("MemberList")]
        public void GetMember()
        {
            var list = new MemberList();
            int memberID = 0;
            var result = list.GetMember(memberID);

            Assert.IsNull(result);

        }

        [TestMethod]
        [TestCategory("MemberList")]
        public void GetMembers()
        {
            var list = new MemberList();
            int memberID = 0;
            var result = list.GetMember(memberID);

            Assert.IsNull(result);

        }

        [TestMethod]
        [TestCategory("MemberList")]
        public void DeleteMember()
        {
            var list = new MemberList();
            int memberID = 1007;
            var result = list.DeleteMember(memberID);
            Assert.IsFalse(result);
        }

        [TestMethod]
        [TestCategory("MemberList")]
        public void AllMembers()
        {
            var list = new MemberList();
            var result = list.GetAllMembers();
            Assert.IsFalse((result != null));
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

            Assert.IsNull(result);
        }
        
    }
}
