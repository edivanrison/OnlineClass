using System.Web.Mvc;
using EAD.OnlineClass.Aplicacao;
using EAD.Onlineclass.Dominio;

namespace EAD.OnlineClass.Areas.Administrador.Controllers
{
    public class CursosController : Controller
    {
        public ActionResult Index()
        {
            var cursoAplicacao = new CursoAplicacao();

            return View(cursoAplicacao.ListarTodos());
        }

        public ActionResult DetalhesCursos(int id)
        {
            var curso = new CursoAplicacao();
            return View(curso.ListarPorId(id));

        }


        public ActionResult CadastrarCursos()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CadastrarCursos(Cursos cursos)
        {
            if (ModelState.IsValid)
            {
                var cursoAplicacao = new CursoAplicacao();
                cursoAplicacao.Inserir(cursos);
                return RedirectToAction("Index");
            }
            return View(cursos);
        }

        public ActionResult EditarCursos(int id)
        {

            var cursoAplicacao = new CursoAplicacao();
            var cursos = cursoAplicacao.ListarPorId(id);
            if (cursos == null)
                return HttpNotFound();

            return View(cursos);
        }

        [HttpPost]
        public ActionResult EditarCursos(Cursos cursos)
        {
            if (ModelState.IsValid)
            {
                var cursoAplicacao = new CursoAplicacao();
                cursoAplicacao.Salvar(cursos);
                return RedirectToAction("Index");
            }

            return View(cursos);
        }

        [Authorize]
        public ActionResult ExcluirCurso(int id)
        {
            var cursoAplicacao = new CursoAplicacao();
            var curso = cursoAplicacao.ListarPorId(id);
            if (curso == null)
                return HttpNotFound();

            return View(curso);
        }

        [HttpPost, ActionName("ExcluirCurso")]
        public ActionResult ExcluirConfirmado(int id)
        {
            var cursoAplicacao = new CursoAplicacao();
            cursoAplicacao.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}