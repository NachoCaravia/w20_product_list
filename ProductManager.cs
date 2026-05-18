
public class ProductManager 
{
    private readonly List<Product> _products = new List<Product>();
    private int _nextId = 1;


    public int AddProduct( string category, string name, double price) {
        
        int newId = _nextId++;
        Product newProduct = new Product(newId, category, name, price);
        _products.Add(newProduct);

        return newProduct.Id;
    }

    public void AddProducts()
    {
        Console.WriteLine("==== ADD PRODUCTS ====");
        Console.WriteLine("Enter Product Details or press 'q' to return to main menu");
        bool adding = true;
        while (adding) 
        {
            string category = "";
            string name = "";
            double price;
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
                    while (!double.TryParse(priceInput, out price) || 
                        priceInput.ToLower().Equals("q") ||
                        price < 0 ) 
                    {
                        Console.WriteLine("ERROR:");
                        if (price < 0) 
                        {
                            Console.WriteLine("Price cannot be negative. Please enter a valid price: ");
                        } else {
                            Console.WriteLine("Invalid price format. Please enter a valid double number: ");
                        }
                        Console.WriteLine("");
                        priceInput = (Console.ReadLine() ?? "").Trim();
                    }
                    Console.WriteLine($"price: {price}");
                    Console.WriteLine($"Is price < 0? {price < 0}");  
                    adding = !priceInput.ToLower().Equals("q");
                    if (!adding) 
                    {
                        Console.WriteLine("==== BACK TO MAIN MENU ====");
                        break ;
                    }
                    AddProduct(category, name, price);
                    Console.WriteLine("Product added successfully!");
                    Console.WriteLine($"category: {category}, name: {name}, price: {price}");
                    Console.WriteLine("====================================================");
                    Console.WriteLine("Enter Product Details or press 'q' to return to main menu");
                }
              
            }
        }
    }
    // public int RemoveProduct(int id) {
    //     // var productToRemove = _products.FirstOrDefault(p => p.Id == id);
    //     // if (productToRemove != null) {
    //     //     _products.Remove(productToRemove);
    //     //     return id;
    //     // }
    //     // return -1; // Return -1 if product not found
    // }

    // public Product SearchProduct(int id) {
    //     // return _products.FirstOrDefault(p => p.Id == id);
    // }

    public double CalculateTotal() {
        return _products.Sum(p => p.getPrice());
    }

    public void ShowProducts() {
        int maxStringLength = GetMaxStringLength();
        IEnumerable<Product> productsQuery = _products.OrderBy(n => n.getPrice());
        ShowTable("Product List", true, productsQuery, false);
        // Console.WriteLine("==== PRODUCT LIST ====");
        // Console.WriteLine($"{"ID",10} | {"Category".PadRight(maxStringLength)} | {"Name".PadRight(maxStringLength)} | {"Price",10}");
        // for (int i = 0; i < maxStringLength*2 + 17; i++) 
        // {
        //     Console.Write("-");
        // }
        // Console.Write("\n");
        // foreach (Product p in productsQuery) {
        //     Console.WriteLine($"{p.getId(),10} | {p.getCategory().PadRight(maxStringLength)} | {p.getName().PadRight(maxStringLength)} | {p.getPrice(),10}");
        // }
        // Console.WriteLine();
        // Console.WriteLine("-----------------------------------");
        // Console.WriteLine($"TOTAL PRICE: {CalculateTotal()} kr");
        // Console.WriteLine("-----------------------------------");
        // Console.WriteLine();
        
    }

    public void SearchProduct() {
        Console.WriteLine("==== SEARCH PRODUCT ====");
        Console.WriteLine("Choose seach mode");
        Console.WriteLine("1 or c - Search by product category");
        Console.WriteLine("2 or n - Search by product name");
        string searchModeInput = Console.ReadLine() ?? "";
        bool isValidSearchMode = searchModeInput.Equals("1") || 
            searchModeInput.Trim().ToLower().Equals("c") ||
            searchModeInput.Equals("2") || 
            searchModeInput.Trim().ToLower().Equals("n");
        while (!isValidSearchMode) 
        {
            Console.WriteLine("Invalid search mode selection. Please enter '1', 'c', '2', or 'n': ");
            searchModeInput = Console.ReadLine() ?? "";
            isValidSearchMode = searchModeInput.Equals("1") || 
                searchModeInput.Trim().ToLower().Equals("c") ||
                searchModeInput.Equals("2") || 
                searchModeInput.Trim().ToLower().Equals("n");
        }
        if (searchModeInput.Equals("1") || 
            searchModeInput.Trim().ToLower().Equals("c")) 
        {
            Console.Write("Enter product category to search: ");
            string categorySearch = Console.ReadLine() ?? "";
            var categoryResults = _products.Where(p => p.getCategory().Equals(categorySearch));
            if (categoryResults.Any()) 
            {
                // Console.WriteLine($"Products in category '{categorySearch}':");
                // foreach (var product in categoryResults) 
                // {
                //     Console.WriteLine($"{"ID",10} | {"Category".PadRight(maxStringLength)} | {"Name".PadRight(maxStringLength)} | {"Price",10}");

                // }
                ShowTable($"Search Results for Category: {categorySearch}", 
                    false,
                    categoryResults,
                    true);
            } else {
                Console.WriteLine($"No products found in category '{categorySearch}'.");
            }
        } 
        else if (searchModeInput.Equals("2") || 
            searchModeInput.Trim().ToLower().Equals("n")) 
        {
            Console.Write("Enter product name to search: ");
            string nameSearch = Console.ReadLine() ?? "";
            var nameResults = _products.Where(p => p.getName().Equals(nameSearch, StringComparison.OrdinalIgnoreCase));
            if (nameResults.Any()) 
            {
                ShowTable($"Search Results for Name: {nameSearch}", 
                    false,
                    nameResults,
                    true);
            } else {
                Console.WriteLine($"No products found with name '{nameSearch}'.");
            }
        }
        else 
        {

        }
       

    }

    private int GetMaxStringLength()
    {
        int maxStringLength = 16;
        Math.Max(maxStringLength, "Category".Length);
        foreach (Product p in _products) {
            int categoryLength = p.getCategory().Length;
            int nameLength = p.getName().Length;
            int longestLength = Math.Max(categoryLength, nameLength);
            if (longestLength > maxStringLength) {
                maxStringLength = longestLength;
            }
        }
        return maxStringLength;
    }

    private void ShowTable(
        string header, 
        bool showPrice, 
        IEnumerable<Product> products,
        bool isSearch) 
    {
        int maxStringLength = GetMaxStringLength();
        Console.WriteLine($"==== {header.ToUpper()} ====");
        Console.WriteLine($"{"ID", 16} | {"Category".PadRight(maxStringLength)} | {"Name".PadRight(maxStringLength)} | {"Price",16}");
        for (int i = 0; i < maxStringLength*2 + 41; i++) 
        {
            Console.Write("-");
        }
        Console.Write("\n");
        if (isSearch)
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        foreach (Product p in products) {
            Console.WriteLine($"{p.getId(), 16} | {p.getCategory().PadRight(maxStringLength)} | {p.getName().PadRight(maxStringLength)} | {p.getPrice(),16}");
        }
        Console.ResetColor();
        Console.WriteLine();
        if (showPrice)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"TOTAL PRICE: {CalculateTotal()} kr");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();  
        }
        
    }
    // ShowStatistics() {
    //     // var categoryGroups = _products.GroupBy(p => p.Category);
    //     // foreach (var group in categoryGroups) {
    //     //     Console.WriteLine($"Category: {group.Key}, Count: {group.Count()}");
    //     // }
    // }

 

}