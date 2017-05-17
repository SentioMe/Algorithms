using Algorithms.Internal;

namespace Project_Euler
{
    public class Q006_Sum_square_difference : QuestionAbstract<ulong>
    {
        public override ulong[] Arguments { get { return new ulong[] { Input.Decimal("Please enter the natural number N.") }; } }

        public override void Answer(ulong[] args)
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
                var sigmaK = MathExtends.SigmaK_ToN(N);
                var sigmaSquareK = MathExtends.SigmaSqureK_ToN(N);

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
