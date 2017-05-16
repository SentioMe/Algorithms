using Algorithms.Internal;

namespace Project_Euler
{
    public class Q006_Sum_square_difference : IQuestionable<ulong>
    {
        public bool Ask()
        {
            Output.Reset();
            Output.Ask("The sum of the squares of the first ten natural numbers is,\n1 ^ 2 + 2 ^ 2 + ... + 10 ^ 2 = 385\n\nThe square of the sum of the first ten natural numbers is,\n(1 + 2 + ... + 10) ^ 2 = 552 = 3025\n\nHence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 - 385 = 2640.\nFind the difference between the sum of the squares of the first N natural numbers and the square of the sum.");

            return true;
        }

        public ulong[] Arguments { get { return new ulong[] { Input.Decimal("Please enter the natural number N.") }; } }

        public void Answer(ulong[] args)
        {
            Output.Enter();

            var N = args[0];
            /*
             * @note
             *  Sum of k   [k to N] = n(n + 1) / 2
             *  Sum of k^2 [k to N] = n(n + 1)(2n + 1) / 6
             */

            Output.Answer(() =>
            {
                var sigmaK = N * (N + 1) / 2;
                var sigmaSquareK = N * (N + 1) * (2 * N + 1) / 6;

                Output.Debug("=====================================");
                Output.Debug("S1 = k (k to N) = " + sigmaK);
                Output.Debug("S1^2 = " + sigmaK * sigmaK);
                Output.Debug("S2 = k^2 (k to N) = " + sigmaSquareK);
                Output.Debug("=====================================");

                return "S1^2 - S2 = " + (sigmaK * sigmaK - sigmaSquareK);

            }, "Using sigmaK and sigmaK^2");
        }
    }
}
