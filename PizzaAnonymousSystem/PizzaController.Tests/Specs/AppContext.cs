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
        public ManageServiceController ManageServiceController { get; set; }
        public ManageAccountController ManageAccountController { get; set; }
        public ManageReportController ManageReportController { get; set; }
    }
}
