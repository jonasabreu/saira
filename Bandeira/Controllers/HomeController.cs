﻿using Bandeira.Models;
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
                try
                {
                    executar.ClonarRepositorio(objeto.URL, objeto.Diretorio);
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
            Acao executar = new Acao();
            string[] arqs = executar.ExtrairTodosOsArquivos("C:/TestaArquivosOnline");
            List<string> resp = arqs.ToList();
            string conteudo = executar.ExtrairConteudoDoArquivo(resp.ElementAt(id));

            return View(new ArquivoDaLista(resp.ElementAt(id), conteudo, (id + 1), arqs.Length));
        }




    }

}