using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UsandoCacheDeObjetos.Startup))]
namespace UsandoCacheDeObjetos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
