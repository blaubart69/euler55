using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler55
{
    public class BigInt 
    {
        public byte[] num;
        public int    len;

        public BigInt(int init)
        {
            len = init.ToString().Length;
            num = new byte[1024*64];
            int i = 0;
            foreach ( char a in init.ToString().Reverse())
            {
                num[i] = (byte)(a - '0');
                ++i;
            }
        }
        // override object.Equals
        public override bool Equals(object other)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (other == null || GetType() != other.GetType())
            {
                return false;
            }

            return this.num.SequenceEqual(((BigInt)other).num);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.num.GetHashCode();
        }
        public override string ToString()
        {
            string number = "";
            for ( int i=this.len-1; i >= 0; --i)
            {
                number += (char)(num[i] + (byte)'0');
            }
            return number;
        }
        public void resize(int newlen)
        {
            byte[] help = new byte[newlen];
            num.CopyTo(help, 0);
            num = help;
        }
        public bool isPalindrom()
        {
            int lastIdx = len - 1;
            int halfway = len / 2;
            for (int i=0; i<halfway; ++i)
            {
                int rightIdx = i;
                int leftIdx = lastIdx - i;
                if ( num[leftIdx] != num[rightIdx] )
                {
                    return false;
                }
            }
            return true;
        }
    }
}
