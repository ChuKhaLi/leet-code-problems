using System;
using System.Collections.Generic;

namespace _1.TwoSum
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var numbers = new [] {2, 7, 11, 15};
            int target = 9;

            var result = TwoSum(numbers, target);

            Console.WriteLine("[" + string.Join(", ", result) + "]");
            Console.ReadKey();
        }

        private static int[] TwoSum(int[] numbers, int target)
        {
            var remain = new Dictionary<int, int>();
            for (int i = 0, len = numbers.Length; i < len; i++)
            {
                int temp = numbers[i];
                if (remain.ContainsKey(temp))
                {
                    return new [] { remain[temp], i };
                }

                remain[target - temp] = i;
            }

            return new []{0, 0};
        }
    }
}
