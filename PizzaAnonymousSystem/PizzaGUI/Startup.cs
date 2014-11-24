using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PizzaGUI.Startup))]
namespace PizzaGUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
