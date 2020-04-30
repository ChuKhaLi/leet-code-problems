using System;
using System.Collections.Generic;
using System.Linq;

namespace _27.RemoveElement
{
    class Program
    {
        /// <summary>
        /// 27. Remove Element
        /// https://leetcode.com/problems/remove-element/
        /// Given an array numbers and a value val, remove all instances of that value in-place and return the new length.
        /// Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.
        /// The order of elements can be changed. It doesn't matter what you leave beyond the new length.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var testList = new[]
            {
                new
                {
                    array = new int[] {3, 2, 2, 3},
                    val = 3,
                    result = new int[] {2, 2}
                },
                new
                {
                    array = new int[] {0, 1, 2, 2, 3, 0, 4, 2},
                    val = 2,
                    result = new int[] {0, 1, 3, 0, 4}
                }
            };

            foreach (var test in testList)
            {
                var len = RemoveElement(test.array, test.val);
                var result = new HashSet<int>(test.array.Take(len));
                var expected = new HashSet<int>(test.result);

                Console.WriteLine($"result {string.Join(",", test.array.Take(len))}");
                Console.WriteLine($"expected {string.Join(",", test.result)}");
                Console.WriteLine($"success {result.SetEquals(expected)}");
            }

            Console.ReadKey();
        }

        public static int RemoveElement(int[] numbers, int val)
        {
            int len = numbers.Length;

            for (int i = len - 1; i >= 0; i--)
            {
                if (numbers[i] != val)
                {
                    continue;
                }

                numbers[i] = numbers[len - 1];
                len--;
            }

            return len;
        }
    }
}
