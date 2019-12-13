using System;
using System.Collections;
using System.Collections.Generic;

namespace Euler55
{
    public class PalinIter : IEnumerable<BigInt>
    {
        IPalindromAdder _adder;
        BigInt[] _xy;
        int _idx; 

        public PalinIter(int start, IPalindromAdder adder)
        {
            _adder = adder;
            _idx = 0;
            _xy = new BigInt[2];
            _xy[0] = new BigInt(start);
            _xy[1] = new BigInt(0);
        }
        IEnumerable<BigInt> Next()
        {
            for(;;)
            {
                BigInt add = _xy[_idx];
                _idx ^= 1;
                BigInt result = _xy[_idx];

                if (result.num.Length <= add.len)
                {
                    result.resize(add.len * 4);
                }

                _adder.Add(add, ref result);

                yield return result;
            }
        }

        public IEnumerator<BigInt> GetEnumerator()
        {
            return Next().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
