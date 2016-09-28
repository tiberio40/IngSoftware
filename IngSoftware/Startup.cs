using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IngSoftware.Startup))]
namespace IngSoftware
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
