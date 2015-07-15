using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pinterest.Startup))]
namespace Pinterest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
