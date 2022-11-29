Vehicle BMW = new Vehicle("BMW M4", 4,"Black",true,191);

Vehicle Sneakers = new Vehicle("Nike Air Forces","white");

Vehicle Helicopter = new Vehicle("Boeing AH-64 Apache",2,"Military Green",true,227);

Vehicle Yacht = new Vehicle("Y721",58,"Black and White",true,8);

List<Vehicle> VehicleList = new List<Vehicle>(){BMW,Sneakers,Helicopter,Yacht};
foreach(Vehicle item in VehicleList)
{
    item.PrintInfo();
}

Helicopter.Travel(100);
Helicopter.PrintInfo();