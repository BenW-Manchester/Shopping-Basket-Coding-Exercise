Dictionary<string, int> basket = [];
Dictionary<string, double> stock = new()
{
            { "Item1", 5 },
            { "Item2", 10 },
            { "Item3", 15 },
            { "Item4", 20 },
            { "Item5", 25 }
};

void Menu()
{
    Console.Clear();
    Console.WriteLine("Please choose an option");
    Console.WriteLine("-1 see stock");
    Console.WriteLine("-2 view basket");
    Console.WriteLine("-3 add to basket");
    Console.WriteLine("-4 remove from basket");
    Console.WriteLine("-5 confirm order");

    while (true)
    {
        ConsoleKeyInfo option = Console.ReadKey();
        switch (option.Key)
        {
            case ConsoleKey.D1:
                ViewStock();
                break;
            case ConsoleKey.D2:
                ViewBasket();
                break;
            case ConsoleKey.D3:
                AddToBasket();
                break;
            case ConsoleKey.D4:
                RemoveFromBasket();
                break;
            case ConsoleKey.D5:
                ConfirmOrder();
                break;
            default:
                Console.WriteLine("Please try again and choose a valid option");
                break;
        }
    }
}

void ReturnToMenu()
{
    Console.WriteLine("Press enter to return to menu");
    while (true)
    {
        ConsoleKeyInfo key = Console.ReadKey();
        if (key.Key == ConsoleKey.Enter)
        {
            Menu();
        }
        else
        {
            ReturnToMenu();
        }
    }
}

void ViewStock()
{
    Console.Clear();
    Console.WriteLine("Currently in stock is: ");
    foreach (KeyValuePair<string, double> item in stock)
    {
        Console.WriteLine($"Name: {item.Key} Price: £{item.Value}");
    }
    ReturnToMenu();
}

void ViewBasket()
{
    Console.Clear();
    Console.WriteLine("Currently in the basket is: ");
    foreach (KeyValuePair<string, int> item in basket)
    {
        Console.WriteLine($"Name: {item.Key} Quantity: {item.Value} Price: £{stock[item.Key]}");
    }
    Console.WriteLine($"Total Price: £{CalculateTotal()}");
    ReturnToMenu();
}

void AddToBasket()
{
    Console.Clear();
    Console.WriteLine("To add an item to the basket enter an item name and the quanity you would like");
    Console.WriteLine("e.g. 'Item1 1'");
    string name;
    int amount;

    try
    {
        string[] item = Console.ReadLine().Split(" ");

        name = item[0];
        amount = int.Parse(item[1]);
    }
    catch (IndexOutOfRangeException)
    {
        AddToBasket();
    }

    if (!stock.ContainsKey(name))
    {
        Console.WriteLine("Please try again and enter a valid item name");
        AddToBasket();
    }

    if (basket.ContainsKey(name))
    {
        basket[name] = basket[name] + amount;
    }
    else
    {
        basket.Add(name, amount);
    }


    ReturnToMenu();
}

void RemoveFromBasket()
{
    Console.Clear();
    Console.WriteLine("To remove an item from the basket enter an item name and the quanity you would like to remove");
    Console.WriteLine("e.g. 'Item1 1'");
    string name;
    int amount;

    try
    {
        string[] item = Console.ReadLine().Split(" ");

        name = item[0];
        amount = int.Parse(item[1]);
    }
    catch (IndexOutOfRangeException)
    {
        RemoveFromBasket();
    }

    if (!stock.ContainsKey(name))
    {
        Console.WriteLine("Please try again and enter a valid item name");
        RemoveFromBasket();
    }

    basket[name] = basket[name] - amount;


    ReturnToMenu();
}

void ConfirmOrder()
{
    Console.Clear();

    Console.WriteLine($"Total Price of basket: £{CalculateTotal()}");
    Console.WriteLine("If you have a discount code enter it now ");
    string code = Console.ReadLine();

    if (code == "TENOFF")
    {
        Console.WriteLine("Ten percent has been deducted from your most expensive item");

        string mostExpItem = basket.MaxBy(item => stock[item.Key]).Key;
        double tenPercentMostExpItem = stock[mostExpItem] * 0.1;

        double newTotal = CalculateTotal() - tenPercentMostExpItem;


        Console.WriteLine($"New Total Price of basket: £{newTotal}");
    }
    else
    {
        Console.WriteLine("Invalid code");
    }

    Console.WriteLine("Press Y to confirm your order or N to cancel");
    while (true)
    {
        ConsoleKeyInfo option = Console.ReadKey();
        switch (option.Key)
        {
            case ConsoleKey.Y:
                Console.WriteLine("Order Confirmed!");
                basket.Clear();
                ReturnToMenu();
                break;
            case ConsoleKey.N:
                Console.WriteLine("Cancelled");
                ReturnToMenu();
                break;
            default:
                Console.WriteLine("Invalid option");
                break;
        }
    }
}

double CalculateTotal()
{
    double total = 0;
    foreach (KeyValuePair<string, int> item in basket)
    {
        total += stock[item.Key] * item.Value;
    }
    return total;
}

Console.WriteLine("Welcome to the shop!");
Menu();
