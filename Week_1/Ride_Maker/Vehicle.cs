class Vehicle
{
    private string Name;
    public string _Name
    {
        get
        {
            return Name;
        }
    }
    private int PassCount;
    public int _PassCount
    {
        get
        {
            return PassCount;
        }
    }
    private string  Color;
    public string _Color
    {
        get
        {
            return Color;
        }
    }
    private bool HasEngine;
    public bool _HasEngine
    {
        get
        {
            return HasEngine;
        }
    }
    private int TopSpeed;
    public int _TopSpeed
    {
        get
        {
            return TopSpeed;
        }
    }
    private int DistTraveled;
    public int _DistTraveled
    {
        get
        {
            return DistTraveled;
        }
        set
        {
            DistTraveled = value;
        }
    }
    public Vehicle(string n, int p, string c, bool h, int t)
    {
        Name = n;
        PassCount = p;
        Color = c;
        HasEngine = h;
        TopSpeed = t;
        DistTraveled = 0;
    }
    public Vehicle(string n, string c)
    {
        Name = n;
        PassCount = 1;
        Color = c;
        HasEngine = false;
        TopSpeed = 5;
        DistTraveled = 0;
    }

    public void PrintInfo()
    {
        Console.WriteLine("Vehicle Information:");
        Console.WriteLine($"\tName: {this._Name}");
        Console.WriteLine($"\tPassenger Count: {this._PassCount}");
        Console.WriteLine($"\tColor: {this._Color}");
        Console.WriteLine($"\tHas an Engine: {this._HasEngine}");
        Console.WriteLine($"\tTop Speed: {this._TopSpeed}");
        Console.WriteLine($"\tDistance Traveled: {this._DistTraveled}\n");
    }

    public void Travel(int dist)
    {
        this._DistTraveled += dist;
        Console.WriteLine($"You traveled {dist} miles! You now have {this._DistTraveled} total miles!\n");
    }
}