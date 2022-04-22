using System;
using System.Collections.Generic;
using System.Linq;

namespace Q2
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstLine = Console.ReadLine();
            string[] firstLineSpl = firstLine.Split();
            long count = long.Parse(firstLineSpl[0]);
            long capacity = long.Parse(firstLineSpl[1]);

            List<long> weightsList = new List<long>();
            List<long> valuesList = new List<long>();

            for(int i = 0; i < count; i++)
            {
                string lootLine = Console.ReadLine();
                string[] lootSpl = lootLine.Split();

                valuesList.Add(long.Parse(lootSpl[0]));
                weightsList.Add(long.Parse(lootSpl[1]));

            }

            long[] weights = weightsList.ToArray();
            long[] values = valuesList.ToArray();

            //---
            double[] valuable = new double[values.Length];
            double answer = 0;

            for (int i = 0; i < values.Count(); i++)
            {
                valuable[i] = (double)values[i] / (double)weights[i];
            }

            while (capacity != 0)
            {
                int indexMax = valuable.ToList().IndexOf(valuable.Max());


                if (capacity - weights[indexMax] >= 0)
                {
                    capacity -= weights[indexMax];
                    answer += values[indexMax];

                    valuable[indexMax] = 0;
                }
                else
                {
                    answer += ((float)capacity * ((float)values[indexMax] / weights[indexMax]));
                    capacity = 0;
                    values[indexMax] = 0;
                }


            }
            Console.WriteLine(Math.Round(answer,4));
        }
    }
}
