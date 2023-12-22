using System;

class Program
{
    static void Main()
    {
        // Test cases
        Console.WriteLine(Simplify("4/6"));
        Console.WriteLine(Simplify("10/11"));
        Console.WriteLine(Simplify("100/400"));
        Console.WriteLine(Simplify("8/4"));
    }

    static string Simplify(string arg)
    {
        string[] parts = arg.Split('/');

        if (parts.Length != 2 || !int.TryParse(parts[0], out int numerator) || !int.TryParse(parts[1], out int denominator))
        {
            return "Invalid input";
        }
        if (numerator == 0) return $"{numerator}";
        if (denominator == 0) return "you can't divide by zero!";

        int gcd = GCD(numerator, denominator);

        // Simplify the fraction by dividing both numerator and denominator by their GCD
        numerator /= gcd;
        denominator /= gcd;
        if (denominator == 1) return $"{numerator}";

        return $"{numerator}/{denominator}";
    }

    static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}
