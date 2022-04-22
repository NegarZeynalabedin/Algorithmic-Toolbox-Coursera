using System;

namespace fuel
{
    class Program
    {
        static int Main(string[] args)
        {
            long distance = long.Parse(Console.ReadLine());
            long mostMile = long.Parse(Console.ReadLine());
            long gasStationsNum = long.Parse(Console.ReadLine());

            string locationOfGSInput = Console.ReadLine();
            string[] locationSpl = locationOfGSInput.Split();
            long[] location = new long[gasStationsNum + 2];
            location[0] = 0;
            for (int i = 0; i < gasStationsNum; i++)
                location[i + 1] = long.Parse(locationSpl[i]);
            location[gasStationsNum + 1] = distance;

            if (distance < mostMile)
            {
                Console.WriteLine(0);
                return 0;
            }

            long answer = 0;

            for(int i = 1; i < gasStationsNum + 2; i++)
            {
                if (location[i] > mostMile)
                {
                    long most = location[i - 1];

                    if (most == 0)
                    {
                        Console.WriteLine(-1);
                        return 0;
                    }

                    for (int j = i - 1; j < gasStationsNum + 2; j++)
                        location[j] -= most;

                    answer += 1;

                    i -= 1;
                }
                else if (location[i] == mostMile)
                {
                    long most = location[i];
                    for (int j = i ; j < gasStationsNum + 2; j++)
                        location[j] -= most;

                    answer += 1;

                }
            }
            //-------
            //for (int i = 2; i < gasStationsNum + 2; i++)
            //{
            //    if (location[i] > mostMile)
            //    {
            //        long most = location[i - 1];

            //        if (most > location[i])
            //            Console.WriteLine(-1);

            //        for (int j = i - 1; j < gasStationsNum + 2; j++)
            //            location[j] -= most;


            //        answer += 1;
            //        i -= 1;
            //    }
            //    else if (location[i] == mostMile)
            //    {
            //        long most = location[i];
            //        for (int j = i - 1; j < gasStationsNum + 2; j++)
            //            location[j] -= most;

            //        answer += 1;

            //    }
            //    else
            //        continue;
            //}
      

            Console.WriteLine(answer);
            return 0;
        }
    }
}
