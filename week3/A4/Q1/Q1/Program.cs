using System;

namespace Q1
{
    class Program
    {
        static void Main(string[] args)
        {
            long money = long.Parse(Console.ReadLine());

            long numbers = 0;
            long reminder = 0;

            //10
            numbers += money / 10;
            reminder += money % 10;

            //5
            numbers += reminder / 5;
            reminder = reminder % 5;

            //1
            numbers += reminder / 1;

            Console.WriteLine(numbers);
        }
    }
}
