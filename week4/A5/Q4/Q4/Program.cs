using System;

namespace Q4
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

            long answer= MergeSort(n, a);

            Console.WriteLine(answer);
        }

        private static long MergeSort(long n, long[] a)
        {
            long inversion = 0;

            if (n == 1)
                return 0;

            long m = n / 2;
            long[] left = new long[m];
            long[] right = new long[n - m];

            for (int i = 0; i < m; i++)
                left[i] = a[i];

            for (long i = 0; i < n - m; i++)
                right[i] = a[i + m];

            inversion += MergeSort(m, left);
            inversion += MergeSort(n - m, right);

            return Merge(a, left, right) + inversion;
        }

        private static long Merge(long[] a, long[] left, long[] right)
        {
            int indexL = 0;
            int indexR = 0;
            int i = 0;

            long inversion = 0;

            while (indexL != left.Length && indexR != right.Length)
            {
                long checkLeft = left[indexL];
                long checlRight = right[indexR];
                if (checkLeft <= checlRight)
                {
                    a[i] = checkLeft;
                    indexL++;
                }
                else
                {
                    a[i] = checlRight;
                    indexR++;
                    inversion += (left.Length - indexL);
                }
                i++;
            }

            for (; indexL < left.Length; indexL++)
            {
                a[i] = left[indexL];
                i++;
            }

            for (; indexR < right.Length; indexR++)
            {
                a[i] = right[indexR];
                i++;
            }
            return inversion;
        }
    }
}
