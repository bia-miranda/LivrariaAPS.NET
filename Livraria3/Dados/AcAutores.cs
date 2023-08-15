using Livraria3.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Livraria3.Dados
{
    public class AcAutores
    {

        Conexao con = new Conexao();
        public void inserirAutor(ModLivro cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbAutor (nomeAutor, sta) values (@nomeAutor, @sta)", con.MyConectarBD());

            cmd.Parameters.Add("@nomeAutor", MySqlDbType.VarChar).Value = cm.nomeAutor;
            cmd.Parameters.Add("@sta", MySqlDbType.VarChar).Value = cm.status;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }
        MySqlDataReader dr;
        public void BuscarAutor(ModLivro cm)
        {
            MySqlCommand cmd = new MySqlCommand("Select * from tbAutor where codAutor = @codAut", con.MyConectarBD());
            cmd.Parameters.AddWithValue("@codAut", cm.codAutor);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cm.codAutor = dr[1].ToString();
                cm.status = dr[2].ToString();
            }
            con.MyDesconectarBD();
        }

        public void atualizarAutor(ModLivro cm)
        {
            MySqlCommand cmd = new MySqlCommand("Update tbAutor set nomeAutor=@nomeAutor, sta=@status where codAutor=@codAutor", con.MyConectarBD());

            cmd.Parameters.Add("@codAutor", MySqlDbType.VarChar).Value = cm.codAutor;
            cmd.Parameters.Add("@nomeAutor", MySqlDbType.VarChar).Value = cm.nomeAutor;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = cm.status;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public void excluirAutor(ModLivro cm)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbAutor where codAutor=@cod", con.MyConectarBD());
            cmd.Parameters.Add("@cod", MySqlDbType.VarChar).Value = cm.codAutor;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

    }
}