using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DDCities.Web.Startup))]
namespace DDCities.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
