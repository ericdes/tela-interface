using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using ITela.Gc;

namespace UnitTesting
{
    [TestClass]
    public class GcDataCountryTests
    {
        [TestMethod]
        public void GetCountryCodeUsingLike1()
        {
            var codes = Country.GetCodesLike("SAN JOSE DEL CABO, B.C., SUR MEXICO.", x => x.VALUE, false);
            Assert.IsTrue(codes.First() == "MX");
        }

        [TestMethod]
        public void GetCountryCodeUsingLike2()
        {
            var codes = Country.GetCodesLike("SAN YSIDRO, CA.", x => x.VALUE, false);
            Assert.IsTrue(codes.Count() == 0);
        }
    }
}
