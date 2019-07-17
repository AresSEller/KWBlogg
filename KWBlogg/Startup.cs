using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KWBlogg.Startup))]
namespace KWBlogg
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
