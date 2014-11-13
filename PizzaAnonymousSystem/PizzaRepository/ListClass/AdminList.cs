﻿using PizzaCommon.Tools;
/*
Author: Mo Chen
*/
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
        public Boolean addAdmin(Admin admin)
        {
            var success = false;

            try
            {
                var pizzDB = new Entity.PizzaDBEntities();
                AppDomain.CurrentDomain.SetData("DataDirectory",
                    System.IO.Path.Combine(PathFactory.SolutionPath(), "PizzaRepository\\App_Data"));

                if (admin != null)
                {
                    var tempadmin = pizzDB.Admins.Where(node => node.ID == admin.ID).FirstOrDefault();
                    if (tempadmin == null)
                    {
                        pizzDB.Admins.Add(MapAdminToEntity(admin));
                        pizzDB.SaveChanges();
                        success = true;
                    }
                    else success = false;
                }
                else success = false;
            }
            catch (Exception e)
            {
                success = false;
                throw new Exception(e.Message);
            }
            return success;
        }

        //need to fix this
        public Admin GetAdmin(int adminID)
        {
            var admin = new Admin();
            try
            {
                var pizzaDB = new Entity.PizzaDBEntities();//EntitiesRepository
                AppDomain.CurrentDomain.SetData("DataDirectory",
                    System.IO.Path.Combine(PathFactory.SolutionPath(), "PizzaRepository\\App_Data"));

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
                    System.IO.Path.Combine(PathFactory.SolutionPath(), "PizzaRepository\\App_Data"));

                var tempAdmin = pizzaDB.Admins
                    .Where(es => es.ID == adminID).FirstOrDefault();

                if (null != tempAdmin)
                {
                    pizzaDB.Admins.Remove(tempAdmin);
                    pizzaDB.SaveChanges(); //Apply changes to DB
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
                    System.IO.Path.Combine(PathFactory.SolutionPath(), "PizzaRepository\\App_Data"));

                Admin eAdmin = admins.Where(node => node.ID == adminID).FirstOrDefault();

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
            }

            return Admin;
        }

        #endregion
    }
}