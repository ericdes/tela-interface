using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using ITela.Gc;

namespace UnitTesting
{
    [TestClass]
    public class GcDataPackagingTypeTests
    {
        [TestMethod]
        public void GetValue()
        {
            var value = PackagingType.GetValue("1A");
            Assert.IsTrue(value == "Drum, steel");
        }

        [TestMethod]
        public void GetValueGeneric()
        {
            var value = PackagingType.GetValue("1A", x => x.numeric);
            Assert.IsTrue(value == "34");
        }

        [TestMethod]
        public void GetCodesContainText()
        {
            var codes = PackagingType.GetCodesLike("Drum", x => x.Value, false);
            Assert.IsTrue(codes.Count() == 1);
            Assert.IsTrue(codes.First() == "DR");
        }



    }
}
