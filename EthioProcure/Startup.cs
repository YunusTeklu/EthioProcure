using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EthioProcure.Startup))]
namespace EthioProcure
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
