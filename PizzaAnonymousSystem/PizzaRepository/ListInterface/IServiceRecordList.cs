using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaModels.Models;

namespace PizzaRepository.ListInterface
{
    public interface IServiceRecordList
    {
        Boolean InsertServiceRecord(ServiceRecord _serviceRecord);
        ServiceRecord GetServiceRecord(int serviceCodeID);
        List<ServiceRecord> GetAllServiceRecordForMember(int memberID);
        List<ServiceRecord> GetAllServiceRecordForProvider(int providerID);
    }
}
