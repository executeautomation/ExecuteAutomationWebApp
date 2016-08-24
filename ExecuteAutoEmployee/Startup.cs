using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExecuteAutoEmployee.Startup))]
namespace ExecuteAutoEmployee
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
