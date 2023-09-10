using System;

namespace HwCreateGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание персонажа
            Character.Character player = Character.Character.CreateCharacter();

            // Создание врага
            Mobs.Mobs enemy = Mobs.Mobs.CreateEnemy();

            // Битва
            Battle(player, enemy);

            Console.ReadLine();
        }



        static Equip.Equipment CreateEquipment()
        {
            Console.WriteLine("Введите имя снаряжения:");
            string name = Console.ReadLine();

            Console.WriteLine("Введите бонус к силе атаки:");
            int attackBonus = int.Parse(Console.ReadLine());

            return new Equip.Equipment(name, attackBonus);
        }



        static void Battle(Character.Character player, Character.Character enemy)
        {
            Console.WriteLine($"Битва начинается! {player.Name} против" +
                $" {enemy.Name}");

            while (player.Health > 0 && enemy.Health > 0)
            {
                // Ход игрока
                Console.WriteLine($"{player.Name}, ваш ход:");
                Console.WriteLine("1. Атаковать");
                Console.WriteLine("2. Заблокировать");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    player.Attack(enemy);
                }
                else if (choice == 2)
                {
                    player.Block();
                }
                else
                {
                    Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
                    continue;
                }

                // Ход врага
                if (enemy.Health > 0)
                {
                    enemy.Attack(player);
                }

                Console.WriteLine($"{player.Name}: {player.Health} здоровья");
                Console.WriteLine($"{enemy.Name}: {enemy.Health} здоровья");
            }

            if (player.Health > 0)
            {
                Console.WriteLine($"{player.Name} победил!");
            }
            else
            {
                Console.WriteLine($"{enemy.Name} победил!");
            }
        }
    }
}
