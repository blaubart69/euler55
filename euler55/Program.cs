using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Euler55
{
    public class Program
    {
        static void Main(string[] args)
        {
            runWithProgress(196);
        }
        static void runWithProgress(int start)
        {
            Console.WriteLine($"calculating Lychrel for {start}");
            int iterations = 0;
            int currLen = 0;
            Task calc = Task.Run(() => runLychrelV1(start, ref iterations, ref currLen));

            int lastIter = 0;
            int seconds = 0;
            while ( !calc.Wait(1000) )
            {
                seconds++;
                int currIter = iterations;
                Console.WriteLine($"{seconds}s\t{currIter-lastIter}/s\titer: {currIter}\tlen: {currLen}");
                lastIter = currIter;
                if (seconds==10)
                {
                    break;
                }
            }
        }
        public static void runLychrelV1(int start, ref int iterations, ref int len)
        {
            iterations = 0;
            var iter = new PalinIter(196, new PalinAddUnrolledWithArray()).GetEnumerator();
            do
            {
                iter.MoveNext();
                ++iterations;
                len = iter.Current.len;

            } while ( ! iter.Current.isPalindrom() );
        }
    }
}
