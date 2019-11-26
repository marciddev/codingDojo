using System;

namespace wizardsamuraininja
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    class Human {
        public string name;
        public int strength;
        public int intelligence;
        public int dexterity;
        private int health;
        public int Health { get; set; } 
        public Human(string Name) {
            name = Name;
            strength = 3;
            intelligence = 3;
            dexterity = 3;
            health = 100;
        }
        public Human(string Name, int Strength, int Intelligence, int Dexterity, int HealthParam) {
            name = Name;
            strength = Strength;
            intelligence = Intelligence;
            dexterity = Dexterity;
            health = HealthParam;
        }
        public virtual int Attack(Human target) {
            target.health -= strength * 5;
            return target.Health;
        }
    }
    class Wizard : Human {
        public Wizard(string Name, int Strength, int Dexterity) : base(Name, Strength, 25, Dexterity, 50) {

        }
        public override int Attack(Human target) {
            target.Health -= 5*intelligence;
            Health += 5*intelligence;
            return target.Health;
        }
        public int Heal(Human target) {
            target.Health += 10*intelligence;
            return target.Health;
        }
    }
    class Ninja: Human {
        public Ninja(String Name, int Strength, int Intelligence, int HealthParam) : base(Name, Strength, Intelligence, 175, HealthParam) {

        }
        public override int Attack(Human target) {
            target.Health -= 5*dexterity;
            Random r = new Random();
            if((int)r.Next(1, 11) > 7) {
                target.Health -= 10;
                Console.WriteLine("You had a 20 percent chance of dealing extra damage. You got lucky!");
            }
            return target.Health;
        }
        public int Steal(Human target) {
            target.Health -= 5;
            Health += 5;
            return Health;
        }
    }
    class Samurai: Human {
        public Samurai(String Name, int Strength, int Intelligence, int Dexterity) : base(Name, Strength, Intelligence, Dexterity, 200) {

        }
        public override int Attack(Human target) {
            base.Attack(target);
            if(target.Health <= 50) {
                target.Health = 0;
                Console.WriteLine("The target has died..");
            }
            return target.Health;
        }
        public int Meditate() {
            Health = 200;
            return Health;
        }
    }
}
