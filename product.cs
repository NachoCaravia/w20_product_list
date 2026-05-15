namespace ProductList
{
    public class Product
    {
        public int Id { get; }
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(int id, string category, string name, decimal price) 
        {
            Id = id;
            Category = category;
            Name = name;
            Price = price;
        }
    }
}