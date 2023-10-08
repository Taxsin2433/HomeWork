using System;
using System.Threading.Tasks;

class Fibonacci
{
    public long CalcFibonacci(int n)
    {
        if (n <= 1)
            return n;

        long a = 0;
        long b = 1;

        for (int i = 2; i <= n; i++)
        {
            long temp = a + b;
            a = b;
            b = temp;
        }

        return b;
    }

    public async Task<long> CalcFibonacciAsync(int n)
    {
        return await Task.Run(() => CalcFibonacci(n));
    }
}
