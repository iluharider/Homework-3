using System;

public sealed class Horse
{
    public string Breed { get; private set; }
    public bool IsShod { get; private set; }

    public Horse(string breed, bool shod)
    {
        Breed = breed;
        IsShod = shod;
    }

    public void ShoeHorse() // put on horse shoes
    {
        IsShod = true;
    }

    public static implicit operator Car(Horse horse)
    {
        return new Car(horse);
    }

}

public class Car
{
    public string Model { get; private set; }
    public bool hasStuddedTires { get; private set; }

    public Car(string model, bool StuddedTires)
    {
        Model = model;
        hasStuddedTires = StuddedTires;
    }
    public Car(Horse horse) // works just like explicit operator in Main - you can't create both explicit and implicit conversion operators (from Horse to Car) with the same arguments and return value 
    {
        Model = horse.Breed switch
        {
            "heavy horse" => "pickup truck",
            "racehorse" => "race car",
            _ => "standard car"
        };
        hasStuddedTires = horse.IsShod ? true : false;

    }
    public Horse toHorse()
    {
        string horseBreed = this.Model switch
        {
            "pickup truck" => "heavy horse",
            "race car" => "racehorse",
            _ => "regular horse"
        };
        bool isShod = this.hasStuddedTires ? true : false;

        return new Horse(horseBreed, isShod);

    }

    public static explicit operator Horse(Car car)
    {
        return car.toHorse();
    }

}

class Program
{
    static void Main()
    {
        Horse myHorse = new Horse("heavy horse", false);
        Console.WriteLine($"My horse: breed: {myHorse.Breed},` isShod: {myHorse.IsShod}");

        myHorse.ShoeHorse();
        Console.WriteLine($"Is the horse shod now? {myHorse.IsShod}");

        // Explicit conversion from Horse to Car (works with the help of constructor, not conversion operator)
        Car myCar = (Car)myHorse;
        Console.WriteLine($"My car: model: {myCar.Model}, hasStuddedTires: {myCar.hasStuddedTires} ");

        Horse newHorse = new Horse("racehorse", false);
        Console.WriteLine($"new horse: breed: {newHorse.Breed}, isShod: {newHorse.IsShod}");

        // Implicit conversion from Horse to Car (works with implicit conversion operator)
        Car newCar = newHorse;
        Console.WriteLine($"new car: model: {newCar.Model}, hasStuddedTires: {newCar.hasStuddedTires} ");

        // Explicit conversion from Car to Horse (works with explicit conversion operator)
        Horse brandNewHorse = (Horse)newCar;
        Console.WriteLine($"brandNewHorse : breed: {brandNewHorse.Breed}, isShod: {brandNewHorse.IsShod} ");
    }
}
