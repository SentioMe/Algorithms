using Algorithms.Internal;
using System;

namespace Project_Euler
{
    /*
     * @note
     *  ~kr : 소수는 1과 자기 자신만을 약수로 가지는 수입니다.
     *        임의의 수 X를 소수들의 곱만으로 표현한 것을 '소인수분해' 라고 하며, 이때 이 소수들을 X의 '소인수(Prime factor)' 라고 합니다.
     *  ~jp : 素数は1と自分自身だけ除数で持つ数です。
     *        任意の数Xを素数の乗算だけで表現したものを「素因数分解」と呼ばれ、この時、この素数達のXの「素因数（Prime factor）」と呼ばれます。
     */
    public class Q003_Largest_prime_factor : IQuestionable<ulong>
    {
        public bool Ask()
        {
            Output.Reset();
            Output.Ask("The prime factors of 13195 are 5, 7, 13 and 29.\nWhat is the largest prime factor of the number N?");

            return true;
        }

        public ulong[] Arguments { get { return new ulong[] { Input.Decimal("Please enter the natural number N.") }; } }

        public void Answer(ulong[] args)
        {
            Output.Enter();
            
            ulong N = args[0];

            /*
             * @note
             *  ~kr : 가장 큰 수를 구하기 때문에 내림차순으로 진행하며, 2를 제외한 짝수는 소수가 아니므로 제외합니다.
             *        또한, 소수는 다른 수로 나뉘어져선 안 되므로 제곱근을 기준으로 그보다 작은 수만을 대상으로 할 수 있습니다.
             *  ~jp : 一番大きい数を求めるから、降順で行い、2を除く偶数は素数ではないので除外します。
             *        また、素数は他の数で分けないので、平方根を基準に、それより小さな数だけを対象にすることができます。
             */
            Output.Answer(() =>
            {
                var value = (ulong)Math.Sqrt(N);
                if ((value & 1) == 0) //=>Equal if(prime % 2 == 0)
                    --value;

                while (value > 1)
                {
                    if (N % value == 0 && MathExtends.IsPrimeNumber(value, (ulong)Math.Sqrt(value)))
                        break;

                    value -= 2;
                }

                return value.ToString();
            }, "Using square root.");
        }
    }
}
