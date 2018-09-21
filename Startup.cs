using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EcommersShop.Startup))]
namespace EcommersShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
