using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Clasificados.Startup))]
namespace Clasificados
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
