using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace euler55
{
    class Program
    {
        static void Main(string[] args)
        {
            runWithProgress(196);
        }
        static void runWithProgress(int start)
        {
            Console.WriteLine($"calculating Lychrel for {start}");
            int iterations = 0;
            Task calc = Task.Run(() => runLychrel(start, ref iterations));

            int lastIter = 0;
            int seconds = 0;
            while ( !calc.Wait(1000) )
            {
                seconds++;
                int currIter = iterations;
                Console.WriteLine($"{seconds}s\t{currIter-lastIter}/s\t{currIter}");
                lastIter = currIter;
            }
        }
        static void runLychrel(int start, ref int iterations)
        {
            iterations = 0;
            var p = new PalinAdd[2] { new PalinAdd(start), new PalinAdd(0) };
            //Console.WriteLine($"(0)\t{p[0]}");

            int idx1 = 1;
            int idx2 = 0;
            do
            {
                idx1 ^= 1;
                idx2 ^= 1;

                p[idx1].selfPlusPalindrom(ref p[idx2]);
                ++iterations;

                //Console.WriteLine($"{iterations}\t{p[idx2]}");
            } while (!p[idx2].isPalindrom());
        }
    }
}
