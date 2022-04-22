using System;
using System.Collections.Generic;
using System.Text;

namespace Q1
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            string[] aStr = a.Split();
            long W = long.Parse(aStr[0]);
            long lenghtOfGoldBars = long.Parse(aStr[1]);

            string b = Console.ReadLine();
            string[] bStr = b.Split();
            long[] goldBars = new long[lenghtOfGoldBars];
            for (int i = 0; i < lenghtOfGoldBars; i++)
                goldBars[i] = long.Parse(bStr[i]);

            long[,] arrayDP = new long[W + 1, goldBars.Length + 1];

            for (long i = 0; i <= W; i++)
                arrayDP[i, 0] = 0;

            for (long i = 0; i <= goldBars.Length; i++)
                arrayDP[0, i] = 0;

            for (long i = 1; i <= goldBars.Length; i++)
            {
                for (long j = 1; j <= W; j++)
                {
                    arrayDP[j, i] = arrayDP[j, i - 1];
                    if (goldBars[i - 1] <= j)
                    {
                        long weight = arrayDP[j - goldBars[i - 1], i - 1] + goldBars[i - 1];
                        if (weight > arrayDP[j, i])
                            arrayDP[j, i] = weight;
                    }
                }
            }
            Console.WriteLine(arrayDP[W, goldBars.Length]);
        }
    }
}
