using Algorithms.Internal;
using System;

namespace Project_Euler
{
    public class Q009_Special_Pythagorean_triplet : QuestionAbstract<ulong>
    {
        public override ulong[] Arguments { get { return new ulong[] { Input.Decimal("Please enter the natural number X.") }; } }

        public override void Answer(ulong[] args)
        {
            Output.Enter();

            var N = args[0];

            Output.Answer(() =>
            {
                for (ulong a = 1; a < N; ++a)
                {
                    for (ulong b = a + 1; b < N - a; ++b)
                    {
                        var c = N - a - b;
                        if (c * c == a * a + b * b)
                        {
                            Output.Debug("=====================================");
                            Output.Debug("a, b, c, = {0}, {1}, {2}", a, b, c);
                            Output.Debug("=====================================");
                            return (a * b * c).ToString();
                        }
                    }
                }

                return string.Format("There is no Pythagorean number to make a sum of {0}.", N);

            }, "Find O(n^2)");

            Output.Enter();

            /*
             * @note
             *  a + b + c = N
             *  b + c = N - a
             *  b = (N - a) - c       ......(1)
             *  
             *  Replace N - a with t. ......(2)
             *  b = t - c
             *  
             *  a^2 + b^2 = c^2
             *  a^2 + (t - c)^2 = c^2
             *  a^2 + t^2 - 2tc + c^2 = c^2
             *  a^2 + t^2 = 2tc
             *  (a^2 - t^2) / 2t = c  ......(3)
             */
            Output.Answer(() =>
            {
                for (ulong a = 1; a < N; ++a)
                {
                    var t = N - a;                      //...(2)
                    var c = (a * a + t * t) / (2 * t);  //...(3)

                    var b = N - a - c;                  //...(1)

                    if (a <= 0 || b <= 0)
                        continue;

                    if (a * a + b * b == c * c)
                    {
                        Output.Debug("=====================================");
                        Output.Debug("a, b, c, = {0}, {1}, {2}", a, b, c);
                        Output.Debug("=====================================");
                        return (a * b * c).ToString();
                    }
                }

                return string.Format("There is no Pythagorean number to make a sum of {0}.", N);

            }, "Replace N - a with t.");

            Output.Enter();

            /*
             * @note
             *  1) a = 2mn, b = m^2 - n^2, c = m^2 + n^2
             *  2) a^2 + b^2 = c^2 and a + b + c = X then
             *     d(a^2 + b^2) = d * c^2 and d(a + b + c) = dX
             */
            Output.Answer(() =>
            {
                var halfN = N / 2;
                for (ulong n = 1; n < halfN; ++n)
                {
                    for (ulong m = n + 1; m < halfN; ++m)
                    {
                        var pri_a = 2 * m * n; 
                        var pri_b = m * m - n * n;
                        var pri_c = m * m + n * n;

                        if (pri_a > halfN || pri_b > halfN)
                            continue;
                        
                        if (GCM(pri_a, pri_b, pri_c) == 1)
                        {
                            var sum = pri_a + pri_b + pri_c;
                            if (N % sum != 0)
                                continue;

                            var scale = N / sum;

                            var a = pri_a * scale;
                            var b = pri_b * scale;

                            if (a > b)
                            {
                                var temp = a;
                                a = b;
                                b = temp;
                            }

                            var c = pri_c * scale;

                            Output.Debug("=====================================");
                            Output.Debug("a, b, c, = {0}, {1}, {2}", a, b, c);
                            Output.Debug("=====================================");
                            return (a * b * c).ToString();
                        }

                    }
                }

                return string.Format("There is no Pythagorean number to make a sum of {0}.", N);

            }, "Using Number of primitive Pythagoreans.");
        }

        ulong GCM(ulong a, ulong b, ulong c)
        {
            ulong range = a > b ? b : a;
            ulong gcm = 0;

            for (ulong i = 1; i < range; ++i)
            {
                if (a % i == 0 && b % i == 0 && c % i == 0)
                    gcm = i;
            }

            return gcm;
        }
    }
}
