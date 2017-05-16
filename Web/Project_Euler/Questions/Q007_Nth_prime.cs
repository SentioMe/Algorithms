using Algorithms.Internal;
using System;
using System.Collections.Generic;

namespace Project_Euler
{
    public class Q007_Nth_prime : IQuestionable<ulong>
    {
        public bool Ask()
        {
            Output.Reset();
            Output.Ask("By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.What is the Nth prime number?");

            return true;
        }

        public ulong[] Arguments { get { return new ulong[] { Input.Decimal("Please enter the natural number N.") }; } }

        public void Answer(ulong[] args)
        {
            Output.Enter();

            var N = args[0];
            /*
             * @note
             *  ~kr : 소수의 특성
             *        1) 소수(p)는 1 < p 범위의 자연수이며, 1과 자기 자신만을 약수로 가짐.
             *        2) 어떤 자연수 N이 소수라면, 1 < P <= rootN 범위 내의 있는 모든 소수로 나누어 떨어지지 않아야한다.
             *        3) 2)의 조건으로 판별 중, 2)를 만족하면서 집합 P의 임의의 원소 p에 대해 p^2 > N를 성립한다면, N은 소수이다.
             *   
             *  ~jp : 素数の特性
             *        1)　素数（ｐ）は、１＜ｐの範囲の自然数で、１と自分自身だけを除数で持ちます。
             *        2)　とある自然数Ｎが素数ならば、1 < P <= rootNの範囲内にある全ての素数で整除されたらいけません。
             *        3)  2)の条件で判別中に2)を満足しながら、集合Pの任意の元素pについてp^2> Nを成立すれば、Nは素数です。
             */

            Output.Answer(() =>
            {
                var primeList = new List<ulong>();
                primeList.Add(2);

                if (N > 1)
                {
                    ulong cur = 3;
                    while (primeList.Count < (int)N)
                    {
                        for (int i = 0; i < primeList.Count; ++i)
                        {
                            var prime = primeList[i];
                            if (cur % prime == 0)
                                break;

                            if (i == primeList.Count - 1)
                                primeList.Add(cur);
                        }
                        cur += 2;
                    }
                }

                return string.Format("{0} prime number is {1}", N.ToOrdinal(), primeList[primeList.Count - 1]);

            }, "Using prime list.");

            Output.Enter();

            Output.Answer(() =>
            {
                var primeList = new List<ulong>();
                primeList.Add(2);

                if (N > 1)
                {
                    ulong cur = 3;
                    while (primeList.Count < (int)N)
                    {
                        for (int i = 0; i < primeList.Count; ++i)
                        {
                            var prime = primeList[i];
                            if (cur % prime == 0)
                                break;

                            if (prime * prime > cur)
                            {
                                primeList.Add(cur);
                                break;
                            }
                        }
                        cur += 2;
                    }
                }

                return string.Format("{0} prime number is {1}", N.ToOrdinal(), primeList[primeList.Count - 1]);

            }, "+Compare to the power of the prime.");
        }
    }
}
