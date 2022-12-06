
List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
// PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");

// Execute Assignment Tasks here!

//1
Eruption? firstChile = eruptions.FirstOrDefault(e => e.Volcano == "Chile");
// Console.WriteLine(firstChile);

//2
Eruption? hawaiian = eruptions.FirstOrDefault(l => l.Location == "Hawaiian Is");
// if (hawaiian == null)
// {
//     Console.WriteLine("No Hawaiian Is Eruption found.");
// } 
// else
// {
//     Console.WriteLine(hawaiian.Volcano);
// }

//3
Eruption? greenland = eruptions.FirstOrDefault(g => g.Location == "Greenland");
// if (greenland == null)
// {
//     Console.WriteLine("No Greenland Eruption found");
// }
// else
// {
//     Console.WriteLine(greenland.Volcano);
// }

// 4
Eruption? after1900 = eruptions.FirstOrDefault(l => l.Year > 1900 && l.Location == "New Zealand");
// Console.WriteLine(after1900);

// 5
List<Eruption> highestEruptions = eruptions.Where(e => e.ElevationInMeters > 2000).ToList();
// PrintEach(highestEruptions);


// 6
List<Eruption> startsL = eruptions.Where(e => e.Volcano.StartsWith("L")).ToList();
// PrintEach(startsL);
// Console.WriteLine(startsL.Count);

// 7
int maxEruption = eruptions.Max(i => i.ElevationInMeters);
// Console.WriteLine(maxEruption);

// 8
Eruption? peakEruption = eruptions.FirstOrDefault(e => e.ElevationInMeters == maxEruption);
// Console.WriteLine($"Volcano: {peakEruption?.Volcano}\nHeight: {peakEruption?.ElevationInMeters}");

// 9
List<string> orderedAlphabetically =  eruptions.OrderBy(e => e.Volcano).Select(e => e.Volcano).ToList();
foreach(string i in orderedAlphabetically)
{
    Console.WriteLine(i);
}

// 10
int totalHeight = eruptions.Sum(e => e.ElevationInMeters);
// Console.WriteLine(totalHeight);

// 11
bool year2k = eruptions.Any(e => e.Year == 2000);
// if(year2k)
// {
//     Console.WriteLine("No eruptions in the year 2000");
// }
// else
// {
//     Console.WriteLine("There were eruptions in the year 2000");
// }

// 12
List<Eruption> strat = eruptions.Where(e => e.Type == "Stratovolcano").Take(3).ToList();
// PrintEach(strat);

// 13
List<Eruption> beforeTime = eruptions.Where(e => e.Year < 1000).OrderBy(e => e.Volcano).ToList();
// PrintEach(beforeTime);

// 14
List<string> beforeTime2 = eruptions.Where(e => e.Year < 1000).OrderBy(e => e.Volcano).Select(e => e.Volcano).ToList();
// foreach(string i in beforeTime2)
// {
//     Console.WriteLine(i);
// }

// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}


