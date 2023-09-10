using System;

namespace HwCreateGame.Mobs
{
    class Mobs : Character.Character
    {
        public Mobs(string name, int health, int attackPower, int defense)
            : base("Mob", name, health, attackPower)
        {
            Defense = defense;
        }

        public override void Attack(Character.Character target)
        {
            int damage = AttackPower - target.Defense;
            target.Health -= damage;
            Console.WriteLine($"{Name} атакует {target.Name} и наносит {damage} урона.");
        }

        public override void Block()
        {
            Console.WriteLine($"{Name} блокирует атаку.");
        }

        static public Mobs CreateEnemy()
        {
            Random random = new Random();
            string[] enemyNames = { "Baium", "Beleth" };
            string[] enemyAntharas = { "Antharas" };
            string[] enemyValakas = { "Valakas" };

            string name;
            int health;
            int attackPower;
            int defense;

            int randomEnemy = random.Next(3); 

            if (randomEnemy == 0)
            {
                name = enemyNames[random.Next(enemyNames.Length)];
                health = random.Next(50, 101);
                attackPower = random.Next(10, 21);
                defense = random.Next(2, 5);
            }
            else if (randomEnemy == 1)
            {
                name = enemyAntharas[random.Next(enemyAntharas.Length)];
                health = random.Next(300, 350); // Изменяем параметры для Antharas
                attackPower = random.Next(40, 60); 
                defense = random.Next(5, 7); 
            }
            else
            {
                name = enemyValakas[random.Next(enemyValakas.Length)];
                health = random.Next(150, 201); // Изменяем параметры для Valakas
                attackPower = random.Next(28, 34); 
                defense = random.Next(7, 12); 
            }


            return new Mobs(name, health, attackPower, defense);
        }

    }

}

