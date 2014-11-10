using PizzaRepository.ListInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaRepository.ListClassFake
{
    public class ManagerListFake : IManagerList
    {
        public bool InsertManager(PizzaModels.Models.Manager manager)
        {
            throw new NotImplementedException();
        }

        public PizzaModels.Models.Member GetManager(int managerID)
        {
            throw new NotImplementedException();
        }

        public bool DeleteManager(int managerID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateManager(string name, int managerID, string streetAddress, string city, string state, string ZIPcode)
        {
            throw new NotImplementedException();
        }
    }
}