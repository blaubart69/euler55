using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace euler55
{
    public class PalinAdd
    {
        public byte[] _num;
        public int _len;

        public PalinAdd(int init)
        {
            _len = init.ToString().Length;
            _num = new byte[_len];
            int i = 0;
            foreach ( char a in init.ToString().Reverse())
            {
                _num[i] = (byte)(a - '0');
                ++i;
            }
        }
        public override string ToString()
        {
            string number = "";
            for ( int i=this._len-1; i >= 0; --i)
            {
                number += (char)(_num[i] + (byte)'0');
            }
            return number;
        }
        public void resize(int newlen)
        {
            _len = newlen;
            byte[] help = new byte[newlen];
            _num.CopyTo(help, 0);
            _num = help;
        }
        public void selfPlusPalindrom(ref PalinAdd result)
        {
            if ( result._len <= this._len )
            {
                result.resize(this._len * 4);
            }

            byte carry = 0;

            int lastIdx = this._len - 1;
            for ( int i = 0; i < _len; ++i)
            {
                byte tmp = (byte)(_num[i] + _num[lastIdx - i] + carry);

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
                result._num[i] = digit;
            }

            result._len = this._len;

            if ( carry > 0 )
            {
                result._num[result._len] = 1;
                result._len += 1;
            }
        }
        public bool isPalindrom()
        {
            int lastIdx = _len - 1;
            int halfway = _len / 2;
            for (int i=0; i<halfway; ++i)
            {
                int rightIdx = i;
                int leftIdx = lastIdx - i;
                if ( _num[leftIdx] != _num[rightIdx] )
                {
                    return false;
                }
            }
            return true;
        }
    }
}
