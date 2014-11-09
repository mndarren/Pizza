using PizzaRepository.ListInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaModels.Models;

namespace PizzaRepository.ListClass
{
    public class ManagerList : IManagerList
    {
        private List<Manager> managers = new List<Manager>();

        private static ManagerList managerList;

        //create a manager list instance
        public static ManagerList Instance()
        {
            if (managerList == null)
            {
                return (managerList = new ManagerList());
            }
            else
            {
                return managerList;
            }
        }

        public ManagerList() { }

        //add manager into list
        public Boolean InsertManager(Manager manager)
        {
            if (manager != null)
            {
                managers.Add(manager);
                return true;
            }
            else { return false; }
        }

        public Manager GetManager(int managerID)
        {
            Manager manager = managers.Where(node => node.ID == managerID).FirstOrDefault();
            return manager;

        }

        //delete manager from link list
        public Boolean DeleteManager(int managerID)
        {
            Manager manager = managers.Where(node => node.ID == managerID).FirstOrDefault();
            if (manager != null)
            {
                managers.Remove(manager);
                return true;
            }
            else { return false; }
        }

        //Update manager status
        public Boolean UpdateManager(string name, int managerID, string streetAddress,
                                     string city, string state, string ZIPcode, int status)
        {
            Manager manager = managers.Where(node => node.ID == managerID).FirstOrDefault();
            if (manager != null)
            {
                manager.Name = name;
                manager.StreetAddress = streetAddress;
                manager.City = city;
                manager.State = state;
                manager.ZipCode = ZIPcode;
                return true;
            }
            else { return false; }
        }
    }
}