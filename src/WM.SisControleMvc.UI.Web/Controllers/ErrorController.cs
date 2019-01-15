using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WM.SisControleMvc.UI.Web.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            ViewBag.AlertaError = "Ops...! Ocorreu um error";
            ViewBag.MensagemError = "Ocorreu um erro, tente novamente ou contate um administrador.";
            return View("Error");
        }

        public ActionResult NotFound()
        {
            ViewBag.AlertaError = "Ops...! Não encontrei";
            ViewBag.MensagemError = "Não existe página para URL confirmada!";
            return View("Error");
        }

        public ActionResult AccessDenied()
        {
            ViewBag.AlertaError = "Acesso negado";
            ViewBag.MensagemError = "Você não tem permissão para executar isso!";
            return View("Error");
        }
    }
}