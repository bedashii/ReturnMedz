using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mapper.Startup))]
namespace Mapper
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
