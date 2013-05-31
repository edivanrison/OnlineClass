using System.Web.Mvc;
using System.Web.Security;
using EAD.OnlineClass.Aplicacao;

namespace EAD.OnlineClass.Areas.Administrador.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string login, string senha)
        {
            var administradorAcesso = new AdministradorAplicacao();
            var administradorLogado = administradorAcesso.Logar(login, senha);
            if (administradorLogado != null)
            {
                FormsAuthentication.SetAuthCookie(login, false);

                Session["Usuario"] = administradorLogado;

                return RedirectToAction("Painel", "Home");
            }
            ViewBag.Mensagem = "Login ou senha inválido";

            return View();
        }

        [Authorize]

        public ActionResult Painel()
        {
            return RedirectToAction("Inicio", "Painel");
        }
    }
}
