using System;
using System.Collections.Generic;
using System.Text;

namespace Q3
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();

            long insertion = 0;
            long deletion = 0;
            long match = 0;
            long misMatch = 0;

            long[,] editDistanceArray = new long[str1.Length + 1, str2.Length + 1];

            char[] str1Array = str1.ToCharArray();
            char[] str2Array = str2.ToCharArray();

            for (long i = 0; i <= str1.Length; i++)
                editDistanceArray[i, 0] = i;
            for (long i = 0; i <= str2.Length; i++)
                editDistanceArray[0, i] = i;

            for (long j = 1; j <= str2.Length; j++)
            {
                for (long i = 1; i <= str1.Length; i++)
                {
                    insertion = editDistanceArray[i, j - 1] + 1;
                    deletion = editDistanceArray[i - 1, j] + 1;
                    match = editDistanceArray[i - 1, j - 1];
                    misMatch = editDistanceArray[i - 1, j - 1] + 1;

                    long minInserAndDelet = Math.Min(insertion, deletion);

                    if (str1Array[i - 1] == str2Array[j - 1])
                        editDistanceArray[i, j] = Math.Min(minInserAndDelet, match);
                    else
                        editDistanceArray[i, j] = Math.Min(minInserAndDelet, misMatch);
                }
            }
            Console.WriteLine(editDistanceArray[str1.Length, str2.Length]);
        }
    }
}
