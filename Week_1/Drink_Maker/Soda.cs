public class Soda : Drink
{
    public bool isDiet;
    public Soda(string name,bool diet, string color, double temp, int calories) : base(name,color,temp,true,calories)
    {
        isDiet = diet;
    }

    public override void ShowDrink()
    {   
        base.ShowDrink();
        Console.WriteLine($"Diet: {isDiet}");
    }
}