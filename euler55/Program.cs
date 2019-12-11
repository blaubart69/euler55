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
            runLychrel(349);
            runLychrel(10667);
            runLychrel(10677);
            runLychrel(196);
        }
        static void runLychrel(int start)
        {
            int iterations = 0;
            var p = new PalinAdd[2] { new PalinAdd(start), new PalinAdd(0) };
            Console.WriteLine($"(0)\t{p[0]}");

            int idx1 = 1;
            int idx2 = 0;
            do
            {
                idx1 ^= 1;
                idx2 ^= 1;

                p[idx1].selfPlusPalindrom(ref p[idx2]);
                ++iterations;
                
                Console.WriteLine($"{iterations}\t{p[idx2]}");
            } while (!p[idx2].isPalindrom());

        }
    }
}
