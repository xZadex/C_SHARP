Enemy Bandos = new Enemy("Bandos");
Attack FireBall = new Attack("FireBall", 99);
Attack IceBall = new Attack("IceBall", 75);
Attack PoisonBall = new Attack("PoisonBall", 50);
Bandos.AddAttack(FireBall).AddAttack(IceBall).AddAttack(PoisonBall);
Bandos.RandomAttack();
Bandos.PrintInfo();
