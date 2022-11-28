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

Random rand = new Random();
for(int k = 1; k <= 10; k++)
{
    Console.WriteLine(rand.Next(1, 100));
}