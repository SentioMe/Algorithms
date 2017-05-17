using Algorithms.Internal;
using System;
using System.Collections.Generic;

namespace Project_Euler
{
    public class Q005_Smallest_multiple : QuestionAbstract<ulong>
    {
        public override ulong[] Arguments { get { return new ulong[] { Input.Decimal("Please enter the natural number N.") }; } }

        public override void Answer(ulong[] args)
        {
            Output.Enter();

            var N = args[0];

            /*
             * @note
             * ~kr : 찾는 숫자 X는 주어진 범위 N 내에 있는 소수들만으로 소인수분해가 되는 수입니다.
             *       이 때문에 나눠 떨어지지 않는 숫자가 발생할 때,해당 수의 소인수 중 곱해지지 않은 부분만을 곱하는 것으로
             *       모든 수에 대한 최소공배수를 구할 수 있습니다.
             * ~jp :　探し数Xは与えられた範囲N内にある素数だけを使った素因数分解で表現できます。
             *        このため、残りが発生したときは、その数の素因数の中で乗算されていない部分だけを乗算することで、
             *        すべての数に対する最小公倍数を求めることができます。
             */
            Output.Answer(() =>
            {
                Output.Debug(Output.DebugLine);
                ulong result = 1;
                for (ulong i = 2; i <= N; ++i)
                {
                    if (result % i != 0)
                    {
                        Output.Debug("Current : {0} (Divisor {1}, Remainder {2})", result, i, result % i);
                        var factors = GetLackedFactors(result, i);
                        foreach (var factor in factors)
                        {
                            result *= factor;
                            Output.DebugWithOutLF(" * {0}", factor);
                        }
                        Output.Debug("= {0}", result);
                    }
                }
                Output.Debug(Output.DebugLine);

                return result.ToString();
            }, "Using factorial decomposition");
        }

        List<ulong> GetFactors(ulong value)
        {
            var factors = new List<ulong>();
            var range = (ulong)Math.Sqrt(value);

            while (MathExtends.IsPrimeNumber(value, range) == false)
            {
                for (ulong i = 2; i <= range; ++i)
                {
                    if (value % i == 0)
                    {
                        factors.Add(i);
                        value /= i;
                        break;
                    }
                }
            }
            factors.Add(value);
            return factors;
        }

        List<ulong> GetLackedFactors(ulong dividend, ulong divisor)
        {
            var dividendFactors = GetFactors(dividend);
            var divisorFactors = GetFactors(divisor);

            foreach (var i in dividendFactors)
                if (divisorFactors.Contains(i))
                    divisorFactors.Remove(i);

            return divisorFactors;
        }
    }
}
