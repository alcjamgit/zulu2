using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShareWealth.Web.Startup))]
namespace ShareWealth.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
