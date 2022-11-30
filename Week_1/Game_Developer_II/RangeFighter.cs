class RangeFighter : Enemy
{
    public int Distance;
    public RangeFighter(string n) : base(n,100)
    {
        Distance = 5;
        AttackList.Add(new Attack("Shoot Arrow", 20));
        AttackList.Add(new Attack("Throw Knife", 15));
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Distance: {Distance}");
    }

    public override void RandomAttack()
    {
        Random rand = new Random();
        Attack randAtt = AttackList[rand.Next(0,AttackList.Count)];
        if(Distance < 10)
        {
            Console.WriteLine("You are too far to your target to attack!");
        } else {
            Console.WriteLine($"You {randAtt._Name} for {randAtt._DamageAmount} damage!");
        }
    }

    public RangeFighter Dash()
    {
        Distance = 20;
        Console.WriteLine("You Dash Away..");
        return this;
    }
}