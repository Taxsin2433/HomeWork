using System;
using HwCreateGame.Character.Interface;
using HwCreateGame.Character;
using HwCreateGame.Character.Human;
using HwCreateGame.Character.Elf;

namespace HwCreateGame.Character
{

    class Character : IHealth
    {
        public string Race { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int Defense { get; set; }

        public Character(string race, string name, int health, int attackPower/*, *int defense*/)
        {
            Race = race;    
            Name = name;
            Health = health;
            AttackPower = attackPower;
           // Defense = defense;
        }

        public virtual void Attack(Character target)
        {
            int damage = AttackPower - target.Defense;
            target.Health -= damage;
            Console.WriteLine($"{Name} атакует {target.Name} и наносит {damage} урона.");
        }

        public virtual void Block()
        {
            Console.WriteLine($"{Name} блокирует атаку.");
        }

        static public Character CreateCharacter()
        {
            Console.WriteLine("Выберите расу: Human или Elf");
            var race = Console.ReadLine();
            var helper = new Profession();
            var professions = helper.GetProffesions(race);
            Console.WriteLine(professions);
            var proffesion = Console.ReadLine();
            

            Console.WriteLine("Введите имя персонажа:");
            string name = Console.ReadLine();

            switch (proffesion)
            {
                case "Warrior":
                    return new Warrior(name);
                        
                case "Rogue":
                    return new Rogue(name);

                case "Knight":
                    return new Knight(name);

                case "Tank":
                    return new Tank(name);

                case "Scout":
                    return new Scout(name);

                default:
                    Console.WriteLine("Wrong Character");
                    return null;
            }

            {
            }
            

         
        }
    }
}
    



 




