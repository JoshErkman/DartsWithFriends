using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DWF.WebMVC.Startup))]
namespace DWF.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
