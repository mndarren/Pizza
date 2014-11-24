/*@Class: CSCI531
 *@Author: Mo Chen
 *@Date:11/6/2014
 *@File: Admin.cs
 *@Description: this class contains Admin's info
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaModels.Models;

namespace PizzaModels.Models
{
    public class Admin : Person
    {
        #region Private Admins
        #endregion

        public Admin() { }
        public Admin(Admin adm)
        {
            ID = adm.ID;
            Name = adm.Name;
            StreetAddress = adm.StreetAddress;
            State = adm.State;
            City = adm.City;
            ZipCode = adm.ZipCode;
        }
    }
}