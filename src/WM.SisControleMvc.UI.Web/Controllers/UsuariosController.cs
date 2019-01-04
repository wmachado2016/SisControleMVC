using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WM.SisControleMvc.Application.Interfaces;
using WM.SisControleMvc.Application.Services;
using WM.SisControleMvc.Application.ViewsModels;
using WM.SisControleMvc.UI.Web.Models;

namespace WM.SisControleMvc.UI.Web.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuariosController()
        {
            _usuarioAppService = new UsuarioAppService();
        }
                
        public ActionResult Index()
        {
            return View(_usuarioAppService.ObterAtivos());
        }


        public ActionResult Details(Guid id)
        {
            var usuarioViewModel = _usuarioAppService.ObterPorId(id);

            if (usuarioViewModel == null)
            {
                return HttpNotFound();
            }

            return View(usuarioViewModel);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }
               
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioEnderecoViewModel usuarioEndViewModel)
        {
            if (!ModelState.IsValid) return View(usuarioEndViewModel);
            
            _usuarioAppService.Adicionar(usuarioEndViewModel);
            return RedirectToAction("Index");            
        }

        public ActionResult Edit(Guid id)
        {
            var usuarioViewModel = _usuarioAppService.ObterPorId(id);

            if (usuarioViewModel == null)
            {
                return HttpNotFound();
            }

            return View(usuarioViewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid) return View(usuarioViewModel);

            _usuarioAppService.Atualizar(usuarioViewModel);
            return RedirectToAction("Index");
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(Guid id)
        {
            var usuarioViewModel = _usuarioAppService.ObterPorId(id);
            if (usuarioViewModel == null)
            {
                return HttpNotFound();
            }
            return View(usuarioViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _usuarioAppService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _usuarioAppService.Dispose();
        }
    }
}
