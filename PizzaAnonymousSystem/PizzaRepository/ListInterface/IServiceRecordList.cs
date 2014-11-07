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
        List<ServiceRecord> GetServiceRecords();
    }
}
