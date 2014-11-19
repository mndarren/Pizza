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
            var repository = new ProviderList();
            var newProvider = new Provider("Zhao Xie", "397 4th Ave S", "MN", "St. Cloud", "56301", 100000023434);
            var newProviderId = repository.AddProvider(newProvider);
            var provider = repository.GetProvider(newProviderId.Value);

            Assert.IsTrue(null != provider, "returned provider does not exist");
        }

        [TestMethod]
        [TestCategory("ProviderList")]
        public void UpdateProvider()
        {
            var repository = new ProviderList();
            var newProvider = new Provider("Zhao Xie", "397 4th Ave S", "MN", "St. Cloud", "56301", 100000023434);
            var newProviderId = repository.AddProvider(newProvider);
            var updatedProvider = repository.UpdateProvider("Mo", newProviderId.Value, "100th Ave", "city", "MM", "30093", 2341341);

            Assert.IsTrue(updatedProvider != null, "returned updated provider");

            Assert.AreEqual(updatedProvider.Name, "Mo", "names are not equal");
            Assert.AreEqual(updatedProvider.StreetAddress, "100th Ave", "addresses are not equal");
            Assert.AreEqual(updatedProvider.State, "MM", "states are not equal");
            Assert.AreEqual(updatedProvider.City, "city", "cities are not equal");
            Assert.AreEqual(updatedProvider.ZipCode, "30093", "cities are not equal");
            Assert.AreEqual(updatedProvider.BankAccount, 2341341, "bankaccounts are not equal");
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
