using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EAD.OnlineClass.Aplicacao;
using EAD.Onlineclass.Dominio;

namespace EAD.OnlineClass.Controllers
{
    public class CursosController : Controller
    {
        //
        // GET: /Cursos/

        public ActionResult Cursos(int id)
        {
            var cursoAplicacao = new CursoAplicacao();
            return View(cursoAplicacao.ListarPorId(id));
        }

    }
}
