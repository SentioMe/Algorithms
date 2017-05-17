
namespace Algorithms.Internal
{
    public static class DecimalExtends
    {
        public static string ToOrdinal(this ulong number)
        {
            const string TH = "th";
            string s = number.ToString();

            if (number < 1)
                return s;

            number %= 100;
            if ((number >= 11) && (number <= 13))
                return s + TH;

            switch (number % 10)
            {
                case 1: return s + "st";
                case 2: return s + "nd";
                case 3: return s + "rd";
                default: return s + TH;
            }
        }

        
    }

    public static class MathExtends
    {
        public static ulong SigmaK_ToN(ulong n) { return n * (n + 1) / 2; }
        public static ulong SigmaSqureK_ToN(ulong n) { return n * (n + 1) * (2 * n + 1) / 6; }

        public static bool IsPrimeNumber(ulong value, ulong range)
        {
            for (ulong i = 2; i <= range; ++i)
                if (value % i == 0)
                    return false;

            return true;
        }
    }
}
