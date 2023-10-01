using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Выберите вариант ввода элементов массива:");
        Console.WriteLine("1. Ввести элементы вручную");
        Console.WriteLine("2. Автоматически сгенерировать элементы");
        Console.Write("Ваш выбор: ");

        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
        {
            Console.WriteLine("Пожалуйста, введите 1 или 2 для выбора варианта.");
        }

        int[] arr;
        if (choice == 1)
        {
            arr = ArrayInput.InputArrayManually();
        }
        else
        {
            Console.Write("Введите количество элементов: ");
            int count;
            while (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
            {
                Console.WriteLine("Пожалуйста, введите положительное число для количества элементов.");
            }
            arr = ArrayInput.GenerateRandomArray(count);
        }

        Console.WriteLine("Исходный массив:");
        ArrayInput.PrintArray(arr);

        QuickSort.QS(arr, 0, arr.Length - 1);

        Console.WriteLine("Отсортированный массив:");
        ArrayInput.PrintArray(arr);
    }
}
