using System;
using System.Collections.Generic;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] vals = {0,1,2,3,4,5,6,7,8,9};
            string[] names = {"Tim", "Martin", "Nikki", "Sara"};
            bool[] alternates = new bool[10];
            alternates[0] = true;
            List<string> flavors = new List<string>();
            flavors.Add("chocolate");
            flavors.Add("vanilla");
            flavors.Add("Banana");
            flavors.Add("Strawberry");
            flavors.Add("Butterfinger");
            Console.WriteLine("The count of flavors is " + flavors.Count);
            Console.WriteLine(flavors[2]);
            flavors.RemoveAt(2);
            Console.WriteLine(flavors.Count);
            Dictionary<string,string> values = new Dictionary<string,string>();
            values.Add(names[0], flavors[0]);
            values.Add(names[1], flavors[1]);
            values.Add(names[2], flavors[2]);
            values.Add(names[3], flavors[3]);
            foreach (var entry in values) {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }
    }
}
