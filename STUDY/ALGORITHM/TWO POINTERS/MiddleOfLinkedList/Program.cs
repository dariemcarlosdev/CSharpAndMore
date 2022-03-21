using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleOfLinkedList
{
    //Creating Node in Single List.
    //Creating a Single Linked List Class. When a new Linked List is created it just has a head, which is Null.
 public class ListNode    {
     public int val;
     public ListNode next;
     public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
       }
  }

    public class Solution
    {
        public static int MiddleNode(ListNode head)
        {

            ListNode fast = head;
            ListNode Slow = head;

            if (head.next == null)
            
                return head.val;


            return Slow.val;
        }
    }

    //public class Solution
    //{
    //    public static ListNode MiddleNode(ListNode head)
    //    {

    //    }
    //}
    class Program
    {
        static void Main(string[] args)
        {


            Solution.MiddleNode( );

        }
    }
}
