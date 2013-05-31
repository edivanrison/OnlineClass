using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using EAD.Onlineclass.Dominio;
using EAD.OnlineClass.Aplicacao;

namespace EAD.OnlineClass.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            var cursosAplicacao = new CursoAplicacao();
            return View(cursosAplicacao.ListarTodos());
        }


    }
}
