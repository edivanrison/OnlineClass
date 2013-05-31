using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EAD.Onlineclass.Dominio;

namespace EAD.OnlineClass.Controllers
{
    public class CadastroController : Controller
    {
        //
        // GET: /Cadastro/

        public void Cadastro(Aluno aluno)
        {
            var strQuery = "";
            strQuery += string.Format("Insert into ALUNO (AlunoLogin,AlunoSenha) values('{0}','{1}')",
                aluno.Login, aluno.Senha);
            contexto.ExecutaComando(strQuery);
        }

    }
}
