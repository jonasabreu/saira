using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibGit2Sharp;
using System.IO;

namespace Bandeira.Models
{
    public class Arquivo
    {
        public IList<string> ExtrairDaPasta(string path)
        {
            return Directory.GetFiles(path, "*", SearchOption.AllDirectories).Where(e => !e.Contains(".git")).Select(e => e.Replace(path, "")).ToList();
        }

        public string ExtrairConteudo(string path)
        {
            return File.ReadAllText(path);
        }

    }
}