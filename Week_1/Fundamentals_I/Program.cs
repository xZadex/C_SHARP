
for(int i = 1; i <= 255; i++)
{
    Console.WriteLine(i);
}

for(int j = 1; j <= 5; j++)
{
    Random rand = new Random();
    Console.WriteLine(rand.Next(10,21));
}


for(int k = 1; k <= 100; k++)
{
    if(k % 5 == 0 && k % 3 == 0)
    {
        Console.WriteLine($"FizzBuzz {k}");
    } else if(k % 3 == 0){
        Console.WriteLine($"Fizz {k}");
    } else if(k % 5 == 0){
        Console.WriteLine($"Buzz {k}");
    }
}

// optional
int counter = 1;
while(counter <= 100)
{
    if(counter % 5 == 0 && counter % 3 == 0)
    {
        Console.WriteLine($"FizzBuzz {counter}");
    } else if(counter % 3 == 0){
        Console.WriteLine($"Fizz {counter}");
    } else if(counter % 5 == 0){
        Console.WriteLine($"Buzz {counter}");
    }
    counter++;
}