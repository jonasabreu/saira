using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibGit2Sharp;
using System.IO;

namespace Bandeira.Models
{
    public class Acao
    {
        public string CriarRepositorio(string path)
        {
            var dir = Directory.CreateDirectory(path);
            Repository.Init(path);
            return dir.FullName;
        }

        public void ClonarRepositorio(string URL, string path)
        {
            if(Directory.Exists(path))
            {
                Apagador apagar = new Apagador();
                apagar.DeleteDirectory(path);
            }

                Repository.Clone(URL, path);
        }
        
        public string[] ExtrairTodosOsArquivos(string path)
        {
            string[] arquivos = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            return arquivos;
        }

        public string ExtrairConteudoDoArquivo(string path)
        {
            string resp = File.ReadAllText(path);
            return resp;
        }

    }
}