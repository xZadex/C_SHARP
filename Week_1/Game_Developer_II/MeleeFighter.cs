class MeleeFighter : Enemy
{
    public MeleeFighter(string n) : base(n,120)
    {
        AttackList.Add(new Attack("Punch", 20));
        AttackList.Add(new Attack("Kick", 15));
        AttackList.Add(new Attack("Tackle", 25));
    }

    public void Rage()
    {
        foreach(Attack move in AttackList)
        {
            move._DamageAmount += 10;
        }
        RandomAttack();
        foreach(Attack move in AttackList)
        {
            move._DamageAmount -= 10;
        }
    }
}