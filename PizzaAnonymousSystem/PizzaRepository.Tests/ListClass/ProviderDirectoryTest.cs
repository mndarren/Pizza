using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaModels.Models;
using PizzaRepository.ListClass;

namespace PizzaRepository.Tests.ListClass
{
    [TestClass]
    public class ProviderDirectoryTest
    {
        [TestMethod]
        [TestCategory("ProviderDirectory")]
        public void AddService()
        {
            var repository = new ProviderDirectory();

            var newService = new Service(888777,"WashFeet",100m);
            var success = repository.AddService(newService);

            var serviceList = repository.GetServices();
            var service = serviceList[serviceList.Count - 1];

            Assert.IsTrue(success, "addition fail");
            Assert.IsTrue(null != service, "returned service does not exist");

            Assert.AreEqual(newService.ServiceCode, service.ServiceCode, "service codes are not equal");
            Assert.AreEqual(newService.ServiceName, service.ServiceName, "service names are not equal");
            Assert.AreEqual(newService.ServiceFee, service.ServiceFee, "service fees are not equal");
        }

        [TestMethod]
        [TestCategory("ProviderDirectory")]
        public void GetService()
        {
            var repository = new ProviderDirectory();
            var service = repository.GetService(100004);

            Assert.IsTrue(null != service, "returned service does not exist");
        }
        [TestMethod]
        [TestCategory("ProviderDirectory")]
        public void GetServices()
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
        [TestCategory("ProviderDirectory")]
        public void UpdateService()
        {
            Assert.Fail("not implemented yet");
        }

        [TestMethod]
        [TestCategory("ProviderDirectory")]
        public void DeleteService()
        {
            Assert.Fail("not implemented yet");
        }
    }
}
