using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WeaponsLocker.WebMVC.Startup))]
namespace WeaponsLocker.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
