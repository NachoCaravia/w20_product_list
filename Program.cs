

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
                    productManager.AddProducts();
                    break;
                case "2":
                    productManager.ShowProducts();
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
}



