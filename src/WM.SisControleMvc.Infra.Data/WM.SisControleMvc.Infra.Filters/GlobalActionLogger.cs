using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WM.SisControleMvc.Infra.Filters
{
    public class GlobalActionLogger : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //LOG de auditoria

            if (filterContext.Exception != null)
            {
                //manipular a EX
                //Injetar uma lib de tratamento de erros
                // -> gravar log de erro no BD
                // -> Email para ADMin
                // -> retornar um codigo de erro amigavel
                // USE SEMPRE ASYNC AQUI DENTRO

                filterContext.ExceptionHandled = true;
                filterContext.Result = new HttpStatusCodeResult(500);

            }
            base.OnActionExecuted(filterContext);
        }
    }
}
