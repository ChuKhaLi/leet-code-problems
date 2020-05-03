using System;
using System.Collections.Generic;

namespace _01.FirstBadVersion
{
    class Program
    {
        /// <summary>
        /// Day 01 First Bad Version
        /// https://leetcode.com/explore/featured/card/may-leetcoding-challenge/534/week-1-may-1st-may-7th/3316/
        /// You are a product manager and currently leading a team to develop a new product. Unfortunately, the latest version of your product fails the quality check. Since each version is developed based on the previous version, all the versions after a bad version are also bad.
        /// Suppose you have n versions[1, 2, ..., n] and you want to find out the first bad one, which causes all the following ones to be bad.
        /// You are given an API bool isBadVersion(version) which will return whether version is bad.Implement a function to find the first bad version.You should minimize the number of calls to the API.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var listVersionControls = new List<VersionControl>
            {
                new VersionControl {TotalVersion = 5, BadVersion = 4},
                new VersionControl {TotalVersion = 5, BadVersion = 2},
                new VersionControl {TotalVersion = 5, BadVersion = 1},
                new VersionControl {TotalVersion = 10, BadVersion = 2},
                new VersionControl {TotalVersion = 10, BadVersion = 6},
                new VersionControl {TotalVersion = 10, BadVersion = 7},
                new VersionControl {TotalVersion = 10, BadVersion = 8},
                new VersionControl {TotalVersion = 2126753390, BadVersion = 1702766719},
            };

            PrintLine();
            PrintRow("Total version", "Init bad version", "Output bad version", "Total API calls", "Success");
            PrintLine();

            foreach (var versionControl in listVersionControls)
            {
                int firstBadVersion = versionControl.FirstBadVersion();

                PrintRow(versionControl.TotalVersion.ToString(), versionControl.BadVersion.ToString(),
                         firstBadVersion.ToString(), versionControl.NumberOfApiCall.ToString(), $"{versionControl.BadVersion == firstBadVersion}");
            }

            PrintLine();

            Console.ReadKey();
        }

        static int tableWidth = 80;

        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            return string.IsNullOrEmpty(text) ? new string(' ', width) : text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
        }
    }

    public class VersionControl
    {
        public int BadVersion { get; set; }
        public int TotalVersion { get; set; }
        public int NumberOfApiCall { get; internal set; }
        public bool IsBadVersion(int version)
        {
            NumberOfApiCall++;
            return version >= BadVersion;
        }

        public int FirstBadVersion()
        {
            int low = 1, high = TotalVersion, firstBadVersion = TotalVersion;

            while (low < high)
            {
                if (low == high - 1)
                {
                    if (!IsBadVersion(low))
                    {
                        low = high;
                    }

                    firstBadVersion = firstBadVersion > low ? low : firstBadVersion;
                    break;
                }

                int mid = low + (high - low) / 2;

                if (!IsBadVersion(mid))
                {
                    low = mid;
                    continue;
                }

                firstBadVersion = firstBadVersion > mid ? mid : firstBadVersion;
                high = mid;
            }

            return firstBadVersion;
        }
    }
}
