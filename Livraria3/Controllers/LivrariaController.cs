using Livraria3.Dados;
using Livraria3.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Livraria3.Controllers
{
    public class LivrariaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public void CarregaAutores()
        {
            List<SelectListItem> autores = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("server=localhost; database=bdLivraria; user=root; password=12345678"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbAutor where sta=1", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    autores.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });

                }
                con.Close();
                ViewBag.autores = new SelectList(autores, "Value", "Text");
            }
        }

        public ActionResult CadLivro()
        {
            CarregaAutores();
            return View();
        }

        AcLivro ac = new AcLivro();//instancia de classe
        ModLivro mod = new ModLivro();//instancia de classe
        public ActionResult ConfCadLivro(FormCollection frm)
        {
            mod.nomeLivro = frm["txtNmLivro"];
            mod.codAutor = Request["autores"];
            ac.inserirLivro(mod);
            return View();
        }

        public ActionResult consLivro()
        {
            GridView gvAtend = new GridView();
            gvAtend.DataSource = ac.selecionaLivro();
            gvAtend.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gvAtend.RenderControl(htw);
            ViewBag.GridViewString = sw.ToString();
            return View();
        }

        public ActionResult ListarLivro()
        {
            return View(ac.BuscarLivro());
        }


    }
}