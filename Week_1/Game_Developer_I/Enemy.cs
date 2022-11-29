class Enemy
{
    private string Name;
    public string _Name{get{return Name;}}
    private int Health;
    public int _Health{get{return Health;}}
    private List<Attack> AttackList;
    public List<Attack> _AttackList{get{return AttackList;}}

    List<Attack> Attacks = new List<Attack>(){new Attack("Punch", 5),new Attack("Kick", 10),new Attack("Block",0)};

    public Enemy(string n)
    {
        Name = n;
        Health = 100;
        AttackList = Attacks;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Enemy Name: {this._Name}\nEnemy Health: {this._Health}");
        foreach(Attack item in AttackList)
        {
            Console.WriteLine($"Attack: {item._Name} | Damage: {item._DamageAmount}");
        }
    }

    public void RandomAttack()
    {
        Random rand = new Random();
        Console.WriteLine($"{AttackList[rand.Next(0,AttackList.Count)]._Name}");
    }

    public Enemy AddAttack(Attack att)
    {
        AttackList.Add(att);
        return this;
    }
}