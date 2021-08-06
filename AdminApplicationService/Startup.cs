using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdminApplicationService.Startup))]
namespace AdminApplicationService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
