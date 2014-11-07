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
            var result = list.InsertMember(member);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("MemberList")]
        public void GetMember()
        {
            var list = new MemberList();
            var result = list.GetMembers();

            Assert.IsNotNull(result);

        }

        [TestMethod]
        [TestCategory("MemberList")]
        public void DeleteMember()
        {
            var list = new MemberList();
            int memberID = 1;
            var result = list.DeleteMember(memberID);
            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("MemberList")]
        public void UpdateMember()
        {
            var list = new MemberList();
            int memberID = 1, status = 0;
            var result = list.UpdateMember(memberID, status);

            Assert.IsTrue(result);
        }
        
    }
}
