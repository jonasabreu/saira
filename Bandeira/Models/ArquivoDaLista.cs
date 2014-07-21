using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bandeira.Models
{
    public class ArquivoDaLista
    {
        public  string nome             { get; set; }
        public  string conteudo         { get; set; }
        public  int proximo             { get; set; }
        public  int totalDeArquivos     { get; set; }
        public  string anotacao         { get; set; }

        public ArquivoDaLista(string nome, string cont, int prox, int total)
        {
            this.nome            = nome;
            this.conteudo        = cont;
            this.proximo         = prox;
            this.totalDeArquivos = total;
            this.anotacao = "";
        }

        public ArquivoDaLista(string nome, string cont, int prox, int total, string anotacao)
        {
            this.nome = nome;
            this.conteudo = cont;
            this.proximo = prox;
            this.totalDeArquivos = total;
            this.anotacao = anotacao;
        }
    }
}