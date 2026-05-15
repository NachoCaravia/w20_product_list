// using Product;
namespace ProductList {
    public class ProductManager 
    {
        private readonly List<Product> _products = new List<Product>();
        private int _nextId = 1;


        public string AddProduct( string category, string name, decimal price) {
            
            int newId = _nextId++;
            newProduct = new Product(newId, category, name, price);
            _products.Add(newProduct);

            return "ok";
        }
    }
}