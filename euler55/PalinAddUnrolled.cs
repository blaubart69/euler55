using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler55
{
    public class PalinAddUnrolled : IPalindromAdder
    {
        public void Add(BigInt a, ref BigInt result)
        {
            byte carry = 0;

            int lastIdx = a.len - 1;
            int i = 0;
            while (i < a.len)
            {
                if (a.len > i + 4)
                {
                    byte tmp1, tmp2, tmp3, tmp4;
                    tmp1 = (byte)(a.num[i + 0] + a.num[lastIdx - (i + 0)] + carry);
                    tmp2 = (byte)(a.num[i + 1] + a.num[lastIdx - (i + 1)]);
                    tmp3 = (byte)(a.num[i + 2] + a.num[lastIdx - (i + 2)]);
                    tmp4 = (byte)(a.num[i + 3] + a.num[lastIdx - (i + 3)]);

                    if (tmp1 > 9)
                    {
                        result.num[i] = (byte)(tmp1 - 10);
                        tmp2 += 1;
                    }
                    else
                    {
                        result.num[i] = tmp1;
                    }
                    // -----
                    if (tmp2 > 9)
                    {
                        result.num[i + 1] = (byte)(tmp2 - 10);
                        tmp3 += 1;
                    }
                    else
                    {
                        result.num[i + 1] = tmp2;
                    }
                    // -----
                    if (tmp3 > 9)
                    {
                        result.num[i + 2] = (byte)(tmp3 - 10);
                        tmp4 += 1;
                    }
                    else
                    {
                        result.num[i + 2] = tmp3;
                    }
                    // -----
                    if (tmp4 > 9)
                    {
                        result.num[i + 3] = (byte)(tmp4 - 10);
                        carry = 1;
                    }
                    else
                    {
                        result.num[i + 3] = tmp4;
                        carry = 0;
                    }

                    i += 4;
                }
                else
                {
                    byte tmp = (byte)(a.num[i] + a.num[lastIdx - i] + carry);

                    byte digit;
                    if (tmp > 9)
                    {
                        digit = (byte)(tmp - 10);
                        carry = 1;
                    }
                    else
                    {
                        digit = tmp;
                        carry = 0;
                    }
                    result.num[i] = digit;

                    i += 1;
                }
            }

            result.len = a.len;

            if (carry > 0)
            {
                result.num[result.len] = 1;
                result.len += 1;
            }
        }
    }
}
