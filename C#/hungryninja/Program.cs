using System;
using System.Collections.Generic;
namespace hungryninja
{
    class Food {
        public string Name;
        public int Calories;
        public bool IsSpicy;
        public bool IsSweet;
        public Food(string name, int calories, bool isspicy, bool issweet) {
            Name = name;
            Calories = calories;
            IsSpicy = isspicy;
            IsSweet = issweet;
        }
    }
    class Buffet {
        public List<Food> Menu;
        public Buffet() {
            Menu = new List<Food>() {
                new Food("Banana", 100, false, true),
                new Food("Wing", 300, true, false)
            };
        }
        public Food Serve() {
            Random r = new Random();
            return Menu[r.Next(0, Menu.Count)];
        }
    }
    class Ninja {
        private int calorieIntake;
        public List<Food> FoodHistory;
        public Ninja() {
            calorieIntake = 0;
            FoodHistory = new List<Food>();
        }
        public Boolean isFull {
            get {
                if(calorieIntake > 1200) {
                    return true;
                } else {
                    return false;
                }
            }
        }
        public void Eat(Food food) {
            if(isFull == false) {
                calorieIntake += food.Calories;
                FoodHistory.Add(food);
                Console.WriteLine($"{food.Name} --- Spicy: {food.IsSpicy}, Sweet: {food.IsSweet}");
            } else {
                Console.WriteLine("Ninja is full!");
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Ninja ninja = new Ninja();
            Buffet buffet = new Buffet();
            Console.WriteLine(ninja.isFull);
            while(ninja.isFull == false) {
                ninja.Eat(buffet.Serve());
            }
            Console.WriteLine(ninja.isFull);
            foreach(Food food in ninja.FoodHistory) {
                Console.WriteLine($"{food.Calories} {food.Name}");
            }
        }
    }
}
