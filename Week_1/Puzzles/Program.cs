// Coin Flip
static string HeadsOrTails()
{
    Random rand = new Random();
    if(rand.Next(0,2)== 0)
    {
        return "Heads";
    } else {
        return "Tails";
    }
}
// Console.WriteLine(HeadsOrTails());

// Dice Roll
static int DiceRoll(int Sides)
{
    Random rand = new Random();
    return rand.Next(1, Sides+1);
}

// Console.WriteLine(DiceRoll(10));

// Stat Roll
static List<int> StatRoll()
{
    Random rand = new Random();
    List<int> myList = new List<int>(){DiceRoll(100),DiceRoll(100),DiceRoll(100),DiceRoll(100)};
    return myList;
}

int highest = 0;
// foreach(int item in StatRoll())
// {
//     if(item > highest)
//     {
//         highest = item;
//     }
//     Console.WriteLine(item);
// }
// Console.WriteLine($"Highest Value in Stat Roll: {highest}");


// Roll Until 
static string RollUntil(int guess)
{
    int count = 0;
    if(guess < 1 || guess > 6)
    {
        return "Number has to between 1 and 6";
    }
    int result = DiceRoll(6);
    while(result != guess)
    {
        result = DiceRoll(6);
        count++;
    }
    return $"You rolled a {guess} after {count} attempts!";
}


Console.WriteLine(RollUntil(4));