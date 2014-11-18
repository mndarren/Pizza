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
            member.StreetAddress = "397 4th Ave S";
            member.State = "MN";
            member.City = "Saint Cloud";
            member.ZipCode = "56301";

            var result = list.InsertMember(member);

            Assert.IsTrue(result);
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
        public void DeleteMember()
        {
            var list = new MemberList();
            int memberID = 1;
            var result = list.DeleteMember(memberID);
            Assert.IsFalse(result);
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
