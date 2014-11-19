using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaModels.Models;
using PizzaRepository.ListClass;

namespace PizzaRepository.Tests.ListClass
{
    [TestClass]
    public class ManagerListTests
    {
        [TestMethod]
        [TestCategory("ManagerList")]
        public void InsertManager()
        {
            var list = new ManagerList();

            //complete data
            var manager = new Manager();
            manager.Name = "manager02";
            manager.StreetAddress = "124 77th Ave S";
            manager.State = "MN";
            manager.City = "Saint Cloud";
            manager.ZipCode = "56401";
            var result = list.InsertManager(manager);
            Assert.IsTrue(result,"failed to adding a member.");

            //fields are null
            manager = new Manager();
            result = list.InsertManager(manager);
            Assert.IsFalse(result, "feilds are null.");

            //object is null
            result = list.InsertManager(null);
            Assert.IsFalse(result, "adding a null object.");

            //boundary data
            manager = new Manager();
            manager.Name = "";
            manager.StreetAddress = "";
            manager.State = "";
            manager.City = "";
            manager.ZipCode = "";
            result = list.InsertManager(manager);
            Assert.IsFalse(result, "all field are empty.");

            //add a manager who does exists in the DB
            manager = new Manager();
            manager.Name = "manager01";
            manager.StreetAddress = "123 77th Ave S";
            manager.State = "MN";
            manager.City = "Saint Cloud";
            manager.ZipCode = "56301";
            result = list.InsertManager(manager);
            Assert.IsFalse(result, "failed to execute an operation of adding a manager who does exist in the DB.");
        }

        [TestMethod]
        [TestCategory("ManagerList")]
        public void GetManager()
        {
            var list = new ManagerList();

            //search a manager who exists in the DB
            int managerID = 29;
            var result = list.GetManager(managerID);
            Assert.IsNotNull(result,"The manager should exist in the DB.");

            //search a manager who does not exist in the DB
             managerID = 0;
             result = list.GetManager(managerID);
             Assert.IsNull(result,"The manager ID does not exist in the DB.");

             //search a manager who does not exist in the DB
             managerID = 1000000;
             result = list.GetManager(managerID);
             Assert.IsNull(result, "The manager ID does not exist in the DB.");
        }

        [TestMethod]
        [TestCategory("ManagerList")]
        public void DeleteManager()
        {
            var list = new ManagerList();

            //delete a manager who exists in the DB
            int managerID = 42;
            var result = list.DeleteManager(managerID);
            Assert.IsTrue(result,"Failed to delete a manager who exists in the DB.");

            //delete a manager who does exist in the DB
            managerID = 0;
            result = list.DeleteManager(managerID);
            Assert.IsFalse(result, "Failed to execute an operation of deleting a manager who does not exist in the DB");

            //delete a manager who does exist in the DB
            managerID = 100000;
            result = list.DeleteManager(managerID);
            Assert.IsFalse(result, "Failed to execute an operation of deleting a manager who does not exist in the DB");
        }

        [TestMethod]
        [TestCategory("ManagerList")]
        public void UpdateManager()
        {
            var list = new ManagerList();
            int managerID = 46;
            string name = "manager02";
            string streetAddress = "999 9th Ave S";
            string city = "Saint Cloud";
            string state = "MN";
            string ZIPcode = "56399";

            var result = list.UpdateManager(name, managerID, streetAddress,
                                     city,state,ZIPcode);
            Assert.IsNotNull(result,"Failed to update the manager, and the manager may exist in the DB.");

             //fields are null
            result = list.UpdateManager(null,0,null,null,null,null);
            Assert.IsNull(result, "Failed to execute updating where fields are null.");


            //fields are empty
            result = list.UpdateManager("", 0, "", "", "", "");
            Assert.IsNull(result, "Failed to execute updating where fields are empty.");

            //A manager does not exist in the DB
             managerID = 0;
             name = "manager02";
             streetAddress = "999 9th Ave S";
             city = "Saint Cloud";
             state = "MN";
             ZIPcode = "56399";

             result = list.UpdateManager(name, managerID, streetAddress,
                                     city, state, ZIPcode);
            Assert.IsNull(result, "Failed to execute updating the manager, and the manager may not exist in the DB.");
        }
    }
}
