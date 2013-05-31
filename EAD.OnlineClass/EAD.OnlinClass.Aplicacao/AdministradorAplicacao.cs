using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using EAD.Onlineclass.Dominio;
using EAD.OnlineClass.Repositorio;


namespace EAD.OnlineClass.Aplicacao
{
    public class AdministradorAplicacao
    {
        private Contexto contexto = new Contexto();

        public void Inserir(Administradores administradores)
        {
            var strQuery = "";
            strQuery += string.Format("Insert into Administradores (AdministradorNome,AdministradorLogin,AdministradorSenha) values('{0}','{1}','{2}')",
                administradores.AdministradorNome, administradores.Login, administradores.Senha);
            contexto.ExecutaComando(strQuery);
        }

        public void Alterar(Administradores administradores)
        {
            var strQuery = "";
            strQuery += string.Format("UPDATE Administradores SET AdministradorNome ='{0}', AdministradorLogin = '{1}', " +
                                      "AdministradorSenha = '{2}' WHERE AdministradorId = {3}",
                administradores.AdministradorNome, administradores.Login, administradores.Senha, administradores.AdministradorId);
            contexto.ExecutaComando(strQuery);
        }

        public void Salvar(Administradores administradores)
        {
            if (administradores.AdministradorId > 0)
                Alterar(administradores);
            else
                Inserir(administradores);
        }

        public void Excluir(int id)
        {
            var strQuery = "";
            strQuery += string.Format("DELETE FROM Administradores WHERE AdministradorId = {0}", id);
            contexto.ExecutaComando(strQuery);
        }

        public List<Administradores> ListarTodos()
        {
            var strQuery = " SELECT * FROM Administradores";
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);

            return TransformaReaderEmListaDeObjeto(retorno);
        }

        public Administradores ListarPorId(int id)
        {
            var strQuery = " SELECT * FROM Administradores WHERE AdministradorId = " + id;
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);

            return TransformaReaderEmListaDeObjeto(retorno).FirstOrDefault();
        }

        private List<Administradores> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var administradores = new List<Administradores>();
            while (reader.Read())
            {
                var tempObjeto = new Administradores
                {
                    AdministradorId = int.Parse(reader["AdministradorId"].ToString()),
                    AdministradorNome = reader["AdministradorNome"].ToString(),
                    Login = reader["AdministradorLogin"].ToString(),
                    Senha = reader["AdministradorSenha"].ToString()
                };
                administradores.Add(tempObjeto);
            }
            return administradores;
        }

        public Administradores Logar(string login, string senha)
        {
            var strQuery = string.Format(" SELECT * FROM Administradores WHERE AdministradorLogin='{0}' and AdministradorSenha='{1}' ", login, senha);
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno).FirstOrDefault();

        }
    }
}
