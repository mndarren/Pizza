using PizzaGUI.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaGUI.Models
{
    public class ProviderViewModel
    {
        public string ValidateMember = System.IO.Path.Combine(PizzaApi.Path, "accountmanager/validation/");

        public string AddServiceRecord = System.IO.Path.Combine(PizzaApi.Path, "servicemanager/servicerecords");
        public string GetAllServices = System.IO.Path.Combine(PizzaApi.Path, "servicemanager/services");

        public string VerifyProviderReportServices = System.IO.Path.Combine(PizzaApi.Path, "reportmanager/report/providerreport/verification/service");
        public string VerifyProviderReportFee = System.IO.Path.Combine(PizzaApi.Path, "reportmanager/report/providerreport/verification/fee");
    }
}