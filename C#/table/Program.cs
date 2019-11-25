using System;

namespace table
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] table = new int[10,10];

            for(int i=1;i<11;i++) {
                for(int j=1;j<11;j++) {
                    table[i-1,j-1] = i * j;
                    Console.WriteLine(table[i-1,j-1]);
                }
            }
        }
    }
}
