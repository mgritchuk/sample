using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookStoreSampleClient.Startup))]
namespace BookStoreSampleClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
