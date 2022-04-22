using System;

namespace Q2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long a = 0;
            long b = 1;

            long answer = 0;

            if (n == 0)
                Console.WriteLine(0);
            if (n == 1)
                Console.WriteLine(1);

            for (long i = 2; i <= n; i++)
            {
                answer = a + b;
                if (answer > 9)
                    answer = answer % 10;
                a = b;
                b = answer;
            }

            Console.WriteLine(answer);
        }
    }
}
