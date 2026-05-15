
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
    public void ShowProducts() {
        int maxStringLength = 8;

        foreach (var product in _products) {
            int categoryLength = product.getCategory().Length;
            int nameLength = product.getName().Length;
            int longestLength = Math.Max(categoryLength, nameLength);
            if (longestLength > maxStringLength) {
                maxStringLength = longestLength;
            }
        }


        Console.WriteLine("==== PRODUCT LIST ====");
        Console.WriteLine($" {"Category".PadRight(maxStringLength)} | {"Name".PadRight(maxStringLength)} |Price");
        for (int i = 0; i < maxStringLength*2 + 17; i++) 
        {
            Console.Write("-");
        }
        Console.Write("\n");
        foreach (var product in _products) {
            Console.WriteLine($" {product.getCategory().PadRight(maxStringLength)} | {product.getName().PadRight(maxStringLength)} | {product.getPrice(),10}");
        }
        Console.WriteLine();
        Console.WriteLine("=====================");
    }
    // ShowStatistics() {
    //     // var categoryGroups = _products.GroupBy(p => p.Category);
    //     // foreach (var group in categoryGroups) {
    //     //     Console.WriteLine($"Category: {group.Key}, Count: {group.Count()}");
    //     // }
    // }

}