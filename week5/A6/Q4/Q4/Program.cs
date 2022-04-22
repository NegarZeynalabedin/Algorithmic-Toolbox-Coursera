using System;
using System.Collections.Generic;
using System.Text;

namespace Q4
{
    class Program
    {
        static void Main(string[] args)
        {
            long a = long.Parse(Console.ReadLine());
            string seq1In = Console.ReadLine();
            string[] seq1Str = seq1In.Split();
            long[] seq1 = new long[a];
            for (int i = 0; i < a; i++)
                seq1[i] = long.Parse(seq1Str[i]);

            long b = long.Parse(Console.ReadLine());
            string seq2In = Console.ReadLine();
            string[] seq2Str = seq2In.Split();
            long[] seq2 = new long[b];
            for (int i = 0; i < b; i++)
                seq2[i] = long.Parse(seq2Str[i]);

            long[,] lCSArray = new long[a + 1, b + 1];

            for (int i = 0; i <= a; i++)
                lCSArray[i, 0] = 0;

            for (int i = 0; i <= b; i++)
                lCSArray[0, i] = 0;

            for (int i = 1; i <= a; i++)
            {
                for (int j = 1; j <= b; j++)
                {
                    if (seq1[i - 1] == seq2[j - 1])
                        lCSArray[i, j] = lCSArray[i - 1, j - 1] + 1;
                    else
                        lCSArray[i, j] = Math.Max(lCSArray[i - 1, j], lCSArray[i, j - 1]);
                }
            }

            Console.WriteLine(lCSArray[seq1.Length, seq2.Length]);
        }
    }
}
