using System;

namespace basic13
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        public static void printNumbers() {
            for(int i=1;i<256;i++) {
                Console.WriteLine(i);
            }
        }
        public static void printOdds() {
            for(int i=1;i<256;i++) {
                if(i % 2 == 1) {
                    Console.WriteLine(i);
                }
            }
        }
        public static void printSum() {
            int sum = 0;
            for(int i=1;i<256;i++) {
                sum += i;
                Console.WriteLine($"sum: {sum}, number: {i}");
            }
        }
        public static void loopArray(int[] numbers) {
            foreach(int i in numbers) {
                Console.WriteLine(i);
            }
        }
        public static int FindMax(int[] numbers) {
            int max = 0;
            foreach(int i in numbers) {
                if(i > max) {
                    max = i;
                }
            }
            return max;
        }
        public static void getAverage(int[] numbers) {
            int average = 0;
            int sum = 0;
            foreach(int i in numbers) {
                sum += i;
            }
            average = sum/numbers.Length;
            Console.WriteLine(average);
        }
        public static int[] oddArray() {
            int count = 0;
            for(int i=1;i<256;i++) {
                if(i % 2 == 1) {
                    count++;
                }
            }
            int[] arr = new int[count];
            for(int i=1;i<256;i++) {
                if(i%2 == 1) {
                    arr[i] = i;
                }
            }
            return arr;
        }
        public static int greaterThanY(int[] numbers, int y) {
            int greaterThan = 0;
            foreach(int i in numbers) {
                if(i > y) {
                    greaterThan++;
                }
            }
            return greaterThan;
        }
        public static void SquareArrayValues(int[] numbers ) {
            int[] arr = new int[numbers.Length];
            for(int i=0;i<arr.Length;i++) {
                arr[i] = numbers[i] * numbers[i];
            }
            Console.WriteLine(arr);
        }
        public static void eliminateNegatives(int[] numbers) {
            for(int i=0;i<numbers.Length;i++) {
                if(numbers[i] < 0) {
                    numbers[i] = 0;
                }
            }
            Console.WriteLine(numbers);
        }
        public static void minMaxAvg(int[] numbers) {
            int max = 0;
            int min = 0;
            int sum = 0;
            int avg = 0;
            for(int i=0;i<numbers.Length;i++) {
                if(numbers[i] > max) {
                    max = numbers[i];
                }
                if(numbers[i] < min) {
                    min = numbers[i];
                }
                sum += numbers[i];
            }
            avg = sum/numbers.Length;
        }
        public static void shiftValues(int[] numbers) {
            int[] arr = new int[numbers.Length];
            arr[arr.Length-1] = 0;
            for(int i=0;i<numbers.Length-2;i++) {
                arr[i] = numbers[i + 1];
            }
        }
        public static object[] numToString(int[] numbers) {
            object[] arr = new object[numbers.Length];
            for(int i=0;i<numbers.Length;i++) {
                if(numbers[i] < 0) {
                    arr[i] = "Dojo";
                } else {
                    arr[i] = numbers[i];
                }
            }
            return arr;
        }
    }
}
