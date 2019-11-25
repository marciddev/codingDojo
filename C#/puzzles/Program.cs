using System;
using System.Collections.Generic;

namespace puzzles
{
    class Program
    {
        public static int ranNum() {
            Random ran = new Random();
                return ran.Next(5, 25); 
            }
        public static void randArr() {
            int[] arr = new int[10];
            for(int i=0;i<10;i++) {
                arr[i] = ranNum();
            }
            int max = 0;
            int min = 0;
            int sum = 0;
            foreach(int i in arr) { 
                sum += i;
                if(min > i) {
                    min = i;
                }
                if(max < i) {
                    max = i;
                }
            }
            Console.WriteLine($"Max: {max}, min: {min}, sum: {sum}");
        }
        public static string TossCoin() {
            Console.WriteLine("Tossing coin...");
            Random ran = new Random();
            int ran2 = ran.Next(1,3);
            if(ran2 == 1) {
                Console.WriteLine("Heads");
                return "Heads";
            } else {
                Console.WriteLine("Tails");
                return "Tails";
            }
        }




        public static double tossMultiple(int num) {
            int heads = 0;
            int tails=0;
            for(int i=0;i<num;i++) {
                string result = TossCoin();
                if(result == "Heads") {
                    heads++;
                } else {
                    tails++;
                }
            }
            Console.WriteLine($"You landed on heads {heads} times and tails {tails} times.");
            double ratio = (heads + tails)/heads;
            return ratio;
        }




        public static List<string> names() {
            List<string> names = new List<string>();
            names.Add("Todd");
            names.Add("Tiffany");
            names.Add("Charlie");
            names.Add("Geneva");
            names.Add("Sydney");
            Random r = new Random();
            int ran = 0;
            List<string> ranList = new List<string>();
            while(names.Count > 0) {
                ran = r.Next(0, names.Count);
                ranList.Add(names[ran]);
                names.RemoveAt(ran);
            }
            foreach(string s in ranList) {
                Console.WriteLine(s);
            }
            List<string> greaterThanFive = new List<string>();
            foreach(string s in ranList) {
                if(s.Length > 5) {
                    greaterThanFive.Add(s);
                    Console.WriteLine($"-- {s}");
                }
            }
            return greaterThanFive;
        }
        static void Main(string[] args) {
            randArr();
            TossCoin();
            tossMultiple(3);
            names();
        }
    }
}
