using PizzaRepository.ListInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaModels.Models;

namespace PizzaRepository.ListClassFake
{
    public class ProviderDirectoryFake : IProviderDirectory
    {
        private bool _returnError;

        public ProviderDirectoryFake(bool returnError = false)
        {
            this._returnError = returnError;
        }


        public bool ReturnError { get { return _returnError; } set { _returnError = value; } }


        public int? AddService(Service newService)
        {
            int? result = new int?();
            return result;
        }

        public Service GetService(string serviceName)
        {
            if (!_returnError)
            {
                return new Service(123456, "Massage", 100.00m);
            }
            else return null;
        }
        public Service GetService(int serviceCode)
        {
            if (!_returnError)
            {
                return new Service(123456, "Massage", 100.00m);
            }
            else return null;
        }

        public Service UpdateService(Service newService)
        {
            if (!_returnError)
            {
                return newService;
            }
            else return null;
        }

        public bool DeleteService(int serviceCode)
        {
            return !_returnError;
        }
        public List<Service> GetServices()
        {
            return new List<Service>();
        }
    }
}