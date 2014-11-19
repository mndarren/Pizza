using PizzaRepository.ListInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaModels.Models;
using PizzaCommon.Tools;

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
        public int? InsertManager(Manager manager)
        {
            var managerId = new int?();
            try
            {
                var pizzDB = new Entity.PizzaDBEntities();
                AppDomain.CurrentDomain.SetData("DataDirectory", PathFactory.DatabasePath());

                if (manager != null)
                {
                    if (manager.Name == null || manager.State == null || manager.StreetAddress == null || manager.ZipCode == null)
                        return false;

                    if (manager.Name.Trim().Length == 0 || manager.State.Trim().Length == 0 || manager.StreetAddress.Trim().Length == 0 || manager.ZipCode.Trim().Length == 0)
                        return false;

                    //first check if exist
                   Manager m2 = this.GetManager(manager.Name);
                   if (m2 != null) return false;

                    var tempmanager = pizzDB.Managers.Where(node => node.ID == manager.ID).FirstOrDefault();
                    if (tempmanager == null)
                    {
                        var eManager = MapManagerToEntity(manager);
                        pizzDB.Managers.Add(eManager);
                        pizzDB.SaveChanges();
                        managerId = eManager.ID;
                    }
                    else managerId = new int?();
                }
                else managerId = new int?();
            }
            catch (Exception e)
            {
                managerId = new int?();
                throw new Exception(e.Message);
            }
            return managerId;
        }


        //delete manager from link list
        public Boolean DeleteManager(int managerID)
        {
            var success = false;
            try
            {
                var pizzaDB = new Entity.PizzaDBEntities();//EntitiesRepository
                AppDomain.CurrentDomain.SetData("DataDirectory", PathFactory.DatabasePath());

                var tempManager = pizzaDB.Managers
                    .Where(es => es.ID == managerID).FirstOrDefault();

                if (null != tempManager)
                {
                    pizzaDB.Managers.Remove(tempManager);
                    pizzaDB.SaveChanges(); //Apply changes to DB
                    success = true;
                }
                else success = false;
            }
            catch (Exception e)
            {
                success = false;
                //If we have time, record the exception
                throw new Exception(e.Message);
            }
            return success;
        }

        //Update manager status
        public Manager UpdateManager(string name, int managerID, string streetAddress,
                                     string city, string state, string ZIPcode)
        {
            var manager = new Manager();
            try
            {
                //first check if exist
                Manager m2 = this.GetManager(manager.Name);
                if (m2 != null) return null;

                if (name == null || state == null || streetAddress == null || ZIPcode == null)
                    return null;

                if (name.Trim().Length == 0 || state.Trim().Length == 0 || streetAddress.Trim().Length == 0 || ZIPcode.Trim().Length == 0)
                    return null;

                var pizzDB = new Entity.PizzaDBEntities();
                AppDomain.CurrentDomain.SetData("DataDirectory", PathFactory.DatabasePath());

                var eMember = pizzDB.Managers.Where(node => node.ID == managerID).FirstOrDefault();

                if (eMember != null)
                {
                    foreach (var es in pizzDB.Managers.Where(es => es.ID == managerID))
                    {
                        es.Name = name;
                        es.StreetAddress = streetAddress;
                        es.City = city;
                        es.State = state;
                        es.ZipCode = ZIPcode;
                    }
                    pizzDB.SaveChanges();
                    manager = GetManager(managerID);
                }
                else manager = null;
            }
            catch (Exception e)
            {
                manager = null;
                throw new Exception(e.Message);
            }
            return manager;
        }


        public Manager GetManager(int managerID)
        {
            var manager = new Manager();
            try
            {
                var pizzaDB = new Entity.PizzaDBEntities();//EntitiesRepository
                AppDomain.CurrentDomain.SetData("DataDirectory", PathFactory.DatabasePath());

                var tempManager = pizzaDB.Managers
                    .Where(es => es.ID == managerID).FirstOrDefault();

                if (null != tempManager)
                    manager = MapEntityToManager(tempManager);
                else manager = null;
            }
            catch (Exception e)
            {
                manager = null;
                //If we have time, record the exception
                throw new Exception(e.Message);
            }

            return manager;
        }

        public Manager GetManager(string _name)
        {
            var manager = new Manager();
            try
            {
                var pizzaDB = new Entity.PizzaDBEntities();//EntitiesRepository
                AppDomain.CurrentDomain.SetData("DataDirectory", PathFactory.DatabasePath());

                var tempManager = pizzaDB.Managers
                    .Where(es => es.Name == _name).FirstOrDefault();

                if (null != tempManager)
                    manager = MapEntityToManager(tempManager);
                else manager = null;
            }
            catch (Exception e)
            {
                manager = null;
                //If we have time, record the exception
                throw new Exception(e.Message);
            }

            return manager;
        }

    
        #region Entity DataType Mapping

        private Entity.Manager MapManagerToEntity(Manager manager)
        {
            var tempManager = new Entity.Manager();

            if (null != manager)
            {
                tempManager.ID = manager.ID;
                tempManager.Name = manager.Name;
                tempManager.StreetAddress = manager.StreetAddress;
                tempManager.City = manager.City;
                tempManager.State = manager.State;
                tempManager.ZipCode = manager.ZipCode;
            }

            return tempManager;
        }

        private Manager MapEntityToManager(Entity.Manager tempManager)
        {
            var manager = new Manager();

            if (null != tempManager)
            {
                manager.ID = tempManager.ID;
                manager.Name = tempManager.Name;
                manager.StreetAddress = tempManager.StreetAddress;
                manager.City = tempManager.City;
                manager.State = tempManager.State;
                manager.ZipCode = tempManager.ZipCode;
            }

            return manager;
        }

        #endregion
    }
}