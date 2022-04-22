using System;

namespace Q1
{
    class Program
    {
        static void Main(string[] args)
        {
            string aStr = Console.ReadLine();
            string[] aSpl = aStr.Split();
            long[] a = new long[aSpl.Length];

            for (int i = 0; i < aSpl.Length; i++)
                a[i] = long.Parse(aSpl[i]);


            string bStr = Console.ReadLine();
            string[] bSpl = bStr.Split();
            long[] b = new long[bSpl.Length];

            for (int i = 0; i < bSpl.Length; i++)
                b[i] = long.Parse(bSpl[i]);

            long[] answer = new long[b.Length];
            long high = a.Length - 1;
            long low = 0;

            for (long i = 0; i < b.Length; i++)
                answer[i] = BinarySearch(a, low, high, b[i]);

            Console.WriteLine(answer);

            //string ans = "";
            //for (int i = 0; i < answer.Length; i++)
            //{
            //    if (i == answer.Length - 1)
            //    {
            //        ans += answer[i].ToString();
            //        break;
            //    }
            //    else
            //    {
            //        ans += answer[i].ToString();
            //        ans += " ";
            //    }
            //}

            //Console.WriteLine(ans);
        }

        private static long BinarySearch(long[] a, long low, long high, long v)
        {
            long mid = low + ((high - low) / 2);

            if (low > high)
                return -1;

            if (a[mid] == v)
                return mid;

            else if (v < a[mid])
                return BinarySearch(a, low, mid - 1, v);
            else
                return BinarySearch(a, mid + 1, high, v);

        }
    }
}
