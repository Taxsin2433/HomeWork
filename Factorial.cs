using System;
using System.Threading.Tasks;

class Factorial
{
    public long CalcFactorial(int n)
    {
        if (n == 0)
            return 1;

        long result = 1;

        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }

        return result;
    }

    public async Task<long> CalcFactorialAsync(int n)
    {
        return await Task.Run(() => CalcFactorial(n));
    }
}
