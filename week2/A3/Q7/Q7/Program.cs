using System;
using System.Collections.Generic;

namespace Q7
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

            if(a==0 && b==0)
            {
                Console.WriteLine(0);
                return;
            }

            if(a==0 && b !=0)
            {
                List<int> theLastDigitSum = new List<int>();
                theLastDigitSum.Add(0);
                theLastDigitSum.Add(1);
                theLastDigitSum.Add(2);

                while (true)
                {
                    if (theLastDigitSum[theLastDigitSum.Count - 1] == 1)
                        if (theLastDigitSum[theLastDigitSum.Count - 2] == 0)
                            break;

                    theLastDigitSum.Add((theLastDigitSum[theLastDigitSum.Count - 1] + theLastDigitSum[theLastDigitSum.Count - 2] + 1) % 10);
                }
                long listTheLastDigitSum = theLastDigitSum.Count - 2;

                Console.WriteLine(theLastDigitSum[(int)(b % listTheLastDigitSum)]);
                return;
            }

            if (b > a)
            {
                var tmp = b;
                b = a;
                a = tmp;
            }

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

            if ((theLastDigit[(int)(a % listTheLastDigit)] - theLastDigit[(int)((b % listTheLastDigit) - 1)]) < 0)
                Console.WriteLine(theLastDigit[(int)(a % listTheLastDigit)] - theLastDigit[(int)((b % listTheLastDigit) - 1)] + 10);
            else
                Console.WriteLine(theLastDigit[(int)(a % listTheLastDigit)] - theLastDigit[(int)((b % listTheLastDigit) - 1)]);
        }
    }
}
