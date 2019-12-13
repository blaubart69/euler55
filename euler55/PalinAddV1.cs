namespace Euler55
{
    public class PalinAddV1 : IPalindromAdder
    {
        public void Add(BigInt a, ref BigInt result)
        {
            byte carry = 0;

            int lastIdx = a.len - 1;
            for (int i = 0; i < a.len; ++i)
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
