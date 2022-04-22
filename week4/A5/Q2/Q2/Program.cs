using System;

namespace Q2
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

            if (MajorityElement(a, 0, a.Length - 1) == -1)
                Console.WriteLine(0);
            else
                Console.WriteLine(1);
        }

        private static long MajorityElement(long[] a, long left, long right)
        {
            long mid = left + (right - left) / 2;

            if (left > right)
                return 0;
            if (left == right)
                return a[left];

            long leftMajor = MajorityElement(a, left, mid);
            long rightMajor = MajorityElement(a, mid + 1, right);

            if (leftMajor == -1 && rightMajor != -1)
            {
                long count = Count(a, left, right, rightMajor);
                if (count > (right - left + 1) / 2)
                    return rightMajor;
                else
                    return -1;
            }
            else if (rightMajor == -1 && leftMajor != -1)
            {
                long count = Count(a, left, right, leftMajor);
                if (count > (right - left + 1) / 2)
                    return leftMajor;
                else
                    return -1;
            }
            else if (leftMajor != -1 && rightMajor != -1)
            {
                long lCount = Count(a, left, right, leftMajor);
                long rCount = Count(a, left, right, rightMajor);

                if (lCount > (right - left + 1) / 2)
                    return leftMajor;
                else
                    if (rCount > (right - left + 1) / 2)
                    return rightMajor;
                else
                    return -1;
            }
            else
                return -1;
        }

        private static long Count(long[] a, long left, long right, long v)
        {
            long count = 0;

            for (long i = left; i <= right; i++)
                if (a[i] == v)
                    count++;

            return count;
        }
    }
}
