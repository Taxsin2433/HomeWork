using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите два числа для вычисления Фибоначчи и факториала (через пробел):");
        string[] numbers = Console.ReadLine().Split(' ');

        int fibNumber = int.Parse(numbers[0]);
        int factNumber = int.Parse(numbers[1]);

        CollectionManager collectionManager = new CollectionManager();
        Fibonacci fibCalculator = new Fibonacci();
        Factorial factCalculator = new Factorial();

        long fibResult = fibCalculator.CalcFibonacci(fibNumber);
        long factResult = factCalculator.CalcFactorial(factNumber);

        collectionManager.AddResult(fibNumber, fibResult, factResult);

        var results = collectionManager.GetResults();

        foreach (var result in results)
        {
            Console.WriteLine($"Число: {result.Key}, Фибоначчи: {result.Value.Item1}, Факториал: {result.Value.Item2}");
        }
    }
}
