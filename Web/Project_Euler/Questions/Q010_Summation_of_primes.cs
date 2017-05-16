﻿using Algorithms.Internal;
using System.Collections.Generic;

namespace Project_Euler
{
    public class Q010_Summation_of_primes : IQuestionable<ulong>
    {
        public bool Ask()
        {
            Output.Reset();
            Output.Ask("The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.\nFind the sum of all the primes below N.");

            return true;
        }

        public ulong[] Arguments { get { return new ulong[] { Input.Decimal("Please enter the natural number N.") }; } }

        public void Answer(ulong[] args)
        {
            Output.Enter();

            var N = args[0];

            Output.Answer(() =>
            {
                var primeList = new List<ulong>();
                primeList.Add(2);

                ulong cur = 3;

                while (cur < N)
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

                ulong sum = 0;
                for (int i = 0; i < primeList.Count; ++i)
                    sum += primeList[i];

                return string.Format("{0}(There are {1} prime numbers below {2}.)", sum, primeList.Count, N);

            }, "Using Q007");
        }
    }
}
