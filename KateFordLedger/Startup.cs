using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KateFordLedger.Startup))]
namespace KateFordLedger
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
