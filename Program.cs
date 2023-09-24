using System;
public class Program
{
    public static void Main(string[] args)
    {
        DoublyLinkedList<int> numbers = new DoublyLinkedList<int>();

        while (true)
        {
            Console.WriteLine("Выберите операцию:");
            Console.WriteLine("1. Добавить элемент в начало");
            Console.WriteLine("2. Добавить элемент в конец");
            Console.WriteLine("3. Удалить элемент");
            Console.WriteLine("4. Вывести список");
            Console.WriteLine("5. Выйти");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Введите элемент для добавления в начало:");
                    if (int.TryParse(Console.ReadLine(), out int value))
                    {
                        numbers.AddFirst(value);
                        Console.WriteLine("Элемент успешно добавлен в начало списка.");
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                    }
                    break;
                case "2":
                    Console.WriteLine("Введите элемент для добавления в конец:");
                    if (int.TryParse(Console.ReadLine(), out int value1))
                    {
                        numbers.AddLast(value1);
                        Console.WriteLine("Элемент успешно добавлен в конец списка.");
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                    }
                    break;
                case "3":
                    Console.WriteLine("Введите элемент для удаления:");
                    if (int.TryParse(Console.ReadLine(), out int removeValue))
                    {
                        if (numbers.Remove(removeValue))
                        {
                            Console.WriteLine("Элемент успешно удален.");
                        }
                        else
                        {
                            Console.WriteLine("Элемент не найден в списке.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                    }
                    break;
                case "4":
                    Console.WriteLine("Список элементов:");
                    foreach (int number in numbers)
                    {
                        Console.WriteLine(number);
                    }
                    break;
                case "5":
                    Console.WriteLine("Программа завершена.");
                    return;
                default:
                    Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
