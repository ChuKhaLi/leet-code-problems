using System;

namespace _5402.LongestContinuousSubarray
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] {4, 2, 2, 2, 4, 4, 2, 2};
            int limit = 0;
            var result = LongestSubarray(nums, limit);
            Console.WriteLine(result);

            Console.ReadKey();
        }

        public static int LongestSubarray(int[] nums, int limit)
        {
            int currentSize = 0, min , max;
            int i = 0, j = 0, n = nums.Length;

            while (i < n && j < n)
            {
                min = int.MaxValue;
                max = int.MinValue;

                for (int k = i; k <= j; k++)
                {
                    if (nums[k] < min)
                    {
                        min = nums[k];
                    }

                    if (nums[k] > max)
                    {
                        max = nums[k];
                    }
                }

                if (max - min <= limit)
                {
                    currentSize = Math.Max(currentSize, j - i + 1);
                    j++;

                    continue;
                }

                i++;
            }

            return currentSize;
        }
    }
}
