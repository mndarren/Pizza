using PizzaGUI.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaGUI.Models
{
    public class IndexViewModel
    {
        public string GetAdmin = System.IO.Path.Combine(PizzaApi.Path, "accountmanager/account/admin");
        public string GetManager = System.IO.Path.Combine(PizzaApi.Path, "accountmanager/account/manager");
        public string GetProvider = System.IO.Path.Combine(PizzaApi.Path, "accountmanager/account/provider");
    }
}