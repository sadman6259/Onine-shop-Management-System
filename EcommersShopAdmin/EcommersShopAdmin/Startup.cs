using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EcommersShopAdmin.Startup))]
namespace EcommersShopAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
