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
                return RedirectToAction("Detalhes");
            }
            return View(objeto);
        }

        public ActionResult Detalhes()
        {
            Acao executar = new Acao();
            string[] arqs = executar.ExtrairTodosOsArquivos("C:/TestaArquivosOnline");
            List<string> resp = arqs.ToList();
            string conteudo = executar.ExtrairConteudoDoArquivo(resp.ElementAt(0));

            return View(resp.ElementAt(0), conteudo, 1);
        }




    }

}