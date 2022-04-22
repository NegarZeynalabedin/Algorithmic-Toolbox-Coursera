using System;
using System.Collections.Generic;
using System.Text;

namespace Q5
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

            long c = long.Parse(Console.ReadLine());
            string seq3In = Console.ReadLine();
            string[] seq3Str = seq3In.Split();
            long[] seq3 = new long[c];
            for (int i = 0; i < c; i++)
                seq3[i] = long.Parse(seq3Str[i]);

            long[,,] lCSArray = new long[seq1.Length + 1, seq2.Length + 1, seq3.Length + 1];

            for (int i = 0; i <= seq1.Length; i++)
                lCSArray[i, 0, 0] = 0;

            for (int i = 0; i <= seq2.Length; i++)
                lCSArray[0, i, 0] = 0;

            for (int i = 0; i <= seq3.Length; i++)
                lCSArray[0, 0, i] = 0;

            for (int i = 1; i <= seq1.Length; i++)
            {
                for (int j = 1; j <= seq2.Length; j++)
                {
                    for (int k = 1; k <= seq3.Length; k++)
                    {
                        if (seq1[i - 1] == seq2[j - 1] && seq2[j - 1] == seq3[k - 1])
                            lCSArray[i, j, k] = lCSArray[i - 1, j - 1, k - 1] + 1;
                        else
                            lCSArray[i, j, k] = Math.Max(lCSArray[i - 1, j, k], Math.Max(lCSArray[i, j - 1, k], lCSArray[i, j, k - 1]));
                    }
                }
            }
            Console.WriteLine(lCSArray[seq1.Length, seq2.Length, seq3.Length]);
        }
    }
}
