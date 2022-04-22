using System;
using System.Collections.Generic;
using System.Linq;

namespace Q6
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            string numInput = Console.ReadLine();

            string[] numSplit = numInput.Split();
            long[] numbers = new long[numSplit.Length];

            for(int i = 0; i < numSplit.Length; i++)
                numbers[i] = long.Parse(numSplit[i]);

            string answer = null;
            List<long> numbersList = numbers.ToList();
            long check = 0;

            while (numbersList.Count != 0)
            {
                for (int i = 0; i < numbersList.Count - 1; i++)
                {
                    if ((numbersList.First() * Math.Pow(10, numbersList[i + 1].ToString().Length)) + numbersList[i + 1] >=
                        ((numbersList[i + 1] * Math.Pow(10, numbersList.First().ToString().Length)) + numbersList.First()))
                        check = numbersList.First();
                    else
                    {
                        check = numbersList[i + 1];
                        numbersList[i + 1] = numbersList.First();
                        numbersList[0] = check;
                    }
                }

                answer += check;
                numbersList.Remove(check);

                if (numbersList.Count == 1)
                {
                    answer += numbersList[0];
                    break;
                }
            }
            Console.WriteLine(answer);
        }
    }
}
