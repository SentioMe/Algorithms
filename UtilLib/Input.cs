using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Algorithms.Internal
{
    public static class Input
    {
        static readonly Dictionary<Regex, string> _replacements;

        static Input()
        {
            _replacements = new Dictionary<Regex, string>()
            {
                { new Regex("value\\([^)]*\\)\\."), string.Empty },
                { new Regex("\\(\\)\\."), string.Empty },
                { new Regex("^[^)]*\\ =>"), string.Empty },
                { new Regex("Not"), "!" }
            };
        }

        public static string String(string message)
        {
            Console.WriteLine(message);
            string result = Console.ReadLine();

            return result;
        }

        public static ulong Decimal(string message)
        {
            Console.WriteLine(message);

            ulong result = 0;

            string read = Console.ReadLine();
            if (ulong.TryParse(read, out result) == false)
                throw new InvalidCastException("\nYou entered value that can not be converted to ulong type.\nRead value is " + read);

            return result;
        }

        public static ulong Decimal(string message, Expression<Func<ulong, bool>> condition)
        {
            ulong result = Decimal(message);

#if DEBUG
            if (condition.Compile()(result) == false)
            {
                string assertion = condition.ToString();
                foreach (var pattern in _replacements)
                    assertion = pattern.Key.Replace(assertion, pattern.Value);

                throw new Exception(string.Format("\nThe entered value violates the condition of '{0}'\nRead value is {1}", assertion.Trim(), result.ToString()));
            }
#endif
            return result;
        }

    }
}
