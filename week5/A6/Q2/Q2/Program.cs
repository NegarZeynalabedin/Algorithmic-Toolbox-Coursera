using System;
using System.Collections.Generic;
using System.Text;

namespace Q2
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            long[] arrayDP = new long[n + 1];
            long[] check = new long[3];

            long minCalculate = 0;

            arrayDP[0] = 0;
            arrayDP[1] = 0;

            for (int i = 2; i < arrayDP.Length; i++)
            {
                check[0] = long.MaxValue;
                check[1] = long.MaxValue;
                check[2] = long.MaxValue;

                if (i % 3 == 0)
                    check[0] = arrayDP[i / 3] + 1;

                if (i % 2 == 0)
                    check[1] = arrayDP[i / 2] + 1;

                check[2] = arrayDP[i - 1] + 1;

                arrayDP[i] = Math.Min(check[0], Math.Min(check[1], check[2]));
            }
            minCalculate = arrayDP[n];

            long[] answer = new long[minCalculate + 1];
            answer[0] = n;

            for (int i = 1; i <= minCalculate; i++)
            {
                if (n % 3 == 0 && (arrayDP[n / 3] + 1 == arrayDP[n]))
                {
                    answer[i] = n / 3;
                    n = (n / 3);
                }
                else
                if (n % 2 == 0 && (arrayDP[n / 2] + 1 == arrayDP[n]))
                {
                    answer[i] = n / 2;
                    n = (n / 2);
                }
                else
                {
                    answer[i] = n - 1;
                    n -= 1;
                }
            }
            Array.Reverse(answer);
            Console.WriteLine(answer.Length - 1);
            Console.WriteLine(answer);
        }
    }
}
