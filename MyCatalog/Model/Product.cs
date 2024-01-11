namespace MyCatalog.Model;
public record Product(int Id, string Name, string? Description, decimal Price);


//public class Product(int id, string name, string description, decimal price)
//{
//    public int Id { get; } = id;
//    public string Name { get; } = name;
//    public string? Description { get; } = description;
//    public decimal Price { get; } = price;

//}


//public record Product1
//{
//    public required int Id { get; init; }
//    public string Name { get; init; } = default!;
//    public string? Description { get; init; }
//    public decimal Price { get; init; }

//}
