using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EAD.OnlineClass.Aplicacao;
using EAD.Onlineclass.Dominio;

namespace EAD.OnlineClass.Controllers
{
    public class CadastrarController : Controller
    {
        //
        // GET: /Cadastrar/

        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                var alunoAplicacao = new AlunoAplicacao();
                alunoAplicacao.Inserir(aluno);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

    }
}
