using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bandeira.Startup))]
namespace Bandeira
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
