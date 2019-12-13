using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler55
{
    public class PalinAddTwoStrikes : IPalindromAdder
    {
        public void Add(BigInt a, ref BigInt result)
        {
            int lastIdx = a.len - 1;
            for (int i = 0; i < a.len; ++i)
            {
                result.num[i] = (byte)(a.num[i] + a.num[lastIdx - i]);
            }

            result.len = a.len;

            byte carry = 0;
            for (int i = 0; i < result.len; ++i)
            {
                result.num[i] += carry;

                if (result.num[i] > 9)
                {
                    result.num[i] -= 10;
                    carry = 1;
                }
                else
                {
                    carry = 0;
                }
            }

            if (carry > 0)
            {
                result.num[result.len] = 1;
                result.len += 1;
            }
        }
    }
}
