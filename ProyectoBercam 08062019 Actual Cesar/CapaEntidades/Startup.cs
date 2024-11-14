using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CapaEntidades.Startup))]
namespace CapaEntidades
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
