﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibGit2Sharp;
using System.IO;

namespace Bandeira.Models
{
    public class Repositorio
    {
        public string Criar(string path)
        {
            var dir = Directory.CreateDirectory(path);
            Repository.Init(path);
            return dir.FullName;
        }

        public void Clonar(string URL, string path)
        {
            if (Directory.Exists(path))
            {
                Apagador apagar = new Apagador();
                apagar.DeleteDirectory(path);
            }
            Repository.Clone(URL, path);
        }
    }
}