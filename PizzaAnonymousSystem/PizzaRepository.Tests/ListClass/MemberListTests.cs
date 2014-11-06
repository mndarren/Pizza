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
        public void InsertMember()
        {
            var list = new MemberList();

            var member = new Member();
            var result = list.InsertMember(member);

            Assert.IsTrue(result);


        }
    }
}
