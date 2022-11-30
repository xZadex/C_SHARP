class Attack
{
    private string Name;
    public string _Name{get{return Name;}}
    private int DamageAmount;
    public int _DamageAmount{get{return DamageAmount;}set{DamageAmount=value;}}

    public Attack(string n, int d)
    {
        Name = n;
        DamageAmount = d;
    }
}