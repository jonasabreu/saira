using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using FluentAssertions;
using Bandeira.Controllers;
using Bandeira.Models;
using System.IO;

namespace Bandeira.Test
{
    public class UnitTest1
    {
        [Test]
        public void TestaCriacaoDeDiretorio()
        {
            Acao executar = new Acao();
            string path = "C:/Verificar";
            string resp = executar.CriarRepositorio(path);

            Directory.Exists(resp).Should().Be(true);
        }
    }
}
