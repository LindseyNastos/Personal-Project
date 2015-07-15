using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Quinterest.Startup))]
namespace Quinterest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
