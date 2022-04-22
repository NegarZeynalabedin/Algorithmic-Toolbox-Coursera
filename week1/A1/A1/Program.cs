using System;

namespace A1
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputStr = Console.ReadLine();
            string[] inputSpl = inputStr.Split();
            int[] input = new int[2];
            for (int i = 0; i < 2; i++)
                input[i] = int.Parse(inputSpl[i]);

            int output = input[0] + input[1];
            Console.WriteLine(output);
        }
    }
}
