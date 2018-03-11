using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab3FIFA.Startup))]
namespace Lab3FIFA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
