using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EnverSoft.Startup))]
namespace EnverSoft
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
