using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using EAD.OnlineClass.Repositorio;
using EAD.Onlineclass.Dominio;

namespace EAD.OnlineClass.Aplicacao
{
    public class AlunoAplicacao
    {
        private Contexto contexto = new Contexto();

        public void Inserir(Aluno aluno)
        {
            var strQuery = "";
            strQuery += string.Format("Insert into Aluno (AlunoNome, AlunoLogin, AlunoSenha, AlunoEmail, AlunoRG, AlunoTelefone) values('{0}','{1}','{2}','{3}','{4}','{5}')",
                aluno.AlunoNome, aluno.Login, aluno.Senha, aluno.AlunoEmail, aluno.AlunoRG, aluno.AlunoTelefone);
            contexto.ExecutaComando(strQuery);
        }

        public void Alterar(Aluno aluno)
        {
            var strQuery = "";
            strQuery += string.Format("UPDATE Aluno SET AlunoNome ='{0}', AlunoLogin = '{1}', AlunoSenha = '{2}', AlunoEmail = '{3}', AlunoRG = '{4}', AlunoTelefone = '{5}' WHERE AlunoId = {6}",
                aluno.AlunoNome, aluno.Login, aluno.Senha, aluno.AlunoEmail, aluno.AlunoRG, aluno.AlunoTelefone, aluno.AlunoId);
            contexto.ExecutaComando(strQuery);
        }

        public void Salvar(Aluno aluno)
        {
            if (aluno.AlunoId > 0)
                Alterar(aluno);
            else
                Inserir(aluno);
        }

        public List<Aluno> ListarTodos()
        {
            var strQuery = " SELECT * FROM Aluno";
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);

            return TransformaReaderEmListaDeObjeto(retorno);
        }

        public Aluno ListarPorId(int id)
        {
            var strQuery = " SELECT * FROM Aluno WHERE AlunoId = " + id;
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);

            return TransformaReaderEmListaDeObjeto(retorno).FirstOrDefault();
        }

        private List<Aluno> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var aluno = new List<Aluno>();
            while (reader.Read())
            {
                var tempObjeto = new Aluno
                                     {
                    AlunoId = int.Parse(reader["AlunoId"].ToString()),
                    Login = reader["Descricao"].ToString(),
                    Senha = reader["Descricao"].ToString(),
                    AlunoNome = reader["NomeDoCurso"].ToString(),
                    AlunoEmail = reader["Descricao"].ToString(),
                    AlunoRG = reader["Descricao"].ToString(),
                    AlunoTelefone = reader["Descricao"].ToString()

                };
                aluno.Add(tempObjeto);
            }
            return aluno;
        }
    }
}
