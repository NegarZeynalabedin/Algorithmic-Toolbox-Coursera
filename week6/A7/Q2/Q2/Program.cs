using System;
using System.Collections.Generic;
using System.Text;

namespace Q2
{
    class Program
    {
        static void Main(string[] args)
        {
            string souvenirsCountStr = Console.ReadLine();
            long souvenirsCount = long.Parse(souvenirsCountStr);

            string aStr = Console.ReadLine();
            string[] aSplit = aStr.Split();
            long[] souvenirs = new long[souvenirsCount];
            for (int i = 0; i < souvenirsCount; i++)
                souvenirs[i] = long.Parse(aSplit[i]);

            long sum = 0;
            for (int i = 0; i < souvenirs.Length; i++)
                sum += souvenirs[i];

            if (sum % 3 != 0)
            {
                Console.WriteLine(0);
                return;
            }

            if (sum == 0)
            {
                Console.WriteLine(0);
                return;
            }

            long forEvery = sum / 3;

            long[,] arrayDP = new long[forEvery + 1, souvenirsCount + 1];

            for (long i = 0; i <= forEvery; i++)
                arrayDP[i, 0] = 0;

            for (long i = 0; i <= souvenirsCount; i++)
                arrayDP[0, i] = 0;

            for (long i = 1; i <= souvenirsCount; i++)
            {
                for (long j = 1; j <= forEvery; j++)
                {
                    arrayDP[j, i] = arrayDP[j, i - 1];
                    if (souvenirs[i - 1] <= j)
                    {
                        long weight = arrayDP[j - souvenirs[i - 1], i - 1] + souvenirs[i - 1];
                        if (weight > arrayDP[j, i])
                            arrayDP[j, i] = weight;
                    }
                }
            }

            if (arrayDP[forEvery, souvenirsCount] == forEvery)
                Console.WriteLine(1);
            else
                Console.WriteLine(0);
        }
    }
}
