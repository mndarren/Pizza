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
            var success = repository.AddProvider(newProvider);

            var providerList = repository.GetAllProviders();
            var provider = providerList[providerList.Count - 1];

            Assert.IsTrue(success, "addition fail");
            Assert.IsTrue(null != provider, "returned provider does not exist");

            Assert.AreEqual(newProvider.Name, provider.Name, "names are not equal");
            Assert.AreEqual(newProvider.StreetAddress, provider.StreetAddress, "addresses are not equal");
            Assert.AreEqual(newProvider.State, provider.State, "states are not equal");
            Assert.AreEqual(newProvider.City,provider.City,"cities are not equal");
            Assert.AreEqual(newProvider.BankAccount, provider.BankAccount, "bankaccounts are not equal");

        }

        [TestMethod]
        [TestCategory("ProviderList")]
        public void GetProvider()
        {
            var repository = new ProviderList();
            var provider = repository.GetProvider(102);

            Assert.IsTrue(null != provider, "returned provider does not exist");
        }

        [TestMethod]
        [TestCategory("ProviderList")]
        public void UpdateProvider()
        {
            var repository = new ProviderList();
            var providerList = repository.GetAllProviders();
            var provider = providerList[providerList.Count - 1];
            var updatedProvider = repository.UpdateProvider("Mo", 102, "100th Ave", "city", "MM", "30093", 2341341);

            Assert.IsTrue(updatedProvider != null, "returned updated provider");

            Assert.AreEqual(updatedProvider.Name, provider.Name, "names are not equal");
            Assert.AreEqual(updatedProvider.StreetAddress, provider.StreetAddress, "addresses are not equal");
            Assert.AreEqual(updatedProvider.State, provider.State, "states are not equal");
            Assert.AreEqual(updatedProvider.City, provider.City, "cities are not equal");
            Assert.AreEqual(updatedProvider.BankAccount, provider.BankAccount, "bankaccounts are not equal");
        }

        [TestMethod]
        [TestCategory("ProviderList")]
        public void DeleteProvider()
        {
            var repository = new ProviderList();
            var providerList = repository.GetAllProviders();
            var provider = providerList[providerList.Count - 1];

            var success = repository.DeleteProvider(provider.ID);
            Assert.IsTrue(success, "delete fail");
        }
    }
}
