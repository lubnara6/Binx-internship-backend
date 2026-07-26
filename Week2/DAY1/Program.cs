using Day1;

Console.WriteLine("=== Generic Repository Lab ===");
Console.WriteLine();

Repository<Product> productRepository = new();

productRepository.Add(new Product
{
    Id = 1,
    Name = "Laptop",
    Price = 1200m
});

productRepository.Add(new Product
{
    Id = 2,
    Name = "Keyboard",
    Price = 80m
});

productRepository.Add(new Product
{
    Id = 3,
    Name = "Mouse",
    Price = 35m
});

Console.WriteLine("Products:");

IReadOnlyList<Product> products = productRepository.GetAll();

foreach (Product product in products)
{
    Console.WriteLine(product);
}


Product? foundProduct =
    productRepository.Find(product => product.Id == 2);

Console.WriteLine();
Console.WriteLine("Product search result:");
//check if the foundProduct is not null before printing it
if (foundProduct is not null)
{
    Console.WriteLine(foundProduct);
}
else
{
    Console.WriteLine("Product was not found.");
}

Console.WriteLine();

// Create another repository using a different domain type.
Repository<Order> orderRepository = new();

orderRepository.Add(new Order
{
    Id = 101,
    CustomerName = "Ahmad",
    Total = 250m
});

orderRepository.Add(new Order
{
    Id = 102,
    CustomerName = "Sara",
    Total = 475m
});

Console.WriteLine("Orders:");

IReadOnlyList<Order> orders = orderRepository.GetAll();

foreach (Order order in orders)
{
    Console.WriteLine(order);
}

Order? foundOrder =
    orderRepository.Find(order => order.CustomerName == "Sara");

Console.WriteLine();
Console.WriteLine("Order search result:");

if (foundOrder is not null)
{
    Console.WriteLine(foundOrder);
}
else
{
    Console.WriteLine("Order was not found.");
}