using System;
using System.Collections.Generic;
using System.Text;

namespace Q1
{
    class Program
    {
        static void Main(string[] args)
        {
            long money = long.Parse(Console.ReadLine());

            int[] coins = new int[] { 1, 3, 4 };

            long[] minCoins = new long[money + 1];
            long numCoins = 0;

            minCoins[0] = 0;

            for (int m = 1; m <= money; m++)
            {
                minCoins[m] = long.MaxValue;
                for (long i = 0; i < coins.Length; i++)
                {
                    if (m >= coins[i])
                    {
                        numCoins = minCoins[m - coins[i]] + 1;
                        if (numCoins < minCoins[m])
                            minCoins[m] = numCoins;
                    }
                }
            }
            Console.WriteLine(minCoins[money]);            
        }
    }
}
