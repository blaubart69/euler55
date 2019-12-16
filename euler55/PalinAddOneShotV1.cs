using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler55
{
    public class PalinAddOneShotV1
    {
        public static void AddPalindrom(ref BigInt a)
        {
            int halfway = a.len / 2;
            int lastIdx = a.len - 1;

            byte carry = 0;

            byte digitSum;

            for (int i=0; i<halfway; ++i)
            {
                int highIdx = lastIdx - i;

                byte tmp = (byte)(a.num[i] + a.num[highIdx]);
                if ( tmp > 9 )
                {
                    carry = 1;
                    digitSum = (byte)(tmp - 10);
                }
                else
                {
                    carry = 0;
                    digitSum = tmp;
                }

                a.num[i]       = (byte)(digitSum + carry);
                a.num[highIdx] =        digitSum;

                if (carry > 0)
                {

                }
            }

        }
    }
}
