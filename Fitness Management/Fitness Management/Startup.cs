using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fitness_Management.Startup))]
namespace Fitness_Management
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
