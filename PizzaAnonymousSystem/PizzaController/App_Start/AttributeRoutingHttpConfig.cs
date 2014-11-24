using System.Web.Http;
using AttributeRouting.Web.Http.WebHost;

[assembly: WebActivator.PreApplicationStartMethod(typeof(PizzaController.AttributeRoutingHttpConfig), "Start")]

namespace PizzaController 
{
    public static class AttributeRoutingHttpConfig
	{
		public static void RegisterRoutes(HttpRouteCollection routes) 
		{    
			// See http://github.com/mccalltd/AttributeRouting/wiki for more options.
			// To debug routes locally using the built in ASP.NET development server, go to /routes.axd

            routes.MapHttpAttributeRoutes(cfg =>
            {
                cfg.InMemory = true;
                cfg.AutoGenerateRouteNames = true;
                cfg.AddRoutesFromAssemblyOf<PizzaController.Controllers.ManageServiceController>();
                cfg.AddRoutesFromAssemblyOf<PizzaController.Controllers.ManageAccountController>();
                cfg.AddRoutesFromAssemblyOf<PizzaController.Controllers.ManageReportController>();
            });
		}

        public static void Start() 
		{
            RegisterRoutes(GlobalConfiguration.Configuration.Routes);
        }
    }
}
