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
            var repository = new ProviderDirectory();
            var serviceList = repository.GetServices();
            var count = serviceList.Count;

            Assert.IsTrue(count != 0, "returned updated provider");
        }
        [TestMethod]
        [TestCategory("ProviderDirectory")]
        public void UpdateService()
        {
            var repository = new ProviderDirectory();
            var addedService = new Service(888777, "WashFeet", 100m);
            var success = repository.AddService(addedService);

            var newService = new Service(888777, "cutNail", 104m);
            var updatedService = repository.UpdateService(newService);

            Assert.IsTrue(updatedService != null, "returned updated provider");

            Assert.AreEqual(updatedService.ServiceCode, newService.ServiceCode, "codes are not equal");
            Assert.AreEqual(updatedService.ServiceName, newService.ServiceName, "names are not equal");
            Assert.AreEqual(updatedService.ServiceFee, newService.ServiceFee, "fees are not equal");

            //Negtive Path
            var newService1 = new Service(777999, "cutNail", 104m);
            var updatedService1 = repository.UpdateService(newService1);

            Assert.IsFalse(updatedService == null, "returned updated provider");
        }

        [TestMethod]
        [TestCategory("ProviderDirectory")]
        public void DeleteService()
        {
            var repository = new ProviderDirectory();
            var newService = new Service(888777, "WashFeet", 100m);
            var success = repository.AddService(newService);

            var serviceList = repository.GetServices();
            var service = serviceList[serviceList.Count - 1];

            success = repository.DeleteService(service.ServiceCode);
            Assert.IsTrue(success, "delete fail");
            //Negtive path
            success = repository.DeleteService(service.ServiceCode);
            Assert.IsFalse(success, "delete fail");
        }
    }
}
