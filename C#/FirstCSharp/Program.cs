using System;
using System.Collections.Generic;

namespace FirstCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i=1;i<251;i++) {
                Console.WriteLine(i);
            }
            for(int i=1;i<101;i++) {
                if(i % 3 == 0 || i % 5 == 0) {
                    if(i % 3 == 0 && i % 5 == 0) {
                        Console.WriteLine("FizzBuzz");
                    } else {
                        if(i % 3 == 0) {
                            Console.WriteLine("Fizz");
                        }
                        if(i % 5 == 0) {
                            Console.WriteLine("Buzz");
                        }
                    }
                }
            }
        }
    }
}
