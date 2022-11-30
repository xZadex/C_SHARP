class MagicCaster : Enemy
{
    public MagicCaster(string n) : base(n,80)
    {

        AttackList.Add(new Attack("Fireball", 25));
        AttackList.Add(new Attack("Shield", 0));
        AttackList.Add(new Attack("Staff Strike", 15));
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
    }


    public MagicCaster Heal(Enemy target)
    {
        target._Health+=40;
        Console.WriteLine($"You healed {target._Name} to {target._Health} health!");
        return this;
    }
}