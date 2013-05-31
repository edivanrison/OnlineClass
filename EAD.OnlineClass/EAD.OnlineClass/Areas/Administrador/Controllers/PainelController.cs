using System.Web.Mvc;
using EAD.OnlineClass.Aplicacao;
using EAD.Onlineclass.Dominio;

namespace EAD.OnlineClass.Areas.Administrador.Controllers
{
    public class PainelController : Controller
    {
        public ActionResult Inicio()
        {
            var adiministradorAplicacao = new AdministradorAplicacao();
            return View(adiministradorAplicacao.ListarTodos());
        }

        [Authorize]
        public ActionResult Detalhes(int id)
        {
            var administradorAplicacao = new AdministradorAplicacao();
            var administrador = administradorAplicacao.ListarPorId(id);
            if (administrador == null)
            {
                return HttpNotFound();
            }

            return View(administrador);
        }

        [Authorize]
        public ActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar(Administradores administradores)
        {
            if (ModelState.IsValid)
            {
                var administradoresAplicacao = new AdministradorAplicacao();
                administradoresAplicacao.Salvar(administradores);
                return RedirectToAction("Inicio");
            }
            return View(administradores);
        }

        [Authorize]
        public ActionResult Editar(int id)
        {
            var administradorAplicacao = new AdministradorAplicacao();
            var administrador = administradorAplicacao.ListarPorId(id);
            if (administrador == null)
                return HttpNotFound();

            return View(administrador);
        }

        [HttpPost]
        public ActionResult Editar(Administradores administradores)
        {
            if (ModelState.IsValid)
            {
                var administradorAplicacao = new AdministradorAplicacao();
                administradorAplicacao.Alterar(administradores);
                return RedirectToAction("Inicio");
            }

            return View(administradores);
        }

        [Authorize]
        public ActionResult Excluir(int id)
        {
            var administradorAplicacao = new AdministradorAplicacao();
            var administrador = administradorAplicacao.ListarPorId(id);
            if (administrador == null)
                return HttpNotFound();

            return View(administrador);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirmado(int id)
        {
            var administradorAplicacao = new AdministradorAplicacao();
            administradorAplicacao.Excluir(id);
            return RedirectToAction("Inicio");
        }
    }
}


