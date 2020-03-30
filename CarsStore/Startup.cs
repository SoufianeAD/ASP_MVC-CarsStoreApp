using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarsStore.Startup))]
namespace CarsStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
