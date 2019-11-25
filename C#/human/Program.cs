using System;

namespace human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human human1 = new Human("Kevin");
            Human human2 = new Human("Josh");
            human1.Attack(human2);
            Console.WriteLine(human2.health);
        }
    }
    class Human {
        public string name;
        public int strength;
        public int intelligence;
        public int dexterity;
        private int Health;
        public int health { get {return Health; } }
        public Human(string Name) {
            name = Name;
            strength = 3;
            intelligence = 3;
            dexterity = 3;
            Health = 100;
        }
        public Human(string Name, int Strength, int Intelligence, int Dexterity, int HealthParam) {
            name = Name;
            strength = Strength;
            intelligence = Intelligence;
            dexterity = Dexterity;
            Health = HealthParam;
        }
        public int Attack(Human target) {
            target.Health -= strength * 5;
            return target.Health;
        }
    }
}
