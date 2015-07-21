using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Quinterest2.Startup))]
namespace Quinterest2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
