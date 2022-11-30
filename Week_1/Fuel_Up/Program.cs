// Vehicle BMW = new Vehicle("BMW M4", 4,"Black",true,191);

// Vehicle Sneakers = new Vehicle("Nike Air Forces","white");

// Vehicle Helicopter = new Vehicle("Boeing AH-64 Apache",2,"Military Green",true,227);

// Vehicle Yacht = new Vehicle("Y721",58,"Black and White",true,8);

// List<Vehicle> VehicleList = new List<Vehicle>(){BMW,Sneakers,Helicopter,Yacht};
// foreach(Vehicle item in VehicleList)
// {
//     item.PrintInfo();
// }

// Helicopter.Travel(100);
// Helicopter.PrintInfo();

Car Lambo = new Car("Lamborghini Aventador",2,"White",true,200,"High Octane");
Car Ferrari = new Car("Ferrari",2,"Red",true,200,"High Octane");
// Lambo.GiveFuel(20);
// Lambo.PrintInfo();

Horse Bucky = new Horse("Bucky",1,"Gray", 55,"Hay");
// Bucky.PrintInfo();

Bicycle Lightning3000 = new Bicycle("Lightning3000",1,"Chrome",false,15);

List<Vehicle> vehicleList = new List<Vehicle>(){Lambo,Ferrari,Bucky,Lightning3000};
List<INeedFuel> needFuelList = new List<INeedFuel>();
foreach(Vehicle item in vehicleList)
{
    item.PrintInfo();
    if(item is INeedFuel)
    {
        needFuelList.Add(item as INeedFuel);
    }
}

Console.WriteLine("-- Fuel List Below --");
foreach(INeedFuel item in needFuelList)
{
    item.GiveFuel(10);
}

