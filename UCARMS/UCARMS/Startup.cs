using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UCARMS.Startup))]
namespace UCARMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
