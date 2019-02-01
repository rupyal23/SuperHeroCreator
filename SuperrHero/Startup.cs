using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuperrHero.Startup))]
namespace SuperrHero
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
