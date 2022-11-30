class Enemy
{
    private string Name;
    public string _Name{get{return Name;}}
    private int Health;
    public int _Health{get{return Health;}set{Health = value;}}
    public List<Attack> AttackList;



    public Enemy(string n, int h)
    {
        Name = n;
        Health = h;
        AttackList = new List<Attack>();
    }

    public virtual void PrintInfo()
    {
        Console.WriteLine($"Enemy Name: {this._Name}\nEnemy Health: {this._Health}");
        foreach(Attack item in AttackList)
        {
            Console.WriteLine($"Attack: {item._Name} | Damage: {item._DamageAmount}");
        }
    }

    public virtual void RandomAttack()
    {
        Random rand = new Random();
        Attack randAtt = AttackList[rand.Next(0,AttackList.Count)];
        Console.WriteLine($"You {randAtt._Name} for {randAtt._DamageAmount} damage!");
    }

    public Enemy AddAttack(Attack att)
    {
        AttackList.Add(att);
        return this;
    }
}