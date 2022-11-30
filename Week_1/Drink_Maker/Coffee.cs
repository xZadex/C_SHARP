public class Coffee : Drink
{
    public string Roast;
    public string Bean;
    public Coffee(string name,string roast, string bean, string color, double temp, bool isCarb, int calories) : base(name,color,temp,isCarb,calories)
    {
        Roast = roast;
        Bean = bean;
    }

    public override void ShowDrink()
    {   
        base.ShowDrink();
        Console.WriteLine($"Roast: {Roast}\nBean: {Bean}");
    }
}