class Dog
{
    private string Name;
    public string _Name
    {
        get
        {
            return Name;
        }
        set
        {
            Name = value;
        }
    }
    string Breed;
    string FurColor;

    public Dog(string n, string b, string f)
    {
        Name = n;
        Breed = b;
        FurColor = f;
    }

    void Bark()
    {
        Console.WriteLine("Bark! Bark!");
    }
}