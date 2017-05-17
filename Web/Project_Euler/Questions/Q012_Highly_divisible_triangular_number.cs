using Algorithms.Internal;
using System;
using System.Text;
using System.Collections.Generic;

namespace Project_Euler
{
    /*
     * @note
     *  ~kr : 삼각수(Triangle number)는 1부터 N까지의 합을 구하는 SigmaK와 같습니다
     *  ~jp : 三角数（Triangle number）は、1からNまでの合計をするSigmaKと同じです。
     */
    public class Q012_Highly_divisible_triangular_number : QuestionAbstract<int>
    {
        public override int[] Arguments { get { return new int[] { (int)Input.Decimal("Please enter the natural number N.") }; } }

        public override void Answer(int[] args)
        {
            Output.Enter();

            var N = args[0];

            /*
             * @note
             *  ~kr : 임의의 수 X의 약수의 개수 N은, X를 소인수분해하여 a^p * b^q 으로 표현된다고 할 때, N = (p + 1) * (q + 1)이 됩니다.
             *  ~jp : 任意の数Xの除数の数Nは、Xを素因数分解してa^ p* b^ qで表現されるとき、N=（p +1）*（q+1）になります。
             */
            Output.Answer(() =>
            {
                ulong triangularNum = 0;
                int current = 1;
                int gcmCount = 0;

                for (; gcmCount < N; ++current)
                {
                    triangularNum = MathExtends.SigmaK_ToN((ulong)current);

                    gcmCount = 1;

                    var factors = GetFactors(triangularNum).Values;

                    foreach (var factor in factors)
                        gcmCount *= (factor + 1);
                }

                Output.Debug("=====================================");
                Output.Debug("{0} Triangle number have {1} divisors", current, gcmCount);
                Output.Debug("=====================================");

                return triangularNum.ToString();
            }, "Using prime factorization");
        }

        Dictionary<ulong, int> GetFactors(ulong value)
        {
            var factors = new Dictionary<ulong, int>();

            var range = (ulong)Math.Sqrt(value);

            while (MathExtends.IsPrimeNumber(value, range) == false)
            {
                for (ulong i = 2; i <= range; ++i)
                {
                    if (value % i == 0)
                    {
                        AddFactor(factors, i);
                        value /= i;
                        break;
                    }
                }
            }

            if (value > 1)
                AddFactor(factors, value);

            return factors;
        }

        void AddFactor(Dictionary<ulong, int> factors, ulong factor)
        {
            if (factors.ContainsKey(factor) == false)
                factors.Add(factor, 1);
            else
                factors[factor]++;
        }
    }
}
