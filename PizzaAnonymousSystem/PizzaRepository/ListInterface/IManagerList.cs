using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaModels.Models;

namespace PizzaRepository.ListInterface
{
    public interface IManagerList
    {

        int? InsertManager(Manager manager);
        Manager GetManager(int managerID);
        Boolean DeleteManager(int managerID);
        Manager UpdateManager(string name, int managerID, string streetAddress,
                                     string city, string state, string ZIPcode);
    }
    
}
