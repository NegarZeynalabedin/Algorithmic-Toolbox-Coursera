using System;
using System.Collections.Generic;
using System.Text;

namespace Q3
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            int numbersCount = (expression.Length / 2) + 1;

            List<int> numbers = new List<int>(numbersCount);
            List<char> opration = new List<char>(numbersCount - 1);

            int[,] arrayDPMin = new int[numbersCount, numbersCount];
            int[,] arrayDPMax = new int[numbersCount, numbersCount];

            for (int i = 0; i < expression.Length; i++)
            {
                if (i % 2 == 0)
                    numbers.Add(int.Parse(expression[i].ToString()));
                else
                    opration.Add(expression[i]);
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                arrayDPMax[i, i] = numbers[i];
                arrayDPMin[i, i] = numbers[i];
            }

            for (int s = 1; s < numbers.Count; s++)
            {
                for (int i = 0; i < numbers.Count - s; i++)
                {
                    int j = i + s;
                    int[] minAndMax = MinAndMax(i, j, opration, arrayDPMax, arrayDPMin);
                    arrayDPMin[i, j] = minAndMax[0];
                    arrayDPMax[i, j] = minAndMax[1];
                }
            }

            Console.WriteLine(arrayDPMax[0, numbers.Count - 1]);
        }

        private static int[] MinAndMax(int i, int j, List<char> opration, int[,] arrayDPMax, int[,] arrayDPMin)
        {
            int min = int.MaxValue;
            int max = int.MinValue;

            long[] arrayOpration = new long[4];

            int[] minAndMax = new int[2];

            for (int k = i; k <= j - 1; k++)
            {
                if (opration[k] == '+')
                    arrayOpration = Opration('+', arrayDPMax, arrayDPMin, i, k, j);
                else if (opration[k] == '-')
                    arrayOpration = Opration('-', arrayDPMax, arrayDPMin, i, k, j);
                else if (opration[k] == '*')
                    arrayOpration = Opration('*', arrayDPMax, arrayDPMin, i, k, j);

                min = (int)Math.Min(min, Math.Min(arrayOpration[0], Math.Min(arrayOpration[1], Math.Min(arrayOpration[2], arrayOpration[3]))));
                max = (int)Math.Max(max, Math.Max(arrayOpration[0], Math.Max(arrayOpration[1], Math.Max(arrayOpration[2], arrayOpration[3]))));
            }

            minAndMax[0] = min;
            minAndMax[1] = max;

            return minAndMax;
        }

        private static long[] Opration(char v, int[,] arrayDPMax, int[,] arrayDPMin, int i, int k, int j)
        {
            long[] answer = new long[4];
            if (v == '+')
            {
                answer[0] = arrayDPMax[i, k] + arrayDPMax[k + 1, j];
                answer[1] = arrayDPMax[i, k] + arrayDPMin[k + 1, j];
                answer[2] = arrayDPMin[i, k] + arrayDPMax[k + 1, j];
                answer[3] = arrayDPMin[i, k] + arrayDPMin[k + 1, j];
            }
            else if (v == '-')
            {
                answer[0] = arrayDPMax[i, k] - arrayDPMax[k + 1, j];
                answer[1] = arrayDPMax[i, k] - arrayDPMin[k + 1, j];
                answer[2] = arrayDPMin[i, k] - arrayDPMax[k + 1, j];
                answer[3] = arrayDPMin[i, k] - arrayDPMin[k + 1, j];
            }
            else
            {
                answer[0] = arrayDPMax[i, k] * arrayDPMax[k + 1, j];
                answer[1] = arrayDPMax[i, k] * arrayDPMin[k + 1, j];
                answer[2] = arrayDPMin[i, k] * arrayDPMax[k + 1, j];
                answer[3] = arrayDPMin[i, k] * arrayDPMin[k + 1, j];
            }
            return answer;
        }
    }
}
