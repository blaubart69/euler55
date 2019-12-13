using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace euler55Bench
{
    [SimpleJob(launchCount: 1, warmupCount: 1, targetCount: 1)]
    public class BenchMain
    {
        int start = 196;
        int iterations = 100_000;

        void Run(Euler55.IPalindromAdder adder)
        {
            foreach ( var i in new Euler55.PalinIter(start, adder).Take(iterations))
            {
            }
        }

        [Benchmark]
        public void Run_196_100k_V1()
        {
            Run(new Euler55.PalinAddV1());
        }
        [Benchmark]
        public void Run_196_100k_unrolled()
        {
            Run(new Euler55.PalinAddUnrolled());
        }
        [Benchmark]
        public void Run_196_100k_PalinAddUnrolledWithArray()
        {
            Run(new Euler55.PalinAddUnrolledWithArray());
        }
        [Benchmark]
        public void Run_196_100k_PalinAddTwoStrikes()
        {
            Run(new Euler55.PalinAddTwoStrikes());
        }

        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<BenchMain>();
        }
    }
}
