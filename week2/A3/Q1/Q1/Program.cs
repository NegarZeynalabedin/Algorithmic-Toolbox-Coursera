using System;

namespace Q1
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
            {
                Console.WriteLine(0);
                return;
            }
            if (n == 1)
            {
                Console.WriteLine(1);
                return;
            }
            for (long i = 2; i <= n; i++)
            {
                answer = a + b;
                a = b;
                b = answer;
            }

            Console.WriteLine(answer);
        }
    }
}
