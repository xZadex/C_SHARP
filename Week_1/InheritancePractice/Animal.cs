public class Animal
{
    public string Name;
    public string Diet;
    public bool IsMammal;

    public Animal(string name, string diet, bool ismammal)
    {
        Name = name;
        Diet = diet;
        IsMammal = ismammal;
    }
    

// method overriding
// include "virtual" before the return type
// continue on Cat.cs
    public virtual void ShowInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Diet: {Diet}");
        Console.WriteLine($"Mammal: {IsMammal}");
    }
}