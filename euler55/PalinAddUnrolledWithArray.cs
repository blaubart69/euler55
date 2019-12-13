using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler55
{
    public class PalinAddUnrolledWithArray : IPalindromAdder
    {
        const int unrollFactor = 4;
        const int lastTmpIdx = unrollFactor - 1;
        byte[] tmp = new byte[unrollFactor];

        public void Add(BigInt a, ref BigInt result)
        {
            byte carry = 0;
            int lastIdx = a.len - 1;
            int i = 0;
            
            while (i < a.len)
            {
                if (a.len > i + unrollFactor)
                {
                    // sum all togehter
                    for (int j = 0; j < unrollFactor; ++j)
                    {
                        tmp[j] = (byte)(a.num[i + j] + a.num[lastIdx - (i + j)]);
                    }

                    tmp[0] += carry;

                    for (int j = 0; j < unrollFactor - 1; ++j)
                    {
                        if (tmp[j] > 9) 
                        { 
                            result.num[i + j] = (byte)(tmp[j] - 10);
                            ++tmp[j + 1];
                        }
                        else            
                        { 
                            result.num[i + j] = tmp[j]; 
                        }
                    }

                    if (tmp[lastTmpIdx] > 9)
                    {
                        result.num[i + lastTmpIdx] = (byte)(tmp[lastTmpIdx] - 10);
                        carry = 1;
                    }
                    else
                    {
                        result.num[i + lastTmpIdx] = tmp[lastTmpIdx];
                        carry = 0;
                    }

                    i += unrollFactor;
                }
                else
                {
                    byte tmpX = (byte)(a.num[i] + a.num[lastIdx - i] + carry);

                    byte digit;
                    if (tmpX > 9)
                    {
                        digit = (byte)(tmpX - 10);
                        carry = 1;
                    }
                    else
                    {
                        digit = tmpX;
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
