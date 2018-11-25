using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Challenge4.Website.Startup))]
namespace Challenge4.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
