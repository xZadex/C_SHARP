// Three Basic Arrays
int[] intArray = {0,1,2,3,4,5,6,7,8,9};

string[] strArray = {"Tim","Martin","Nikki","Sara"};

bool[] boolArray = new bool[10];

for(int i=0;i<boolArray.Length;i++)
{
    if(i % 2 == 0)
    {
        boolArray[i] = true;
    }
}

foreach(bool item in boolArray)
{
    Console.WriteLine(item);
}

// List of Flavors

List<string> FlavorsList = new List<string>();
FlavorsList.Add("Chocolate");
FlavorsList.Add("Vanilla");
FlavorsList.Add("Mint Chocolate Chip");
FlavorsList.Add("Strawberry");


Console.WriteLine(FlavorsList.Count);
Console.WriteLine(FlavorsList[2]);
FlavorsList.RemoveAt(2);
Console.WriteLine(FlavorsList.Count);


// User Dictionary
Random rand = new Random();
Dictionary<string,string> profile = new Dictionary<string, string>();
profile.Add(strArray[0],FlavorsList[rand.Next(0, FlavorsList.Count)]);
profile.Add(strArray[1],FlavorsList[rand.Next(0, FlavorsList.Count)]);
profile.Add(strArray[2],FlavorsList[rand.Next(0, FlavorsList.Count)]);
profile.Add(strArray[3],FlavorsList[rand.Next(0, FlavorsList.Count)]);

// foreach(KeyValuePair<string,string> item in profile)
// {
//     Console.WriteLine(item);
// }

foreach(var item in profile)
{
    Console.WriteLine(item.Key);
}