/*@Class: CSCI531
 *@Author: Mo Chen
 *@Date:11/8/2014
 *@File: AdminList.cs
 *@Description: this class contains Admin List's info
 */
using PizzaCommon.Tools;
using PizzaModels.Models;
using PizzaRepository.ListInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaRepository.ListClass
{
    public class AdminList : IAdminList
    {
        private List<Admin> admins = new List<Admin>();

        private static AdminList adminList;

        //create a admin list instance
        public static AdminList Instance()
        {
            if (adminList == null)
            {
                return (adminList = new AdminList());
            }
            else
            {
                return adminList;
            }
        }

        public AdminList() { }

        //add admin into list
        public int? AddAdmin(Admin admin)
        {
            var adminId = new int?();

            try
            {
                var pizzDB = new Entity.PizzaDBEntities();
                AppDomain.CurrentDomain.SetData("DataDirectory",
                    PathFactory.DatabasePath());

                if (admin != null)
                {
                    var tempadmin = pizzDB.Admins.Where(node => node.ID == admin.ID).FirstOrDefault();
                    if (tempadmin == null)
                    {
                        var eAdmin = MapAdminToEntity(admin);
                        pizzDB.Admins.Add(eAdmin);
                        pizzDB.SaveChanges();
                        adminId = eAdmin.ID;
                    }
                    else adminId = new int?();
                }
                else adminId = new int?();
            }
            catch (Exception e)
            {
                adminId = new int?();
                throw new Exception(e.Message);
            }
            return adminId;
        }

        //need to fix this
        public Admin GetAdmin(int adminID)
        {
            var admin = new Admin();
            try
            {
                var pizzaDB = new Entity.PizzaDBEntities();//EntitiesRepository
                AppDomain.CurrentDomain.SetData("DataDirectory",
                    PathFactory.DatabasePath());

                var tempAdmin = pizzaDB.Admins
                    .Where(es => es.ID == adminID).FirstOrDefault();

                if (null != tempAdmin)
                    admin = MapEntityToAdmin(tempAdmin);
                else admin = null;
            }
            catch (Exception e)
            {
                admin = null;
                //If we have time, record the exception
                throw new Exception(e.Message);
            }

            return admin;
        }

        //delete admin from link list
        public Boolean DeleteAdmin(int adminID)
        {
            var success = false;
            try
            {
                var pizzaDB = new Entity.PizzaDBEntities();//EntitiesRepository
                AppDomain.CurrentDomain.SetData("DataDirectory",
                    PathFactory.DatabasePath());

                var tempAdmin = pizzaDB.Admins
                    .Where(es => es.ID == adminID).FirstOrDefault();

                if (null != tempAdmin)
                {
                    pizzaDB.Admins.Remove(tempAdmin);
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

        //Update admin
        public Admin UpdateAdmin(string name, int adminID, string streetAddress,
                                     string city, string state, string ZIPcode)
        {
            var admin = new Admin();
            try
            {
                var pizzDB = new Entity.PizzaDBEntities();
                AppDomain.CurrentDomain.SetData("DataDirectory",
                    PathFactory.DatabasePath());

                var eAdmin = pizzDB.Admins.Where(node => node.ID == adminID).FirstOrDefault();

                if (eAdmin != null)
                {
                    foreach (var es in pizzDB.Admins.Where(es => es.ID == adminID))
                    {
                        es.Name = name;
                        es.StreetAddress = streetAddress;
                        es.City = city;
                        es.State = state;
                        es.ZipCode = ZIPcode;
                    }
                    pizzDB.SaveChanges();
                    admin = GetAdmin(adminID);
                }
                else admin = null;
            }
            catch (Exception e)
            {
                admin = null;
                throw new Exception(e.Message);
            }
            return admin;
        }


        #region Entity DataType Mapping

        private Entity.Admin MapAdminToEntity(Admin admin)
        {
            var tempAdmin = new Entity.Admin();

            if (null != admin)
            {
                tempAdmin.ID = admin.ID;
                tempAdmin.Name = admin.Name;
                tempAdmin.StreetAddress = admin.StreetAddress;
                tempAdmin.City = admin.City;
                tempAdmin.State = admin.State;
                tempAdmin.ZipCode = admin.ZipCode;
            }

            return tempAdmin;
        }

        private Admin MapEntityToAdmin(Entity.Admin tempAdmin)
        {
            var Admin = new Admin();

            if (null != tempAdmin)
            {
                Admin.ID = tempAdmin.ID;
                Admin.Name = tempAdmin.Name;
                Admin.StreetAddress = tempAdmin.StreetAddress;
                Admin.City = tempAdmin.City;
                Admin.State = tempAdmin.State;
                Admin.ZipCode = tempAdmin.ZipCode;
            }

            return Admin;
        }

        #endregion
    }
}