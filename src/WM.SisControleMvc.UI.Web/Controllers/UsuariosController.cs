using System;
using System.Web.Mvc;
using WM.SisControleMvc.Application.Interfaces;
using WM.SisControleMvc.Application.ViewsModels;
using WM.SisControleMvc.Infra.Filters;

using DomainValidation.Validation;

namespace WM.SisControleMvc.UI.Web.Controllers
{
    [Authorize]
    [RoutePrefix("area-administrativa/gestão-usuários")]
    public class UsuariosController : BaseController
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuariosController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }
                
        [ClaimsAuthorize("Usuarios","LI")]
        [Route("listar-todos")]
        public ActionResult Index()
        {
            return View(_usuarioAppService.ObterAtivos());
        }

        [ClaimsAuthorize("Usuarios", "DE")]
        [Route("detalhes/{id:guid}")]
        public ActionResult Details(Guid id)
        {
            var usuarioViewModel = _usuarioAppService.ObterPorId(id);

            if (usuarioViewModel == null)
            {
                return HttpNotFound();
            }

            return View(usuarioViewModel);
        }

        [ClaimsAuthorize("Usuarios", "IN")]
        [Route("criar-novo")]
        public ActionResult Create()
        {
            return View();
        }

        [ClaimsAuthorize("Usuarios", "IN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("criar-novo")]
        public ActionResult Create(UsuarioEnderecoViewModel usuarioEndercoViewModel)
        {
            if (!ModelState.IsValid) return View(usuarioEndercoViewModel);

            var usuarioEnd = _usuarioAppService.Adicionar(usuarioEndercoViewModel);

            if (usuarioEnd.Usuario.ValidationResult.IsValid) return RedirectToAction("Index");

            PopularModelStateComErros(usuarioEnd.Usuario.ValidationResult);

            return View(usuarioEndercoViewModel);
        }

        [ClaimsAuthorize("Usuarios", "ED")]
        [Route("editar/{id:guid}")]
        public ActionResult Edit(Guid id)
        {
            var usuarioViewModel = _usuarioAppService.ObterPorId(id);

            if (usuarioViewModel == null)
            {
                return HttpNotFound();
            }

            return View(usuarioViewModel);
        }

        [ClaimsAuthorize("Usuarios", "ED")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("editar/{id:guid}")]
        public ActionResult Edit(UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid) return View(usuarioViewModel);

            _usuarioAppService.Atualizar(usuarioViewModel);
            return RedirectToAction("Index");
        }

        [ClaimsAuthorize("Usuarios", "EX")]
        [Route("excluir/{id:guid}")]
        public ActionResult Delete(Guid id)
        {
            var usuarioViewModel = _usuarioAppService.ObterPorId(id);
            if (usuarioViewModel == null)
            {
                return HttpNotFound();
            }
            return View(usuarioViewModel);
        }

        [ClaimsAuthorize("Usuarios", "EX")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("excluir/{id:guid}")]
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
