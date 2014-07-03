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
            if(ModelState.IsValid)
            {
                Acao executar = new Acao();
                executar.CriarRepositorio(objeto.Diretorio);
                executar.ClonarRepositorio(objeto.URL, objeto.Diretorio);

                if(!Directory.EnumerateFileSystemEntries(objeto.Diretorio).Any())
                {
                    return View("Index");
                }
                return RedirectToAction("Detalhes", new { indice = 0 });
            }
            return View(objeto);
        }

        public ActionResult Detalhes(int indice)
        {
            Acao executar = new Acao();
            string[] arqs = executar.ExtrairTodosOsArquivos("C:/TestaArquivosOnline");
            List<string> resp = arqs.ToList();
            string conteudo = executar.ExtrairConteudoDoArquivo(resp.ElementAt(indice));

            return View(new ArquivoDaLista(resp.ElementAt(indice), conteudo, (indice + 1)));
        }




    }

}