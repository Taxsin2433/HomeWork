using System;

public class ArrayInput
{
    public static int[] InputArrayManually()
    {
        Console.Write("Введите элементы массива через пробел: ");
        string input = Console.ReadLine();
        string[] inputElements = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int[] arr = new int[inputElements.Length];
        for (int i = 0; i < inputElements.Length; i++)
        {
            if (!int.TryParse(inputElements[i], out arr[i]))
            {
                Console.WriteLine("Ошибка ввода. Пожалуйста, повторите.");
                return InputArrayManually(); // например при вводе дробных чисел
            }
        }

        return arr;
    }

    public static int[] GenerateRandomArray(int count)
    {
        Random random = new Random();
        int[] arr = new int[count];
        for (int i = 0; i < count; i++)
        {
            arr[i] = random.Next(1000);
        }
        return arr;
    }

    public static void PrintArray(int[] arr)
    {
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}
