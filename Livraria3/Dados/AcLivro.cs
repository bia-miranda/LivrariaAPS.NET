using Livraria3.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Livraria3.Dados
{
    public class AcLivro
    {
        Conexao con = new Conexao();

        public void inserirLivro(ModLivro cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbLivro(nomeLivro, codAutor) values(@nomeLivro, @codAutor)",
                con.MyConectarBD()); //@parametro

            cmd.Parameters.Add("@nomeLivro", MySqlDbType.VarChar).Value = cm.nomeLivro;
            cmd.Parameters.Add("@codAutor", MySqlDbType.VarChar).Value = cm.codAutor;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        //mostra um select em um grid
        public DataTable selecionaLivro()
        {
            MySqlCommand cmd = new MySqlCommand("Select * from tbLivro inner join tbAutor on tbLivro.codAutor = tbAutor.codAutor", con.MyConectarBD());

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable atend = new DataTable();
            da.Fill(atend);
            con.MyDesconectarBD();
            return atend;
        }


        public List<ModLivro> BuscarLivro()
        {
            //mostra uma lista com os links
            List<ModLivro> ModList = new List<ModLivro>();
            MySqlCommand cmd = new MySqlCommand("Select * from tbLivro inner join tbAutor on tbLivro.codAutor = tbAutor.codAutor", con.MyConectarBD());

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ModList.Add(
                    new ModLivro
                    {
                        codLivro = Convert.ToString(dr["codLivro"]),
                        nomeLivro = Convert.ToString(dr["nomeLivro"]),
                        codAutor = Convert.ToString(dr["codAutor"]),
                        nomeAutor = Convert.ToString(dr["nomeAutor"])
                    }
                    );
            }
            return ModList;

        }
    }
}