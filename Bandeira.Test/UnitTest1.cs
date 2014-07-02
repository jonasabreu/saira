using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using FluentAssertions;

namespace Bandeira.Test
{
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {

            var a = 1 + 2;

            a.Should().Be(2);

        }
    }
}
