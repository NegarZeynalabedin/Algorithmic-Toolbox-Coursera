using System;
using System.Collections.Generic;

namespace Q5
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            List<long> prizes = new List<long>();
            long check = 0;

            for (int i = 1; check < n; i++)
            {
                if (check + i <= n)
                {
                    prizes.Add(i);
                    check += i;
                }
                else
                {
                    prizes[i - 2] += (n - check);
                    break;
                }
            }
            Console.WriteLine(prizes.Count);

            string output = null;
            for (int i = 0; i < prizes.Count; i++)
            {
                output += prizes[i];
                if(i!=prizes.Count-1)
                    output += " ";
            }

            Console.WriteLine(output);
                
        }
    }
}
