using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Euler55;

namespace TestEuler55
{
    [TestClass]
    public class TestOneShotV1
    {
        [TestMethod]
        public void CompareToReference()
        {
            BigInt a = new BigInt(196);
            var iter = new PalinIter(196, new PalinAddV1());

            int iterations = 0;
            foreach ( var refValue in iter )
            {
                Euler55.PalinAddOneShotV1.AddPalindrom(ref a);
                Assert.AreEqual<BigInt>(expected: refValue, actual: a);
                if ( ++iterations == 10_000)
                {
                    break;
                }
            }
        }
    }
}
