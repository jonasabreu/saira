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
            Repositorio repo = new Repositorio();
            string path = "C:/Verificar";
            string resp = repo.Criar(path);
            Directory.Exists(resp).Should().Be(true);
        }

        [Test]
        public void TestaClonagemDeRepositorio()
        {
            Repositorio repo = new Repositorio();
                 string resp = repo.Criar("C:/Verificar");
                        repo.Clonar("https://github.com/jonasabreu/leis-site.git", "C:/Verificar");
            Directory.EnumerateFiles("C:/Verificar").Should().NotBeNull();
        }

        [Test]
        public void TestaExtracaoDeNomesDeArquivos()
        {
            Arquivo arq = new Arquivo();
            Repositorio repo = new Repositorio();
                 string resp = repo.Criar("C:/TestaArquivosOnline");
                               repo.Clonar("https://github.com/jonasabreu/leis-site.git", "C:/TestaArquivosOnline");
            Directory.EnumerateFiles("C:/TestaArquivosOnline").Should().NotBeNull();
            var teste = arq.ExtrairDaPasta("C:/TestaArquivosOnline");

            teste.Should().NotBeNull();
        }
    }
}
