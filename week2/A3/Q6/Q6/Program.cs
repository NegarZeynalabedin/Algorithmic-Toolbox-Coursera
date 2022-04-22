using System;
using System.Collections.Generic;

namespace Q6
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            List<int> theLastDigit = new List<int>();
            theLastDigit.Add(0);
            theLastDigit.Add(1);
            theLastDigit.Add(2);

            while (true)
            {
                if (theLastDigit[theLastDigit.Count - 1] == 1)
                    if (theLastDigit[theLastDigit.Count - 2] == 0)
                        break;

                theLastDigit.Add((theLastDigit[theLastDigit.Count - 1] + theLastDigit[theLastDigit.Count - 2] + 1) % 10);
            }
            long listTheLastDigit = theLastDigit.Count - 2;

            Console.WriteLine(theLastDigit[(int)(n % listTheLastDigit)]);
        }
    }
}
