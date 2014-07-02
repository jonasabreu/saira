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

                }
                return View("Resultado", objeto);
            }
            return View(objeto);
        }

        public ActionResult Resultado(Dados objeto)
        {
            return View();
        }
    }

}