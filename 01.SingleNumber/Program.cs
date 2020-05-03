using System;

namespace _01.SingleNumber
{
    class Program
    {
        /// <summary>
        /// Day 01 Single Number
        /// Given a non-empty array of integers, every element appears twice except for one. Find that single one.
        /// Note:
        /// Your algorithm should have a linear runtime complexity.Could you implement it without using extra memory?
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var testList = new[]
            {
                new
                {
                    input = new[] {1, 2, 3, 3, 1},
                    output = 2
                }
            };

            foreach (var test in testList)
            {
                Console.WriteLine($"input {string.Join(",", test.input)}");
                Console.WriteLine($"output {SingleNumber(test.input)}");
                Console.WriteLine($"expected {test.output}");
            }

            Console.ReadKey();
        }

        public static int SingleNumber(int[] numbers)
        {
            for (int i = 1; i < numbers.Length; i++)
            {
                numbers[0] ^= numbers[i];
            }

            return numbers[0];
        }
    }
}
