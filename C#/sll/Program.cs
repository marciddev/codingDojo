using System;

namespace sll
{
    class Program
    {
        static void Main(string[] args)
        {
            SLNode node1 = new SLNode(6);
            SLNode node2 = new SLNode(3);
            SLNode node3 = new SLNode(5);
            SLL list = new SLL();
            list.addFront(6);
            node1.next = node2;
            node2.next = node3;
            foreach(int i in list.display()) {
                Console.WriteLine(i);
            }
            Console.WriteLine(list.Length());
            
        }
    }
    class SLNode {
        public SLNode next;
        public int value;
        public SLNode(int val) {
            next = null;
            value = val;
        }
    }
    class SLL {
        public SLNode head;
        public SLL() {
            SLNode head = null;
        }
        public void addFront(int val) {
            SLNode node = new SLNode(val);
            node.next = head;
            head = node;
        }
        public SLNode removeFront() {
            head = head.next;
            return head;
        }
        public bool contains(int val) {
            SLNode runner = head;
            while(runner != null) {
                if(runner.value == val) {
                    return true;
                }
                runner = runner.next;
            }
            return false;
        }
        public int Length() {
            int count = 0;
            SLNode runner = head;
            while(runner != null) {
                count++;
                runner = runner.next;
            }
            return count;
        }
        public int[] display() {
            Console.WriteLine(Length());
            int[] num = new int[Length()];
            SLNode runner = head;
            int count = 0;
            while (runner != null) {
                num[count] = runner.value;
                runner = runner.next;
                count++;
            }
            return num;
        }

    }
}
