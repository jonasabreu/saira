using Bandeira.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Bandeira.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Dados objeto = new Dados(); 
            return View(objeto);
        }

        [HttpPost]
        public ActionResult Index(Dados objeto)
        {
            Dictionary<string, string> dic = new Dictionary<string, string> { };
            Session.Add("Dicionario", dic);

            if(ModelState.IsValid)
            {
                Arquivo executar = new Arquivo();
                Repositorio repo = new Repositorio();
                repo.Criar(objeto.Diretorio);
                try
                {
                    repo.Clonar(objeto.URL, objeto.Diretorio);
                    objeto.exibir = false;
                }
                catch
                {
                    objeto.exibir   = true;
                    return View("Index", objeto);
                }
                return RedirectToAction("Detalhes", new { id = 0 });
            }
            return View(objeto);
        }

        public ActionResult Detalhes(int id, string anot = null)
        {
            Arquivo executar = new Arquivo();           
            IList<string> resp = executar.ExtrairDaPasta("C:/TestaArquivosOnline");

            if(id < resp.Count())
            {
                string conteudo = executar.ExtrairConteudo("C:/TestaArquivosOnline" + resp.ElementAt(id));
                if (Session["Tamanho"] == null)
                {
                    Session["Tamanho"] = resp.Count;
                }
                Dictionary<string, string> dic = (Dictionary<string, string>)Session["Dicionario"];
                if (dic.ContainsKey(resp.ElementAt(id)))
                    ViewBag.Anotacao = dic[resp.ElementAt(id)];
                return View(new ArquivoDaLista(resp.ElementAt(id), conteudo, (id + 1), resp.Count, anot));
            }
            return RedirectToAction("Anotacoes");
        }

        public ActionResult SalvarDados(string nome, int atual, string anotacao)
        {
            Dictionary<string, string> dic = (Dictionary<string, string>)Session["Dicionario"];

            if(anotacao != "")
            {
                if (dic.ContainsKey(nome))
                {
                    dic[nome] += "\n" + anotacao;
                }
                else
                {
                    dic.Add(nome, anotacao);
                }
            }
            return RedirectToAction("Detalhes", new { id = (atual +1) });
        }

        public ActionResult Anotacoes()
        {
            return View();
        }
    }

}