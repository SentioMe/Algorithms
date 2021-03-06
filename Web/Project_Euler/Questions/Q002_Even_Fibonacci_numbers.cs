﻿using Algorithms.Internal;
using System;

namespace Project_Euler
{
    public class Q002_Even_Fibonacci_numbers : QuestionAbstract<ulong>
    {
        public struct Mat2x2
        {
            private ulong[,] _elements;
            public ulong this[ulong r, ulong c]
            {
                get { return _elements[r, c]; }
                set { _elements[r, c] = value; }
            }

            public Mat2x2(ulong _00, ulong _01, ulong _10, ulong _11)
            {
                _elements = new ulong[,]
                {
                    { _00, _01 },
                    { _10, _11 }
                };
            }

            public static Mat2x2 operator *(Mat2x2 a, Mat2x2 b)
            {
                /*
                 * @note
                 * Multiple with 2by2 matrix
                 * 
                 * |a, b| X |e, f| = |ae + bg, af + bh|
                 * |c, d|   |g, h|   |ce + dg, cf + dh|
                 */

                return new Mat2x2(
                    a[0, 0] * b[0, 0] + a[0, 1] * b[1, 0], a[0, 0] * b[0, 1] + a[0, 1] * b[1, 1],
                    a[1, 0] * b[0, 0] + a[1, 1] * b[1, 0], a[1, 0] * b[0, 1] + a[1, 1] * b[1, 1]);
            }
        }

        static Mat2x2 FibonacciMatrix = new Mat2x2(1, 1, 1, 0);
        
        public override ulong[] Arguments { get { return new ulong[] { Input.Decimal("Please enter the natural number N.") }; } }

        public override void Answer(ulong[] args)
        {
            Output.Enter();
            
            var N = args[0];

            Output.Answer(() =>
            {
                var fPair = new Tuple<ulong, ulong>(1, 2);
                ulong sum = 0;

                while (fPair.Item2 <= N)
                {
                    if (fPair.Item2 % 2 == 0)
                        sum += fPair.Item2;

                    fPair = new Tuple<ulong, ulong>(fPair.Item2, fPair.Item1 + fPair.Item2);
                }

                return sum.ToString();

            }, "Routing");

            Output.Enter();

            Output.Answer(() =>
            {
                /*
                 * @note
                 * ~kr : F0 = 1, F1 = 1, Fn = Fn-1 + Fn-2로 정의되는 피보나치 수열에서 F2 = 2가 됩니다
                 *       두 수의 합이 짝수이기 위해선 두 수가 모두 홀수거나 짝수여야 하는데,
                 *       피보나치의 특성 상 홀수, 홀수, 짝수가 반복됩니다(즉, 2 + 3n단위로 발생)
                 *       이 때문에 행렬의 제곱으로 임의의 N번째 피보나치 수를 계산할 때 짝수가 되는 항만을 계산합니다.
                 * ~jp : F0=1、F1= 1、Fn= Fn-1 + Fn-2で定義されているフィボナッチ数列で、F2=2となります。
                 *      　二つの数の合計が偶数であるためには、両方がすべて奇数、または偶数である必要があります。
                 *      　1と1で始まったフィボナッチ数列では、結局、最初に偶数が出る2から3n単位で偶数が発生します。
                 *      　このため、行列の乗法で任意のN番目のフィボナッチ数を計算する時に偶数となる番だけを計算します。
                 */
                const ulong EvenTerm = 3;

                ulong current = EvenTerm;
                ulong sum = 0;
                ulong value = 0;

                while ((value = Fibonacci(current)) <= N)
                {
                    current += EvenTerm;
                    sum += value;
                }

                return sum.ToString();
            }, "Calcurate with matrix");
        }

        ulong Fibonacci(ulong n)
        {
            if (n < 2)
                return n;
            /*   |Fn+2|   |1 1| |Fn+1|
             *   |Fn+1| = |1 0| | Fn |
             *   
             *   |Fn+1 Fn  |   |1 1|n
             *   |Fn   Fn-1| = |1 0|
             */

            var result = FibonacciMatrix;

            for (ulong i = 1; i < n; ++i)
                result = FibonacciMatrix * result;

            return result[0, 1];
        }
    }
}
