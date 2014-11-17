using PizzaGUI.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaGUI.Models
{
    public class ManagerViewModel
    {
        public string AddMember = System.IO.Path.Combine(PizzaApi.Path, "accountmanager/account/member");
        public string AddProvider = System.IO.Path.Combine(PizzaApi.Path, "accountmanager/account/provider");

        public string UpdateMember = System.IO.Path.Combine(PizzaApi.Path, "accountmanager/account/member");
        public string UpdateProvider = System.IO.Path.Combine(PizzaApi.Path, "accountmanager/account/provider");

        public string DeleteMember = System.IO.Path.Combine(PizzaApi.Path, "accountmanager/account/member");
        public string DeleteProvider = System.IO.Path.Combine(PizzaApi.Path, "accountmanager/account/provider");

        public string AddService = System.IO.Path.Combine(PizzaApi.Path, "servicemanager/services");
        public string UpdateService = System.IO.Path.Combine(PizzaApi.Path, "servicemanager/services");
        public string DeleteService = System.IO.Path.Combine(PizzaApi.Path, "servicemanager/services");

        public string UpdateMemberReportSchedule = System.IO.Path.Combine(PizzaApi.Path, "reportmanager/schedules/memberreport");
        public string UpdateProviderReportSchedule = System.IO.Path.Combine(PizzaApi.Path, "reportmanager/schedules/providerreport");
        public string UpdateEFTReportSchedule = System.IO.Path.Combine(PizzaApi.Path, "reportmanager/schedules/eftreport");
    }
}