using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using EAD.OnlineClass.Repositorio;
using EAD.Onlineclass.Dominio;

namespace EAD.OnlineClass.Aplicacao
{
    public class CursoAplicacao
    {
        private Contexto contexto = new Contexto();

        public void Inserir(Cursos cursos)
        {
            var strQuery = "";
            strQuery += string.Format("Insert into Cursos (NomeDoCurso, Descricao) values('{0}','{1}')",
                cursos.NomeDoCurso, cursos.Descricao);
            contexto.ExecutaComando(strQuery);
        }

        public void Alterar(Cursos cursos)
        {
            var strQuery = "";
            strQuery += string.Format("UPDATE Cursos SET NomeDoCurso ='{0}', Descricao = '{1}' WHERE CursoId = {2}",
                cursos.NomeDoCurso, cursos.Descricao, cursos.CursoId);
            contexto.ExecutaComando(strQuery);
        }

        public void Salvar (Cursos cursos)
        {
            if (cursos.CursoId > 0)
                Alterar(cursos);
            else
                Inserir(cursos);
        }

        public void Excluir(int id)
        {
            var strQuery = string.Format("DELETE FROM Cursos WHERE CursoId = {0}", id);
            contexto.ExecutaComando(strQuery);
        }

        public List<Cursos> ListarTodos()
        {
            var strQuery = " SELECT * FROM Cursos";
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);

            return TransformaReaderEmListaDeObjeto(retorno);
        }

        public Cursos ListarPorId(int id)
        {
            var strQuery = " SELECT * FROM Cursos WHERE CursoId = " + id;
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);

            return TransformaReaderEmListaDeObjeto(retorno).FirstOrDefault();
        }

        private List<Cursos> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var cursos = new List<Cursos>();
            while (reader.Read())
            {
                var tempObjeto = new Cursos
                {
                    CursoId = int.Parse(reader["CursoId"].ToString()),
                    NomeDoCurso = reader["NomeDoCurso"].ToString(),
                    Descricao = reader["Descricao"].ToString()
                };
                cursos.Add(tempObjeto);
            }
            return cursos;
        }
    }
}
