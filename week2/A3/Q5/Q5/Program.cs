using System;
using System.Collections.Generic;

namespace Q5
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

            List<long> reminder = new List<long>();
            reminder.Add(0);
            reminder.Add(1);
            reminder.Add(1);

            while (true)
            {
                if (reminder[reminder.Count - 1] == 1)
                    if (reminder[reminder.Count - 2] == 0)
                        break;

                reminder.Add((reminder[reminder.Count - 1] + reminder[reminder.Count - 2]) % b);
            }

            long period = reminder.Count - 2;

            Console.WriteLine(reminder[(int)(a % period)]);
        }
    }
}
