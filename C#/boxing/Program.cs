using System;
using System.Collections.Generic;
namespace boxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> listable = new List<object>();
            listable.Add(7);
            listable.Add(28);
            listable.Add(true);
            listable.Add("chair");
            listable.Add(-1);
            int sum = 0;
            foreach(var i in listable) { 
                Console.WriteLine(i);
                if(i is int) {
                    sum += (int)i;
                }
            }
                Console.WriteLine(sum);

        }
    }
}
