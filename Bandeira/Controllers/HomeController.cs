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

        public ActionResult Detalhes(int id)
        {
            Arquivo executar = new Arquivo();

            IList<string> resp = executar.ExtrairDaPasta("C:/TestaArquivosOnline");
            string conteudo = executar.ExtrairConteudo("C:/TestaArquivosOnline"+resp.ElementAt(id));

            return View(new ArquivoDaLista(resp.ElementAt(id), conteudo, (id + 1), resp.Count));
        }
    }

}