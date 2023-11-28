using System;

// Define the base 'Component' interface
public interface IPerson
{
    string GetDescription();
    int GetComfortLevel();
    int GetStyleRating();
}

// Implement the 'ConcreteComponent' class
public class Person : IPerson
{
    private string _name;

    public Person(string name)
    {
        _name = name;
    }

    public string GetDescription()
    {
        return _name + " is wearing";
    }

    // Base comfort level when not wearing anything
    public int GetComfortLevel()
    {
        return 5; 
    }

    // Base style rating when not wearing anything
    public int GetStyleRating()
    {
        return 5;
    }
}

// Implement the 'Decorator' abstract class
public abstract class ClothingDecorator : IPerson
{
    protected IPerson _person;

    public ClothingDecorator(IPerson person)
    {
        _person = person;
    }

    public virtual string GetDescription()
    {
        return _person.GetDescription();
    }


    public virtual int GetComfortLevel()
    {
        return _person.GetComfortLevel();
    }

    public virtual int GetStyleRating()
    {
        return _person.GetStyleRating();
    }
}

// Implement 'ConcreteDecoratorA' class
public class Shirt : ClothingDecorator
{
    public Shirt(IPerson person) : base(person)
    {
    }

    public override string GetDescription()
    {
        return base.GetDescription() + " a shirt";
    }

    public override int GetComfortLevel()
    {
        return base.GetComfortLevel() + 2;
    }

    public override int GetStyleRating()
    {
        return base.GetStyleRating() + 3;
    }
}

// Implement 'ConcreteDecoratorB' class
public class Pants : ClothingDecorator
{
    public Pants(IPerson person) : base(person)
    {
    }

    public override string GetDescription()
    {
        return base.GetDescription() + ", pants";
    }

    public override int GetComfortLevel()
    {
        return base.GetComfortLevel() + 2;
    }

    public override int GetStyleRating()
    {
        return base.GetStyleRating() + 2;
    }
}

public class Shoes : ClothingDecorator
{
    public Shoes(IPerson person) : base(person)
    {
    }

    public override string GetDescription()
    {
        return base.GetDescription() + ", and shoes";
    }

    public override int GetComfortLevel()
    {
        return base.GetComfortLevel() + 1;
    }

    public override int GetStyleRating()
    {
        return base.GetStyleRating() + 5;
    }
}

public class Gun : ClothingDecorator
{
    public Gun(IPerson person) : base(person)
    {
    }

    public override string GetDescription()
    {
        return base.GetDescription() + ", and a gun";
    }

    public override int GetComfortLevel()
    {
        return base.GetComfortLevel() + 100;
    }

    public override int GetStyleRating()
    {
        return base.GetStyleRating() + 1;
    }
}

// The client code
class Program
{
    static void Main(string[] args)
    {
        IPerson person = new Person("Ilhan");

        Console.WriteLine("Choose the clothes for Ilhan:");
        Console.WriteLine("1. Shirt");
        Console.WriteLine("2. Pants");
        Console.WriteLine("3. Shoes");
        Console.WriteLine("4. Gun");
        Console.WriteLine("Enter the numbers of the clothes to wear.");

        var choices = Console.ReadLine().Split(' ');

        foreach (var choice in choices)
        {
            switch (choice)
            {
                case "1":
                    person = new Shirt(person);
                    break;
                case "2":
                    person = new Pants(person);
                    break;
                case "3":
                    person = new Shoes(person);
                    break;
                case "4":
                    person = new Gun(person);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Skipping.");
                    break;
            }
        }

        Console.Clear();
        Console.WriteLine(person.GetDescription());
        Console.WriteLine($"Total Comfort Level: {person.GetComfortLevel()}");
        Console.WriteLine($"Total Style Rating: {person.GetStyleRating()}");
    }
}
