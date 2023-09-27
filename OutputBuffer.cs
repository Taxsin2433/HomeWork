using System;
using System.Collections.Generic;

public static class OutputBuffer
{
    private static List<string> buffer = new List<string>();

    public static void Add(string output)
    {
        buffer.Add(output);
    }

    public static void Flush()
    {
        buffer.Sort(); // Сортируем вывод по алфавиту
        foreach (var output in buffer)
        {
            Console.WriteLine(output);
        }

        buffer.Clear();
    }
}