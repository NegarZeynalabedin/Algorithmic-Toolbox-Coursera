using System;
using System.Collections.Generic;

namespace Q4
{
    class Program
    {
        static void Main(string[] args)
        {
            long tenantCount = long.Parse(Console.ReadLine());
            List<long> startTimesList = new List<long>();
            List<long> endTimesList = new List<long>();

            for (int j = 0; j < tenantCount; j++)
            {
                string input = Console.ReadLine();
                string[] inputSpl = input.Split();
                startTimesList.Add(long.Parse(inputSpl[0]));
                endTimesList.Add(long.Parse(inputSpl[1]));
            }

            long[] startTimes = startTimesList.ToArray();
            long[] endTimes = endTimesList.ToArray();

            Array.Sort(endTimes, startTimes);
            long check = endTimes[0];
            long count = 0;

            string answer = null;

            int i = 0;
            for (; i < endTimes.Length - 1; i++)
            {
                if ((check >= startTimes[i + 1]) && (check <= endTimes[i + 1]))
                    continue;
                else
                {
                    count++;
                    answer += check.ToString();
                    answer += " ";
                    check = endTimes[i + 1];
                }
            }

            if (i == endTimes.Length - 1)
            {
                count++;
                answer += check.ToString();
            }
            

            Console.WriteLine(count);
            Console.WriteLine(answer);
        }
    }
}
