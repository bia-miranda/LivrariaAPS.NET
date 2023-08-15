using Livraria3.Dados;
using Livraria3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Livraria3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CadAutor()
        {
            return View();
        }

        AcAutores acoes = new AcAutores();//instancia de classe
        ModLivro modelo = new ModLivro();//instancia de classe

        public ActionResult ConfCadAutor(FormCollection frm)
        {
            modelo.nomeAutor = frm["txtNmAutor"];
            modelo.status = frm["txtSta"];

            acoes.inserirAutor(modelo);

            return View();
        }

        public ActionResult AtAutor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AtAutor(FormCollection frm, string btn)
        {
            modelo.codAutor = frm["txtCodAutor"];
            if (btn == "Buscar")
            {
                acoes.BuscarAutor(modelo);
                ViewBag.cod = modelo.codAutor;
                ViewBag.nome = modelo.nomeAutor;
                ViewBag.sta = modelo.status;

                return View();
            }
            else if (btn == "Atualizar")
            {
                modelo.nomeAutor = frm["txtNmAutor"];
                modelo.status = frm["txtSta"];

                acoes.atualizarAutor(modelo);

                ViewBag.msg = "Autor atualizado.";

                return View();
            }
            else if (btn == "Exluir")
            {
                acoes.excluirAutor(modelo);

                ViewBag.msg = "Autor excluído";

                return View();
            }
            else
            {
                return View();
            }

        }
    }
}