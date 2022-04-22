using System;
using System.Linq;

namespace Q3
{
    class Program
    {
        static void Main(string[] args)
        {
            long slotCount = long.Parse(Console.ReadLine());

            string firstLine = Console.ReadLine();
            string[] firstLineSpl = firstLine.Split();
            long[] adRevenue = new long[slotCount];

            string secondLine = Console.ReadLine();
            string[] secondLineSpl = secondLine.Split();
            long[] averageDailyClick = new long[slotCount];

            for (int i = 0; i < slotCount; i++)
            {
                adRevenue[i] = long.Parse(firstLineSpl[i]);
                averageDailyClick[i] = long.Parse(secondLineSpl[i]);
            }

            long answer = 0;

            for (int i = 0; i < slotCount; i++)
            {
                answer += adRevenue.Max() * averageDailyClick.Max();
                adRevenue[adRevenue.ToList().IndexOf(adRevenue.Max())] = long.MinValue;
                averageDailyClick[averageDailyClick.ToList().IndexOf(averageDailyClick.Max())] = long.MinValue;
            }

            Console.WriteLine(answer);
        }
    }
}
