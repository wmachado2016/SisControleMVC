using DomainValidation.Validation;
using System.Web.Mvc;

namespace WM.SisControleMvc.UI.Web.Controllers
{
    public class BaseController : Controller
    {
        protected void PopularModelStateComErros(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Erros)
            {
                ModelState.AddModelError(string.Empty, erro.Message);
            }
        }
    }
}