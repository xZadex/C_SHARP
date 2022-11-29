// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


// Data types
string name = "Nicholas";
int age = 27;
double dec = 3.14;
float floatvalue = 1.2f;
bool isTired = true;


// Lists and Dictionaries
// Array and List
// Arrays are fixed length
string[] groceryList = new string[4];
// [null, null, null, null]
string[] groceryList2 = {"Carrots", "Turkey", "Bread", "Milk"};
//                          0          1         2       3
groceryList[2] = "Ham";
// Console.WriteLine(groceryList[2]);
// Console.WriteLine(groceryList2.Length);


// Lists are variable length
List<int> NumberList = new List<int>();
NumberList.Add(1);
NumberList.Add(5);
// This removes the value of 3
// NumberList.Remove(5);
// Remove at the location index 3
// NumberList.RemoveAt(5);
// First parameter is the index, second is the value
NumberList.Insert(1, 3);

// Console.WriteLine(NumberList.Count);
// foreach(int i in NumberList)
// {
//     Console.WriteLine(i);
// }

// conditionals
int numberOne = -2;
// if(numberOne > 0)
// {
//     Console.WriteLine("Greater than 0");
// } else {
//     Console.WriteLine("Not greater than 0");
// }

// >
// <
// >=
// <=
// ==
// !=
// &&
// ||
// !


// For loops
// for(int i = 1; i <= 5;i++)
// {
//     Console.WriteLine(i);
// }

// While loop
// int j = 1;
// while(j <= 5)
// {
//     Console.WriteLine(j);
//     j++;
// }

// Random rand = new Random();
// for(int k = 1; k <= 10; k++)
// {
//     Console.WriteLine(rand.Next(1, 100));
// }

// Dictionary
// Dictionary<string,string> profile = new Dictionary<string, string>();
// profile.Add("Name","Nick");
// Console.WriteLine(profile["Name"]);

// Functions
// static string SayHello()
// {
//     return "Hey!";
// }

// Console.WriteLine(SayHello());


// String inputs
// Console.WriteLine("Type something, then hit enter: ");
// string InputLine = Console.ReadLine();
// Console.WriteLine($"You wrote: {InputLine}");


// Number inputs / TryParse
// Console.WriteLine("Type a number, then hit enter: ");
// string NumberInput = Console.ReadLine();
// // TryParse takes 2 parameters: the item to be parsed and a variable
// // you would like to output (out) to if it is successful
// if(Int32.TryParse(NumberInput, out int j))
// {
//     // Notice how we used j instead of NumberInput
//     Console.WriteLine($"The integer was {j}");
//     Console.WriteLine(10 + j);
// }

// Convert
// string aNumber = "7";
// int converted = Convert.ToInt32(aNumber);
// Console.WriteLine(14 + converted); // should print 21
// string aDecimal = "3.14";
// double convertDec = Convert.ToDouble(aDecimal);
// Console.WriteLine(1.8 + convertDec); // should print 4.94

// Classes
Dog Harley = new Dog("Harley","French Bulldog","Dark Gray");
Console.WriteLine(Harley._Name);
