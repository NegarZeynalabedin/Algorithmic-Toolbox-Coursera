using System;
using System.Collections.Generic;

namespace Q8
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            if(n==0)
            {
                Console.WriteLine(0);
                return;
            }

            List<long> listTheLastDigit = new List<long>();
            listTheLastDigit.Add(0);
            listTheLastDigit.Add(1);
            listTheLastDigit.Add(1);

            while (true)
            {
                if (listTheLastDigit[listTheLastDigit.Count - 1] == 1)
                    if (listTheLastDigit[listTheLastDigit.Count - 2] == 0)
                        break;

                listTheLastDigit.Add((listTheLastDigit[listTheLastDigit.Count - 1] + listTheLastDigit[listTheLastDigit.Count - 2]) % 10);
            }
            long period = listTheLastDigit.Count - 2;

            Console.WriteLine(((listTheLastDigit[((int)((n - 1) % period))] + listTheLastDigit[(int)(n % period)]) * listTheLastDigit[(int)(n % period)]) % 10);
        }
    }
}
