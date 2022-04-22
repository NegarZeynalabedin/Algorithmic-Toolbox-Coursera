using System;
using System.Linq;

namespace Q3
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            string aStr = Console.ReadLine();
            string[] aSpl = aStr.Split();
            long[] a = new long[aSpl.Length];
            for (int i = 0; i < aSpl.Length; i++)
                a[i] = long.Parse(aSpl[i]);

            QuickSort(a, 0, n - 1);

            //string ans = "";
            //for (int i = 0; i < a.Length; i++)
            //{
            //    if (i == a.Length - 1)
            //    {
            //        ans += a[i].ToString();
            //        break;
            //    }
            //    else
            //    {
            //        ans += a[i].ToString();
            //        ans += " ";
            //    }
            //}

            

            Console.WriteLine(string.Join(" ", a));
        }

        private static void QuickSort(long[] a, long l, long r)
        {
            if (l >= r)
                return;

            long[]arr = Partition(a, l, r);

            QuickSort(a, l, arr[0] - 1);
            QuickSort(a, arr[1] + 1, r);
        }

        private static long [] Partition(long[] a, long l, long r)
        {
            long check = a[l];

            long j = l;
            long k = l;

            for (long i = l + 1; i <= r; i++)
            {
                if (a[i] < check)
                {
                    k++;
                    Swap(a, i, k);
                    j++;
                    Swap(a, k, j);
                }
                else if (a[i] == check)
                {
                    k++;
                    Swap(a, i, k);
                }
            }
            Swap(a, l, j);
            long[] arr = { j + 1, k };
            return arr;
        }

        private static void Swap(long[] a, long k, long j)
        {
            long swap = a[k];
            a[k] = a[j];
            a[j] = swap;
        }
    }
}
