class Horse : Vehicle, INeedFuel
{
    public string FuelType {get;set;}
    public int FuelTotal {get;set;}
    public Horse(string n, int p, string c, int t, string ftype) : base(n,p,c,false,t)
    {
        FuelType = ftype;
        FuelTotal = 10;
    }

    public void GiveFuel(int Amount)
    {
        FuelTotal+=Amount;
        Console.WriteLine($"You filled up your {_Name}. You now have {FuelTotal} gallons remaining.");
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"\tFuel Type: {FuelType}\n\tFuel Total: {FuelTotal}");
    }
}