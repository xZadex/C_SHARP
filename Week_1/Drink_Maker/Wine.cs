public class Wine : Drink
{
    public string Region;
    public int yearMade;
    public Wine(string name,string region,int yearmade ,string color, double temp, bool isCarb, int calories) : base(name,color,temp,isCarb,calories)
    {
        Region = region;
        yearMade = yearmade;
    }
    public override void ShowDrink()
    {   
        base.ShowDrink();
        Console.WriteLine($"Region: {Region}\nYear Made: {yearMade}");
    }
}