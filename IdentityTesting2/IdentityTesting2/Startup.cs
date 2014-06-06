using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityTesting2.Startup))]
namespace IdentityTesting2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
