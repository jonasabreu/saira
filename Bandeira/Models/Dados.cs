using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bandeira.Models
{
    public class Dados
    {
        [Required(ErrorMessage = "Favor, insira uma URL")]
        public string URL { get; set; }

        [Required(ErrorMessage = "Favor, insira um diretório onde salvar os dados")]
        [RegularExpression(@"[A-Z]{1}\:\/([\w]+\/*)+", ErrorMessage = "Formato de diretorio inválido!")]
        public string Diretorio { get; set; }
    }
}