using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using euler55;

namespace TestEuler55
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test349()
        {
            PalinAdd a = new PalinAdd(349);
            PalinAdd r = new PalinAdd(0);

            a.selfPlusPalindrom(ref r);
            Assert.AreEqual("1292", r.ToString());

            r.selfPlusPalindrom(ref a);
            Assert.AreEqual("4213", a.ToString());

            a.selfPlusPalindrom(ref r);
            Assert.AreEqual("7337", r.ToString());
        }
        [TestMethod]
        public void isPalin7337()
        {
            PalinAdd a = new PalinAdd(7337);
            Assert.IsTrue(a.isPalindrom());
        }
        [TestMethod]
        public void isPalin73137()
        {
            PalinAdd a = new PalinAdd(73137);
            Assert.IsTrue(a.isPalindrom());
        }
        [TestMethod]
        public void isNotPalin73123137()
        {
            PalinAdd a = new PalinAdd(73123137);
            Assert.IsFalse(a.isPalindrom());
        }
    }
}
