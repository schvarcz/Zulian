using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Zulian.Startup))]
namespace Zulian
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
