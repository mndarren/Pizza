using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaModels.Models;

namespace PizzaRepository.ListInterface
{
    public interface IProviderDirectory
    {
        bool AddService(Service newService);
        bool DeleteServiceItem(int serviceID);
        Service UpdateService(Service newService);
        Service GetService(string serviceName);
    }
}
