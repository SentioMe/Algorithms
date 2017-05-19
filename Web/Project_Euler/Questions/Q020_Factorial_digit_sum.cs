using Algorithms.Internal;
using System.Numerics;

/*
 * @note
 *  ~kr : 숫자를 문자의 배열로 변환해 관리한다면, BigInteger없이도 가능하다고 생각됩니다.
 *  ~jp : 数値を文字の配列として変換して管理すれば、BigIntegerなしで可能だと思っています。
 */

namespace Project_Euler
{
    public class Q020_Factorial_digit_sum : QuestionAbstract<int>
    {
        public override int[] Arguments { get { return new int[] { (int)Input.Decimal("Please enter the natural number N.") }; } }

        public override void Answer(int[] args)
        {
            Output.Enter();

            var N = args[0];

            Output.Answer(() =>
            {
                var nFac = Factorial(N).ToString();

                int sum = 0;
                
                for (int i = 0; i < nFac.Length; ++i)
                    sum += int.Parse(nFac.Substring(i, 1));

                Output.Debug(Output.DebugLine);
                Output.Debug("{0}! = {1}", N, nFac);
                Output.Debug(Output.DebugLine);

                return sum.ToString();

            }, "Using factorial and BigInteger type");
        }

        static BigInteger Factorial(int n)
        {
            if (n <= 1)
                return 1;

            return n * Factorial(n - 1);
        }
    }
}
