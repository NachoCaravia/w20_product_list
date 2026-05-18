

class Program
{
    static ProductManager productManager = new ProductManager();
    static void Main()
    {
        Console.WriteLine("==== PRODUCT LIST APPLICATION ====");

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Enter a Number");
            Console.WriteLine("1-Add a Product");
            Console.WriteLine("2-Show Products");
            
            Console.WriteLine("3-Search Product");
            Console.WriteLine("4-Edit Product");
            Console.WriteLine("5-Delete Product");
            Console.WriteLine("6-Statistics");
            Console.WriteLine("9-Quit");

            Console.Write("Enter a Number: ");
            string userInput = Console.ReadLine() ?? "";
            switch (userInput)
            {
                case "1":
                    Program.AddProduct();
                    break;
                case "2":
                    Program.ShowProducts();
                    break;
                case "3":
                    // Program.SearchProduct();
                    break;
                case "4":
                    // Program.EditProduct();
                    break;
                case "5":
                    // Program.DeleteProduct();
                    break;
                case "6":
                    // Program.ShowStatistics();
                    break;
                case "9":
                    exit = true;
                    // Console.WriteLine("Thank you for using this application");
                    break;

                default:
                    Console.WriteLine("Invalid Selection");
                    break;
            }
        }
    }

    static void AddProduct()
    {

        Console.WriteLine("==== ADD PRODUCTS ====");
        Console.WriteLine("Enter Product Details or press 'q' to return to main menu");
        bool adding = true;
        while (adding) 
        {
            string category = "";
            string name = "";
            double price = 0;
            for (int i = 0; i < 3; i++) 
            {
                if (i == 0)
                {
                    Console.Write("Enter Product Category: ");
                    string catInput = (Console.ReadLine() ?? "").Trim();
                    adding = !catInput.ToLower().Equals("q");
                    if (!adding) 
                    {
                        Console.WriteLine("==== BACK TO MAIN MENU ====");
                        break ;
                    }
                    category = catInput;
                    Console.WriteLine($"category: {category}");
                } 
                else if (i == 1) 
                {
                    Console.Write("Enter Product Name: ");
                    string nameInput = (Console.ReadLine() ?? "").Trim();;
                    adding = !nameInput.ToLower().Equals("q");
                    if (!adding) 
                    {
                        Console.WriteLine("==== BACK TO MAIN MENU ====");
                        break ;
                    }
                    name = nameInput;
                    Console.WriteLine($"name: {name}");
                }
                else
                {
                    Console.Write("Enter Product Price: ");
                    string priceInput = (Console.ReadLine() ?? "").Trim();
                    while (!double.TryParse(priceInput, out price) && !priceInput.ToLower().Equals("q")) 
                    {
                        Console.WriteLine("Invalid price. Please enter a valid double number: ");
                        priceInput = (Console.ReadLine() ?? "").Trim();
                    }
                    adding = !priceInput.ToLower().Equals("q");
                    if (!adding) 
                    {
                        Console.WriteLine("==== BACK TO MAIN MENU ====");
                        break ;
                    }
                    // price  = double.Parse(priceInput);
                    productManager.AddProduct(category, name, price);
                    Console.WriteLine("Product added successfully!");
                    Console.WriteLine($"category: {category}, name: {name}, price: {price}");
                    Console.WriteLine("====================================================");
                    Console.WriteLine("Enter Product Details or press 'q' to return to main menu");
                }
              
            }
        }
    }

    static void ShowProducts() 
    {
        productManager.ShowProducts();
    }

        
}



