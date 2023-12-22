using System;
using System.Security.Cryptography.X509Certificates;

public sealed class Horse
{
    public string Breed { get; private set; }
    public bool IsShod { get; private set; }
    public int Age { get; private set; }
    public int Weight { get; private set; }
    public int Height { get; private set; }

    public Horse(string breed, bool shod, int age, int weight, int height)
    {
        Breed = breed;
        IsShod = shod;
        Age = age;
        Weight = weight;
        Height = height; 

    }

    public void ShoeHorse() // put on horse shoes
    {
        IsShod = true;
    }

    //public static implicit operator Car(Horse horse)
    //{
    //    return new Car(horse);
    //}
    public static bool operator >(Horse h1, Horse h2)
    {
        return (h1.Age + h1.Weight + h1.Height > h2.Age + h2.Weight + h2.Height);
    }
    public static bool operator <(Horse h1, Horse h2)
    {
        return (h1.Age + h1.Weight + h1.Height < h2.Age + h2.Weight + h2.Height);
    }
    public static bool operator ==(Horse h1, Horse h2)
    {
        return h1.Age == h2.Age && h1.Weight == h2.Weight && h1.Height == h2.Height;
    }
    public static bool operator !=(Horse h1, Horse h2)
    {
        return h1.Age != h2.Age || h1.Weight != h2.Weight || h1.Height != h2.Height;
    }
}


class Program
{
    static void Main()
    {
        Horse Thunder = new Horse("race horse", true, 10, 300, 180);
        Horse Bella = new Horse("regular", false, 18, 200, 170);
        Horse Lora = new Horse("regular", false, 18, 200, 170);
        Console.WriteLine($"is Thunder cooler than Bella? Answer: {Thunder > Bella}");
        Console.WriteLine($"is Lora is the same as Bella? Answer: {Lora == Bella}");
    }
}
