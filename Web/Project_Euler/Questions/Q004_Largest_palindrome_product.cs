using Algorithms.Internal;
using System;

namespace Project_Euler
{
    public class Q004_Largest_palindrome_product : IQuestionable<int>
    {
        public bool Ask()
        {
            Output.Reset();
            Output.Ask("A palindromic number reads the same both ways.The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.Find the largest palindrome made from the product of two N-digit numbers.");
            
            return true;
        }

        public int[] Arguments { get { return new int[] { (int)Input.Decimal("Please enter the digit P.") }; } }

        public void Answer(int[] args)
        {
            Output.Enter();

            var digit = Math.Max(args[0], 2);

            Output.Answer(() =>
            {
                ulong max = (ulong)Math.Pow(10, digit) - 1;
                ulong min = (ulong)Math.Pow(10, digit - 1);

                ulong maxValue = max * max;
                ulong minValue = min * min;

                for (ulong i = maxValue; i > minValue; --i)
                {
                    if (IsPalindrome(i))
                    {
                        for (ulong j = max; j > min; --j)
                        {
                            ulong multiplier = i / j;
                            if (i % j == 0 && multiplier > min && max > multiplier)
                                return string.Format("{0} x {1} = {2}", j, multiplier, i);

                        }
                    }
                }

                return "No value found.";
            }, "Using string");
        }

        /*
         * @brief
         *  ~kr : 정수를 문자열로 변환하여 끝단부터 비교하는 것으로 대칭 여부를 알 수 있습니다.
         *  ~jp : 整数を文字列に変換して先端から比較することで、対称かどうかを知ることができます。
         */
        bool IsPalindrome(ulong n)
        {
            string numStr = n.ToString();
            int length = numStr.Length;

            for (int i = 0; i < length / 2; ++i)
                if (numStr[i] != numStr[length - 1 - i])
                    return false;

            return true;
        }
    }
}
