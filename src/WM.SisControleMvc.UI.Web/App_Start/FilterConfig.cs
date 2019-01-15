using System.Web;
using System.Web.Mvc;
using WM.SisControleMvc.Infra.Filters;

namespace WM.SisControleMvc.UI.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalActionLogger());
        }
    }
}   
