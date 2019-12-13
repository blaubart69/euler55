using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Euler55;
using System.Collections;
using System.Collections.Generic;

namespace TestEuler55
{
    [TestClass]
    public class UnitTest1
    {
        IEnumerable<string> nextResults(IEnumerable<IEnumerator<BigInt>> iters)
        {
            return
                iters.Select(i =>
                {
                    i.MoveNext();
                    return i.Current.ToString();
                });
        }
        [TestMethod]
        public void Test349()
        {
            var adder = new IPalindromAdder[] { 
                new PalinAddV1(), 
                new PalinAddUnrolled(), 
                new PalinAddUnrolledWithArray(),
                new PalinAddTwoStrikes() };

            var iters = adder.Select(a => new PalinIter(349, a).GetEnumerator()).ToList();

            Assert.IsTrue(nextResults(iters).All(i => i.Equals("1292")));
            Assert.IsTrue(nextResults(iters).All(i => i.Equals("4213")));
            Assert.IsTrue(nextResults(iters).All(i => i.Equals("7337")));
        }
        [TestMethod]
        public void isPalin7337()
        {
            BigInt a = new BigInt(7337);
            Assert.IsTrue(a.isPalindrom());
        }
        [TestMethod]
        public void isPalin73137()
        {
            BigInt a = new BigInt(73137);
            Assert.IsTrue(a.isPalindrom());
        }
        [TestMethod]
        public void isNotPalin73123137()
        {
            BigInt a = new BigInt(73123137);
            Assert.IsFalse(a.isPalindrom());
        }
        [TestMethod]
        public void Test196_5k_times()
        {
            var adder = new IPalindromAdder[] {
                new PalinAddV1()
                , new PalinAddUnrolled() 
                , new PalinAddUnrolledWithArray()
                , new PalinAddTwoStrikes() };

            var iters = adder.Select(a => new PalinIter(349, a).GetEnumerator()).ToList();

            int iteration = 0;
            for (int i=0; i < 5_000; ++i)
            {
                foreach (var iter in iters)
                {
                    iter.MoveNext();
                    ++iteration;
                }
                BigInt reference = iters[0].Current;
                for (int j=1;j<iters.Count;++j)
                {
                    var currIter = iters[j];
                    Assert.AreEqual<BigInt>( expected: reference, actual: currIter.Current, 
                        $"iteration# {iteration}, failing adder: {adder[j]}");
                }
            }
        }
    }
}
