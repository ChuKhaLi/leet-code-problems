using System;

namespace _03.MaximumSubarray
{
    class Program
    {
        /// <summary>
        /// Day 03. Maximum Sub-array
        /// Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.
        /// Example:
        /// Input: [-2,1,-3,4,-1,2,1,-5,4],
        /// Output: 6
        /// Explanation: [4,-1,2,1] has the largest sum = 6.
        /// Follow up:
        /// If you have figured out the O(n) solution, try coding another solution using the divide and conquer approach, which is more subtle.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var testList = new[]
            {
                new
                {
                    input = new []{ -2, 1, -3, 4, -1, 2, 1, -5, 4 },
                    output = 6
                },
                new
                {
                    input = new []{ -2, 1},
                    output = 1
                }
            };

            foreach (var test in testList)
            {
                int result = MaxSubArrayV2(test.input);

                Console.WriteLine($"input {string.Join(",", test.input)}");
                Console.WriteLine($"expected {test.output}");
                Console.WriteLine($"output {result}");
                Console.WriteLine($"success {result == test.output}");
            }


            Console.ReadKey();
        }


        // Bru-force
        public static int MaxSubArray(int[] numbers)
        {
            int maxSum = numbers[0], len = numbers.Length;

            for (int i = 0; i < len; i++)
            {
                for (int j = i; j < len; j++)
                {
                    int sum = 0;
                    for (int k = i; k <= j; k++)
                    {
                        sum += numbers[k];
                    }

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                    }
                }
            }

            return maxSum;
        }

        //Kadane's algorithm
        public static int MaxSubArrayV2(int[] numbers)
        {
            int currentSum = 0, maxSum = int.MinValue, len = numbers.Length;

            for (int i = 0; i < len; i++)
            {
                currentSum += numbers[i];

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }

                if (currentSum < 0)
                {
                    currentSum = 0;
                }
            }

            return maxSum;
        }
    }
}
