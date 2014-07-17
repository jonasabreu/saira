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

        public bool exibir { get; set; }

        public readonly string Diretorio = "C:/TestaArquivosOnline";
    }
}