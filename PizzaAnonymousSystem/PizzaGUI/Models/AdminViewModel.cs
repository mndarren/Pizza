using PizzaGUI.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaGUI.Models
{
    public class AdminViewModel
    {
        public string AddMember = System.IO.Path.Combine(PizzaApi.Path, "accountmanager/account/member");
        public string AddAdmin = System.IO.Path.Combine(PizzaApi.Path, "accountmanager/account/admin");
        public string AddManager = System.IO.Path.Combine(PizzaApi.Path, "accountmanager/account/manager");
        public string AddProvider = System.IO.Path.Combine(PizzaApi.Path, "accountmanager/account/provider");

        public string UpdateMember = System.IO.Path.Combine(PizzaApi.Path, "accountmanager/account/member");
        public string UpdateAdmin = System.IO.Path.Combine(PizzaApi.Path, "accountmanager/account/admin");
        public string UpdateManager = System.IO.Path.Combine(PizzaApi.Path, "accountmanager/account/manager");
        public string UpdateProvider = System.IO.Path.Combine(PizzaApi.Path, "accountmanager/account/provider");

        public string DeleteMember = System.IO.Path.Combine(PizzaApi.Path, "accountmanager/account/member");
        public string DeleteAdmin = System.IO.Path.Combine(PizzaApi.Path, "accountmanager/account/admin");
        public string DeleteManager = System.IO.Path.Combine(PizzaApi.Path, "accountmanager/account/manager");
        public string DeleteProvider = System.IO.Path.Combine(PizzaApi.Path, "accountmanager/account/provider");

        public string AddService = System.IO.Path.Combine(PizzaApi.Path, "servicemanager/services");
        public string UpdateService = System.IO.Path.Combine(PizzaApi.Path, "servicemanager/services");
        public string DeleteService = System.IO.Path.Combine(PizzaApi.Path, "servicemanager/services");

        public string UpdateMemberReportSchedule = System.IO.Path.Combine(PizzaApi.Path, "reportmanager/schedules/memberreport");
        public string UpdateProviderReportSchedule = System.IO.Path.Combine(PizzaApi.Path, "reportmanager/schedules/providerreport");
        public string UpdateEFTReportSchedule = System.IO.Path.Combine(PizzaApi.Path, "reportmanager/schedules/eftreport");

        public string GetWeeklyMemberReports = System.IO.Path.Combine(PizzaApi.Path, "reportmanager/reports/memberreport");
        public string GetWeeklyProviderReports = System.IO.Path.Combine(PizzaApi.Path, "reportmanager/reports/providerreport");
        public string GetWeeklyEFTReports = System.IO.Path.Combine(PizzaApi.Path, "reportmanager/reports/eftreport");

        public string GetWeeklyMemberReportsFile = System.IO.Path.Combine(PizzaApi.Path, "reportmanager/reports/memberreport/file");
        public string GetWeeklyProviderReportsFile = System.IO.Path.Combine(PizzaApi.Path, "reportmanager/reports/providerreport/file");
        public string GetWeeklyEFTReportsFile = System.IO.Path.Combine(PizzaApi.Path, "reportmanager/reports/eftreport/file");
    }
}