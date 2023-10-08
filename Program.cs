using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Введите два числа для вычисления Фибоначчи и факториала (через пробел):");
        string[] numbers = Console.ReadLine().Split(' ');

        int fibNumber = int.Parse(numbers[0]);
        int factNumber = int.Parse(numbers[1]);

        CollectionManager collectionManager = new CollectionManager();
        Fibonacci fibCalculator = new Fibonacci();
        Factorial factCalculator = new Factorial();

        Task<long> fibTask = fibCalculator.CalcFibonacciAsync(fibNumber);
        Task<long> factTask = factCalculator.CalcFactorialAsync(factNumber);

        await Task.WhenAll(fibTask, factTask);

        long fibResult = fibTask.Result;
        long factResult = factTask.Result;

        collectionManager.AddResult(fibNumber, fibResult, factResult);

        var results = collectionManager.GetResults();

        foreach (var result in results)
        {
            Console.WriteLine($"Число: {result.Key}, Фибоначчи: {result.Value.Item1}, Факториал: {result.Value.Item2}");
        }
    }
}
