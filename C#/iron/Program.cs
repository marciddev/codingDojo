using System;
using System.Collections.Generic;
namespace iron
{
    interface IConsumable {
        string Name {get;set;}
        int Calories {get;set;}
        bool IsSpicy {get;set;}
        bool IsSweet{get;set;}
        string GetInfo();
    }
    class Food : IConsumable {
        public string Name {get;set;}
        public int Calories {get;set;}
        public bool IsSpicy {get;set;}
        public bool IsSweet {get;set;}
        public string GetInfo() {
            return $"{Name} (Food). Calories: {Calories}. Spicy?: {IsSpicy}, Sweet?: {IsSweet}";
        }
        public Food(string name, int calories, bool isspicy, bool issweet) {
            Name = name;
            Calories = calories;
            IsSpicy = isspicy;
            IsSweet = issweet;
        }
    }
    class Buffet {
        public List<IConsumable> Menu;
        public Buffet() {
            Menu = new List<IConsumable>() {
                new Food("Banana", 100, false, true),
                new Food("Wing", 300, true, false),
                new Drink("Coke", 450, false),
                new Drink("Water", 0, false)
            };
        }
        public IConsumable Serve() {
            Random r = new Random();
            return Menu[r.Next(0, Menu.Count)];
        }
    }
    abstract class Ninja {
        protected int calorieIntake;
        public List<IConsumable> ConsumptionHistory;
        public Ninja() {
            calorieIntake = 0;
            ConsumptionHistory = new List<IConsumable>();
        }
        public abstract bool IsFull {get;set;}
        public abstract void Consume(IConsumable Item);

    }
    class SweetTooth : Ninja {
        public override bool IsFull {get;set;}
        public override void Consume(IConsumable Item) {
            if(calorieIntake > 1500) {
                IsFull = true;
            } else {
                IsFull = false;
            }
            if(!IsFull) {
                if(Item.IsSweet) {
                    calorieIntake += 10;
                }
                calorieIntake += 150;
                ConsumptionHistory.Add(Item);
                Console.WriteLine(Item.GetInfo());
                Console.WriteLine("Sweet tooth has eaten " + Item.Name + ". It was (calories) " + Item.Calories);
            } else {
                Console.WriteLine("Full! Cannot eat anymore!...");
            }
        }
    }
    class SpiceHound : Ninja {
        public override bool IsFull {get;set;}
        public override void Consume(IConsumable Item) {
            if(calorieIntake > 1200) {
                IsFull = true;
            } else {
                IsFull = false;
            }
            if(!IsFull) {
            calorieIntake += 150;
            if(Item.IsSpicy) {
                calorieIntake -= 5;
            }
            ConsumptionHistory.Add(Item);
            Console.WriteLine(Item.GetInfo());
            Console.WriteLine("Sweet tooth has eaten " + Item.Name + ". It was (calories) " + Item.Calories);
            } else {
                Console.WriteLine("Full! Cannot eat anymore!...");
            }
        }
    }
    class Drink : IConsumable {
        public string Name {get;set;}
        public int Calories {get;set;}
        public bool IsSpicy {get;set;}
        public bool IsSweet {get;set;}
        public Drink(string name, int calories, bool isspicy) {
            IsSweet = true;
            Name = name;
            Calories = calories;
            IsSpicy = isspicy;
        }
        public string GetInfo() {
            return $"{Name} (Drink). Calories: {Calories}. Spicy?: {IsSpicy}, Sweet?: {IsSweet}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int c = 0;
            int c2 = 0;
            Buffet buffet = new Buffet();
            SweetTooth s = new SweetTooth();
            SpiceHound h = new SpiceHound();
            while(s.IsFull == false) {
                c++;
                s.Consume(buffet.Serve());
            }
            while(h.IsFull == false) {
                c2++;
                h.Consume(buffet.Serve());
            }
            if(c > c2) {
                Console.WriteLine("SweetTooth consumed more items." + c);
            } else {
                Console.WriteLine("SpiceHound consumed more items." + c2);
            }
            Console.WriteLine(c + " " + c2);
        }
    }
}
