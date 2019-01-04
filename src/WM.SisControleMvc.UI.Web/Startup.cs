using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WM.SisControleMvc.UI.Web.Startup))]
namespace WM.SisControleMvc.UI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
