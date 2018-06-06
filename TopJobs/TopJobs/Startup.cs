using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TopJobs.Startup))]
namespace TopJobs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
