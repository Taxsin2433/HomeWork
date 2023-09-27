public class Divide2and3
{
    private int[] numbers;

    public Divide2and3(int[] numbers)
    {
        this.numbers = numbers;
    }

    public void Execute()
    {
        var result = numbers.Where(x => x % 2 == 0 && x % 3 == 0);
        Console.WriteLine("Числа, которые делятся на 2 и 3:");
        PrintArray(result);
        Console.WriteLine();
    }

    private void PrintArray(IEnumerable<int> array)
    {
        foreach (var number in array)
        {
            Console.WriteLine(number);
        }
    }
}
