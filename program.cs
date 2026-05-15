// using Product;
// using ProductManager;

namespace ProductList
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("==== PRODUCT LIST APPLICATION ====");

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Enter a Number");
                Console.WriteLine("1-Add a Product");
                Console.WriteLine("2-Search a Product");
                Console.WriteLine("3-List Products");
                Console.WriteLine("0-Quit");

                Console.Write("Enter a Number: ");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        SearchProduct();
                        break;
                    case "3":
                        ListProducts();
                        break;
                    case "0":
                        // Console.WriteLine("Thank you for using this application");
                        break;

                    default:
                        Console.WriteLine("Invalid Selection");
                        break;
                }
            }
        }
    }
    
}


/*
Console.WriteLine("Enter a Number");
Console.WriteLine("1-Add a Product");
Console.WriteLine("2-Search a Product");
Console.WriteLine("3-List Products");
Console.WriteLine("0-Quit");

Console.Write("Enter a Number");
string userInput = Console.ReadLine();
switch (userInput)
{
    case "1":
        AddProduct();
        break;
    case "2":
        SearchProduct();
        break;
    case "3":
        ListProducts();
        break;
    case "0":
        Console.WriteLine("Thank you for using this application");
        break;

    default:
        Console.WriteLine("Invalid Selection");
        //ShowMainMenu();
        break;
}

void AddProduct()
{

}

void SearchProduct()
{

}

void ListProducts()
{

}*/