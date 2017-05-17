using Algorithms.Internal;

namespace Project_Euler
{
    public class Q001_Multiples_of_X_and_Y : QuestionAbstract<ulong>
    {
        public override ulong[] Arguments
        {
            get
            {
                ulong N = Input.Decimal("Please enter the natural number N.");
                var args = new ulong[] {
                N,
                Input.Decimal("Please enter a natural number X less than N.", (X) => X < N),
                Input.Decimal("Please enter a natural number Y less than N.", (Y) => Y < N)};

                return args;
            }
        }

        public override void Answer(ulong[] args)
        {
            Output.Enter();

            ulong N = args[0];
            ulong X = args[1];
            ulong Y = args[2];

            Output.Answer(() =>
            {
                ulong sum = 0;
                for (ulong i = 1; i < N; ++i)
                {
                    if (i % X == 0 || i % Y == 0)
                        sum += i;
                }

                return sum.ToString();

            }, "Routing, O (n)");

            Output.Enter();

            Output.Answer(() =>
            {
                ulong sum = SumOfMultiplies(N, X) + SumOfMultiplies(N, Y) - SumOfMultiplies(N, LCM(X, Y));
                return sum.ToString();

            }, "Sum of multiplies X + Sum of multiplies Y - Sum of multiplies LCM");
        }

        ulong SumOfMultiplies(ulong n, ulong d)
        {
            ulong sum = 0;
            for (ulong i = d; i < n; i += d)
                sum += i;

            return sum;
        }
        ulong GCD(ulong x, ulong y) { return y == 0 ? x : GCD(y, x % y); }
        ulong LCM(ulong x, ulong y) { return (x * y) / GCD(x, y); }
    }
}
