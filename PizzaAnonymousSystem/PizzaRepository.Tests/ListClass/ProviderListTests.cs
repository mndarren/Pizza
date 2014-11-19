using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaModels.Models;
using PizzaRepository.ListClass;

namespace PizzaRepository.Tests.ListClass
{
    [TestClass]
    public class ProviderListTests
    {
        [TestMethod]
        [TestCategory("ProviderList")]
        public void AddProvider()
        {
            var repository = new ProviderList();

            var newProvider = new Provider("Zhao Xie", "397 4th Ave S", "MN", "St. Cloud", "56301",100000023434);
            var newProviderId = repository.AddProvider(newProvider);
            var providerList = repository.GetAllProviders();

            var provider = providerList[providerList.Count - 1];

            Assert.IsTrue(null != newProviderId, "addition fail");
            Assert.IsTrue(null != provider, "returned provider does not exist");

            Assert.AreEqual(newProvider.Name, provider.Name, "names are not equal");
            Assert.AreEqual(newProvider.StreetAddress, provider.StreetAddress, "addresses are not equal");
            Assert.AreEqual(newProvider.State, provider.State, "states are not equal");
            Assert.AreEqual(newProvider.City,provider.City,"cities are not equal");
            Assert.AreEqual(newProvider.BankAccount, provider.BankAccount, "bankaccounts are not equal");

            var deleteSuccess = repository.DeleteProvider(newProviderId.Value);
            Assert.IsTrue(deleteSuccess, "delete fail");
        }

        [TestMethod]
        [TestCategory("ProviderList")]
        public void GetProvider()
        {
            Assert.Fail("not implemented yet");
        }

        [TestMethod]
        [TestCategory("ProviderList")]
        public void UpdateProvider()
        {
            Assert.Fail("not implemented yet");
        }

        [TestMethod]
        [TestCategory("ProviderList")]
        public void DeleteProvider()
        {
            Assert.Fail("not implemented yet");
        }
    }
}
