using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Objektno.Startup))]
namespace Objektno
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
