public class Product
{
    public int Id { get; }
    public string Category { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }

    public Product(int id, string category, string name, double price) 
    {
        Id = id;
        Category = category;
        Name = name;
        Price = price;
    }

    public int getId() 
    {
        return Id;
    }

    public string getCategory() 
    {
        return Category;
    }
    public string getName() 
    {
        return Name;
    }
    public double getPrice() 
    {
        return Price;
    }
    public override string ToString()
    {
        return $"Product :Category={Category}, Name={Name}, Price={Price}";
    }
}