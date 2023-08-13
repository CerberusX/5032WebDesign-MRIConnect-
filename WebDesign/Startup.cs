using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebDesign.Startup))]
namespace WebDesign
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
