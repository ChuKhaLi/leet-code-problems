using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace _6.ZigZagConversion
{
    class Program
    {
        /// <summary>
        /// 6. ZigZag Conversion
        /// The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this:
        /// (you may want to display this pattern in a fixed font for better legibility)
        /// 
        /// P   A   H   N
        /// A P L S I I G
        /// Y   I   R
        /// And then read line by line: "PAHNAPLSIIGYIR"
        /// 
        /// Write the code that will take a string and make this conversion given a number of rows:
        /// 
        /// string convert(string s, int numRows);
        /// Example 1:
        /// 
        /// Input: s = "PAYPALISHIRING", numRows = 3
        /// Output: "PAHNAPLSIIGYIR"
        /// Example 2:
        /// 
        /// Input: s = "PAYPALISHIRING", numRows = 4
        /// Output: "PINALSIGYAHRPI"
        /// Explanation:
        /// 
        /// P     I    N
        /// A   L S  I G
        /// Y A   H R
        /// P     I
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var testStr = new[]
            {
                new
                {
                    input = "PAYPALISHIRING",
                    numRows = 3,
                    result = "PAHNAPLSIIGYIR"
                },
                new
                {
                    input = "PAYPALISHIRING",
                    numRows = 4,
                    result = "PINALSIGYAHRPI"
                },
                new
                {
                    input = "AB",
                    numRows = 1,
                    result = "AB"
                }
            };

            foreach (var test in testStr)
            {
                string result = Convert(test.input, test.numRows);
                Console.WriteLine($"input {test.input}\tnumRows {test.numRows}");
                Console.WriteLine($"expected {test.result}\tgot {result}");
                Console.WriteLine($"expected.Length {test.result.Length}\tresult.Length {result.Length}");
                Console.WriteLine($"success: {test.result.Equals(result)}");
            }

            Console.ReadKey();
        }

        public static string Convert(string input, int numRows)
        {
            if (numRows == 1)
            {
                return input;
            }

            var rows = new int[numRows]
                .Select(x => new StringBuilder())
                .ToList();

            int index = 0;
            bool increasing = true;
            foreach (char c in input)
            {
                rows[index].Append(c);
                index += increasing ? 1 : -1;
                if (index == numRows - 1 || index == 0)
                {
                    increasing = !increasing;
                }
            }

            var result = new StringBuilder();
            foreach (var row in rows)
            {
                result.Append(row);
            }

            return result.ToString();
        }
    }
}
