// 1
List<string> strList = new List<string>(){"Hello","World","People"};
static void PrintList(List<string> MyList)
{
    foreach(string item in MyList)
    {
        Console.WriteLine(item);
    }
}

// PrintList(strList);

// 2
List<int> myList = new List<int>(){1,2,3,4,5};
static void SumOfNumbers(List<int> IntList)
{
    int result = 0;
    for(int i = 0; i<IntList.Count;i++)
    {
        result+=IntList[i];
    }
    Console.WriteLine(result);
}

// SumOfNumbers(myList);

// 3
List<int> maxList = new List<int>(){1,2,3,4,5};
static int FindMax(List<int> IntList)
{
    int max = 0;
    for(int i = 0; i<IntList.Count;i++)
    {
        if(IntList[i] > max)
        {
            max = IntList[i];
        }
    }
    return max;
}
// Console.WriteLine(FindMax(maxList));

// 4
List<int> squaredList = new List<int>(){1,2,3,4,5};
static List<int> SquareValues(List<int> IntList)
{
    List<int> squaredListNew = new List<int>();
    for(int i = 0; i < IntList.Count; i++)
    {
        squaredListNew.Add(IntList[i] * IntList[i]);
    }
    return squaredListNew;
}

// foreach(int item in SquareValues(squaredList))
// {
//     Console.WriteLine(item);
// }

// 5
int[] intArray01 = {-1,1,-1,1,-1};
static int[] NonNegatives(int[] IntArray)
{
    for(int i=0;i<IntArray.Length;i++)
    {
        if(IntArray[i] < 0)
        {
            IntArray[i] = 0;
        }
    }
    return IntArray;
}

// foreach(int item in NonNegatives(intArray01))
// {
//     Console.WriteLine(item);
// }

// 6
Dictionary<string,string> testDictionary = new Dictionary<string, string>(){{"Nicholas","Gibson"},{"Cliff","Helms"}};
testDictionary.Add("Hello", "World");
static void PrintDictionary(Dictionary<string,string> MyDictionary)
{
    foreach(var item in MyDictionary)
    {
        Console.WriteLine(item);
    }
}

// PrintDictionary(testDictionary);

// 7
Dictionary<string,string> findDictionary = new Dictionary<string, string>(){{"Nicholas","Gibson"},{"Cliff","Helms"}};
static bool FindKey(Dictionary<string,string> MyDictionary, string SearchTerm)
{
    bool keyExists = MyDictionary.ContainsKey(SearchTerm);
    return keyExists;
}

// Console.WriteLine(FindKey(findDictionary,"Nicholas"));

// 8
// Ex: Given ["Julie", "Harold", "James", "Monica"] and [6,12,7,10], return a dictionary
// {
//	"Julie": 6,
//	"Harold": 12,
//	"James": 7,
//	"Monica": 10
// } 
List<int> numList01 = new List<int>(){1,2,3,4,5};
List<string> stringList = new List<string>(){"One","Two","Three","Four","Five"};
static Dictionary<string,int> GenerateDictionary(List<string> Names, List<int> Numbers)
{
    Dictionary<string,int> returnDictionary = new Dictionary<string, int>();
    for(int i=0;i<Numbers.Count;i++)
    {
        returnDictionary.Add(Names[i],Numbers[i]);
    }
    return returnDictionary;
}

foreach(var item in GenerateDictionary(stringList, numList01))
{
    Console.WriteLine(item);
}