using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SeedingDataFromCSV.Startup))]
namespace SeedingDataFromCSV
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
