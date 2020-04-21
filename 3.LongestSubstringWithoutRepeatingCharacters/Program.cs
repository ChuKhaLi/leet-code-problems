using System;
using System.Collections.Generic;
using System.Text;

namespace _3.LongestSubstringWithoutRepeatingCharacters
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string s = "abc";

            Console.WriteLine(lengthOfLongestSubstringSlidingWindow(s));
            int x = (1534236460 + 9) * -1;

            Console.WriteLine(x);

            Console.ReadKey();
        }

        /// <summary>
        /// First attempt
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static int LengthOfLongestSubstring(string s)
        {
            int index = 0, len = s.Length, maxLen = 0;
            var charSet = new HashSet<char>(s);

            while (index < len)
            {
                string subStr = string.Empty;
                for (int i = index; i < len; i++)
                {
                    if (subStr.Contains(s[i]))
                    {
                        break;
                    }

                    subStr += s[i];
                }

                if (subStr.Length == len)
                {
                    return len;
                }

                if (subStr.Length > maxLen)
                {
                    maxLen = subStr.Length;
                }

                index++;
            }

            return maxLen;
        }


        /// <summary>
        /// Sliding window
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int lengthOfLongestSubstringSlidingWindow(String s)
        {
            int n = s.Length;
            var set = new HashSet<char>();

            int ans = 0, i = 0, j = 0;
            int numberOfLoop = 0;

            while (i < n && j < n)
            {
                numberOfLoop++;
                // try to extend the range [i, j]
                if (!set.Contains(s[j]))
                {
                    set.Add(s[j++]);
                    ans = Math.Max(ans, j - i);
                }
                else
                {
                    set.Remove(s[i++]);
                }
            }

            Console.WriteLine($"String length: {n}");
            Console.WriteLine($"Number of Loop: {numberOfLoop}");

            return ans;
        }
    }
}
