
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
    // public ShowProducts() {
    //     // foreach (var product in _products) {
    //     //     Console.WriteLine(product);
    //     // }
    // }
    // ShowStatistics() {
    //     // var categoryGroups = _products.GroupBy(p => p.Category);
    //     // foreach (var group in categoryGroups) {
    //     //     Console.WriteLine($"Category: {group.Key}, Count: {group.Count()}");
    //     // }
    // }

}