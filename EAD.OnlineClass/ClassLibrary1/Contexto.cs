﻿using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EAD.OnlineClass.Repositorio
{
    public class Contexto
    {
        private readonly SqlConnection minhaConexao;

        public Contexto()
        {
            minhaConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["OCDB"].ConnectionString);
            minhaConexao.Open();
        }

        public void ExecutaComando(string strQuery)
        {
            var cmdComando = new SqlCommand
                                 {
                                     CommandText = strQuery,
                                     CommandType = CommandType.Text,
                                     Connection = minhaConexao
                                 };
            cmdComando.ExecuteNonQuery();
        }

        public SqlDataReader ExecutaComandoComRetorno(string strQuery)
        {
            var cmdComando = new SqlCommand(strQuery, minhaConexao);
            return cmdComando.ExecuteReader();
        }

    }
}