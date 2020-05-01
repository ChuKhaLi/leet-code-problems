using System;
using System.Linq;

namespace _26.RemoveDuplicatesFromSortedArray
{
    class Program
    {
        /// <summary>
        /// 26. Remove Duplicates from Sorted Array
        /// https://leetcode.com/problems/remove-duplicates-from-sorted-array/
        /// Given a sorted array nums, remove the duplicates in-place such that each element appear only once and return the new length.
        ///  Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var testList = new[]
            {
                new
                {
                    input = new []{ 1, 1, 2 },
                    output = new []{1, 2} 
                },
                new
                {
                    input = new []{ 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 },
                    output = new []{0, 1, 2, 3, 4}
                }
            };

            foreach (var test in testList)
            {
                Console.WriteLine($"input {string.Join(",", test.input)}");

                int len = RemoveDuplicates(test.input);

                var result = string.Join(",", test.input.Take(len));
                var expected = string.Join(",", test.output);

                Console.WriteLine($"result {result}");
                Console.WriteLine($"expected {expected}");
                Console.WriteLine($"success {result.Equals(expected)}");
            }

            Console.ReadKey();
        }

        public static int RemoveDuplicates(int[] numbers)
        {
            if (numbers.Length == 0)
            {
                return 0;
            }

            int len = 0;
            for (int i = 1; i < numbers.Length; i++)
            {
                if(numbers[i] != numbers[len])
                {
                    numbers[++len] = numbers[i];
                }
            }

            return len + 1;
        }
    }
}
