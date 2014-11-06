using PizzaController.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace PizzaController.Tests.Specs
{
    [Binding]
    public class AppContext
    {
        public ManageService ManageServiceController { get; set; }
        public ManageAccount ManageAccountController { get; set; }
        public ManageReport ManageReportController { get; set; }
    }
}
