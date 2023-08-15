using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Livraria3.Models
{
    public class ModLivro
    {

        [Required(ErrorMessage="Este campo é obrigatório")]
        [DisplayName("Código do livro")]
        public string codLivro { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DisplayName("Nome do livro")]
        public string nomeLivro { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DisplayName("Código do autor")]
        public string codAutor { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DisplayName("Nome do autor")]
        public string nomeAutor { get; internal set; }


        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DisplayName("Status")]
        public object status { get; internal set; }
    }
}