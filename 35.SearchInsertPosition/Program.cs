using System;

namespace _35.SearchInsertPosition
{
    class Program
    {
        /// <summary>
        /// 35. Search Insert Position
        /// https://leetcode.com/problems/search-insert-position/
        /// Given a sorted array and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        /// You may assume no duplicates in the array.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var testList = new[]
            {
                new
                {
                    input = new []{1, 2, 5, 6},
                    target = 5,
                    output = 2
                },
                new
                {
                    input = new []{1, 2, 5, 6},
                    target = 2,
                    output = 1
                },
                new
                {
                    input = new []{1, 2, 5, 6},
                    target = 7,
                    output = 4
                },
                new
                {
                    input = new []{1, 2, 5, 6},
                    target = 0,
                    output = 0
                },
                new
                {
                    input = new []{1, 3, 5},
                    target = 4,
                    output = 2
                }
            };

            foreach (var test in testList)
            {
                int result = SearchInsert(test.input, test.target);
                Console.WriteLine($"input {string.Join(", " , test.input)}\ntarget {test.target}");
                Console.WriteLine($"result {result}\nexpected {test.output}");
                Console.WriteLine($"success {result == test.output}");
            }

            Console.ReadKey();
        }

        public static int SearchInsert(int[] numbers, int target)
        {
            int len = numbers.Length;

            for (int i = 0; i < len; i++)
            {
                if (numbers[i] >= target)
                {
                    return i;
                }
            }

            return len;
        }
    }
}
