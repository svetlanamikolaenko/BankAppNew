using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BankApp.Startup))]
namespace BankApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
