using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookStoreSample.Startup))]
namespace BookStoreSample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
