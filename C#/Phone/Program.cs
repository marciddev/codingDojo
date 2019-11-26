using System;

namespace Phone
{
    class Program
    {
        static void Main(string[] args)
        {
            Galaxy note9 = new Galaxy("1", 90, "AT&T", "RINGING RINGING");
            Nokia crap = new Nokia("0", 20, "US CELLULAR", "BAD BAD");
            note9.DisplayInfo();
            Console.WriteLine(note9.Ring());
            Console.WriteLine(note9.Unlock());
            Console.WriteLine("-----------------");
            crap.DisplayInfo();
            Console.WriteLine(crap.Ring());
            Console.WriteLine(crap.Unlock());
            Console.WriteLine("-----------------------");
        }
    }
}
