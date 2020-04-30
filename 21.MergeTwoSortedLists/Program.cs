using System;
using System.Text;

namespace _21.MergeTwoSortedLists
{
    class Program
    {
        /// <summary>
        /// 21. Merge Two Sorted Lists
        /// https://leetcode.com/problems/merge-two-sorted-lists/
        /// Merge two sorted linked lists and return it as a new list.
        /// The new list should be made by splicing together the nodes of the first two lists.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var list1 = ListNode.GenerateNode(1, 2, 4);
            var list2 = ListNode.GenerateNode(1, 3, 4);

            var result = MergeTwoLists(list1, list2);

            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            var result = new ListNode(0);
            var current = result;

            while (l1 != null || l2 != null)
            {
                if (l1 == null || (l2 != null && l2.val <= l1.val))
                {
                    current.next = l2;
                    current = current.next;

                    l2 = l2.next;
                    continue;
                }

                if (l2 == null || l1.val <= l2.val)
                {
                    current.next = l1;
                    current = current.next;

                    l1 = l1.next;
                }
            }

            return result.next;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }

        public override string ToString()
        {
            var current = this;
            var sb = new StringBuilder();
            sb.Append("[");
            while (current != null)
            {
                sb.Append(current.val + ", ");
                current = current.next;
            }

            string result = sb.ToString();
            result = result.Substring(0, result.Length - 2);
            result += "]";

            return result;
        }

        public static ListNode GenerateNode(params int[] numbers)
        {
            var node = new ListNode(numbers[0]);
            var current = node;
            for (int i = 1; i < numbers.Length; i++)
            {
                current.next = new ListNode(numbers[i]);
                current = current.next;
            }

            return node;
        }
    }
}
