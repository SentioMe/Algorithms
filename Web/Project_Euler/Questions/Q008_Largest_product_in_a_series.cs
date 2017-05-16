﻿using Algorithms.Internal;
using System.Text;
using System.Collections.Generic;

namespace Project_Euler
{
    public class Q008_Largest_product_in_a_series : IQuestionable<int>
    {
        const string Defined1000digitsValue = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";
        const int SplitTerm = 50;

        public bool Ask()
        {
            var sb = new StringBuilder();
            sb.Append("The four adjacent digits in the 1000-digit number that have the greatest product are 9 × 9 × 8 × 9 = 5832.\n\n");

            for (int i = 0; i < Defined1000digitsValue.Length; i += SplitTerm)
            {
                sb.Append(Defined1000digitsValue.Substring(i, SplitTerm));
                sb.Append("\n");
            }

            sb.Append("\nFind the N adjacent digits in the 1000-digit number that have the greatest product. What is the value of this product?");
            
            Output.Reset();

            Output.Ask(sb.ToString());

            return true;
        }

        public int[] Arguments
        {
            get
            {
                var digits = (ulong)Defined1000digitsValue.Length;
                return new int[] { (int)Input.Decimal("Please enter a natural number N less than 1000-digits.", (A) => A < digits) };
            }
        }

        public void Answer(int[] args)
        {
            Output.Enter();

            var length = Defined1000digitsValue.Length;
            var adjLength = args[0];

            Output.Answer(() =>
            {
                var indices = new int[adjLength];

                var digitList = new List<ulong>(length);
                for (int i = 0; i < length; ++i)
                    digitList.Add(ulong.Parse(Defined1000digitsValue.Substring(i, 1)));

                ulong maxValue = 0;

                for (int i = 0; i < length - adjLength; ++i)
                {
                    ulong value = digitList[i];
                    for (int j = 1; j < adjLength; ++j)
                    {
                        int index = i + j;
                        if (digitList[index] == 0)
                        {
                            i = index;
                            break;
                        }

                        value *= digitList[index];
                    }

                    if (value > maxValue)
                    {
                        maxValue = value;
                        for (int j = 0; j < adjLength; ++j)
                            indices[j] = i + j;
                    }
                }

                Output.Debug("=====================================");
                Output.DebugWithOutLF("{0}", digitList[indices[0]]);
                for (int i = 1; i < adjLength; ++i)
                {
                    Output.DebugWithOutLF(" * {0}", digitList[indices[i]]);
                }
                Output.Debug(" = {0}", maxValue);
                Output.Debug("=====================================");

                return maxValue.ToString();

            }, "Verify that the digit value is 0.");
        }
    }
}
