using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Migo.Startup))]
namespace Migo
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
