using System;
using System.Diagnostics;

namespace Algorithms.Internal
{
    public static class Output
    {
        static int MethodFlag = 1;

        public static void Reset()
        {
            MethodFlag = 1;
        }

        public static void Ask(string message)
        {
            var stackTrace = new StackTrace();
            var methodBase = stackTrace.GetFrame(1).GetMethod();
            var Class = methodBase.ReflectedType;

            Console.WriteLine("-{0}-", Class.Name);
            Console.WriteLine(message);

            Enter();
        }

        public static void Answer(Func<string> onAnswer, string desc)
        {
            Stopwatch sw = new Stopwatch();

            int number = MethodFlag++;

            Console.WriteLine("Method{0:D2} : {1}", number, desc);

            sw.Start();
            Console.WriteLine("Answer{0:D2} : {1}", number, onAnswer());
            sw.Stop();

            Console.WriteLine("Time  {0:D2} : {1}sec", number, sw.Elapsed.TotalSeconds);

            sw = null;
        }

        public static void Enter() { Console.WriteLine(); }

        [Conditional("DEBUG")]
        public static void Debug(string message) { Console.WriteLine(message); }
        [Conditional("DEBUG")]
        public static void DebugWithOutLF(string message) { Console.Write(message); }
        [Conditional("DEBUG")]
        public static void Debug(string format, params object[] args) { Console.WriteLine(format, args); }
        [Conditional("DEBUG")]
        public static void DebugWithOutLF(string format, params object[] args) { Console.Write(format, args); }
    }
}
