using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Livraria3.Dados
{
    public class Conexao
    {
        MySqlConnection cn = new MySqlConnection("server=localhost; database=bdLivraria; user=root; password=12345678");
        public static string msg;

        public MySqlConnection MyConectarBD() //Método: Myconectarbd
        {
            try
            {
                cn.Open();
            }
            catch (Exception erro)
            {
                msg = "Ocorreu um erro ao se conectar" + erro.Message;
            }
            return cn;
        }

        public MySqlConnection MyDesconectarBD()
        {
            try
            {
                cn.Close();
            }
            catch (Exception erro)
            {
                msg = "Ocorreu um erro ao se conectar" + erro.Message;
            }
            return cn;
        }
    }
}