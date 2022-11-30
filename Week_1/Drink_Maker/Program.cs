Soda Coke = new Soda("Coke",false,"Brown",40.00,200);
Coffee Espresso = new Coffee("Espresso","Dark","House Blend","Brown",85.00,false,10);
Wine RedWine = new Wine("Red Wine","Italy",1982,"Red",65.50, false, 120);

List<Drink> DrinkList = new List<Drink>(){Coke,Espresso,RedWine};
RedWine.ShowDrink();

//Bonus
Coffee MyDrink = new Soda("Pepsi",false,"Brown",42.22,201);
// initially it complained about not having arguments passed in
// after providing arguments it states you cannot implicitly convert type 'Soda' to 'Coffee'