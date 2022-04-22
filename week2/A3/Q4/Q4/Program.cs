using System;

namespace Q4
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] inputStr = input.Split();
            long[] inputLong = new long[inputStr.Length];

            for (int i = 0; i < inputStr.Length; i++)
                inputLong[i] = long.Parse(inputStr[i]);

            long a = inputLong[0];
            long b = inputLong[1];

            long gcd = GCD(a, b);

            Console.WriteLine((a*b)/gcd);

        }

        private static long GCD(long a, long b)
        {
            long reminder = a;

            if (b > a)
            {
                var tmp = b;
                b = a;
                a = tmp;
            }

            while (reminder != 0)
            {
                reminder = a % b;
                a = b;
                b = reminder;
            }
            return a;
        }
    }
}
