using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineOrdering
{
    // Address class
    public class Address
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public Address(string streetAddress, string city, string state, string country)
        {
            StreetAddress = streetAddress;
            City = city;
            State = state;
            Country = country;
        }

        public bool IsInUSA()
        {
            return Country.ToLower() == "usa";
        }

        public string GetFullAddress()
        {
            return $"{StreetAddress}\n{City}, {State}\n{Country}";
        }
    }

    // Customer class
    public class Customer
    {
        public string Name { get; set; }
        public Address Address { get; set; }

        public Customer(string name, Address address)
        {
            Name = name;
            Address = address;
        }

        public bool IsInUSA()
        {
            return Address.IsInUSA();
        }
    }

    // Product class
    public class Product
    {
        public string Name { get; set; }
        public string ProductID { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Product(string name, string productID, decimal price, int quantity)
        {
            Name = name;
            ProductID = productID;
            Price = price;
            Quantity = quantity;
        }

        public decimal GetTotalCost()
        {
            return Price * Quantity;
        }
    }

    // Order class
    public class Order
    {
        public List<Product> Products { get; set; }
        public Customer Customer { get; set; }

        public Order(Customer customer)
        {
            Customer = customer;
            Products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public decimal GetTotalCost()
        {
            decimal totalCost = 0;
            foreach (var product in Products)
            {
                totalCost += product.GetTotalCost();
            }
            totalCost += Customer.IsInUSA() ? 5 : 35; // Shipping cost
            return totalCost;
        }

        public string GetPackingLabel()
        {
            StringBuilder packingLabel = new StringBuilder();
            foreach (var product in Products)
            {
                packingLabel.AppendLine($"{product.Name} ({product.ProductID})");
            }
            return packingLabel.ToString();
        }

        public string GetShippingLabel()
        {
            return $"{Customer.Name}\n{Customer.Address.GetFullAddress()}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create address objects
            Address address1 = new Address("123 Elm St", "Springfield", "IL", "USA");
            Address address2 = new Address("456 Oak Ave", "Metropolis", "NY", "USA");
            Address address3 = new Address("789 Pine Rd", "Toronto", "ON", "Canada");

            // Create customer objects
            Customer customer1 = new Customer("John Doe", address1);
            Customer customer2 = new Customer("Jane Smith", address2);
            Customer customer3 = new Customer("Alice Brown", address3);

            // Create order objects and add products
            Order order1 = new Order(customer1);
            order1.AddProduct(new Product("Laptop", "P001", 799.99m, 1));
            order1.AddProduct(new Product("Mouse", "P002", 19.99m, 2));

            Order order2 = new Order(customer2);
            order2.AddProduct(new Product("Smartphone", "P003", 599.99m, 1));
            order2.AddProduct(new Product("Charger", "P004", 29.99m, 3));

            Order order3 = new Order(customer3);
            order3.AddProduct(new Product("Tablet", "P005", 299.99m, 1));
            order3.AddProduct(new Product("Stylus", "P006", 49.99m, 1));

            // Create a list to store orders
            List<Order> orders = new List<Order> { order1, order2, order3 };

            // Display order details
            foreach (var order in orders)
            {
                Console.WriteLine($"Customer: {order.Customer.Name}");
                Console.WriteLine($"Shipping Address:\n{order.GetShippingLabel()}");
                Console.WriteLine("Packing List:");
                Console.WriteLine(order.GetPackingLabel());
                Console.WriteLine($"Total Cost: {order.GetTotalCost():C}\n");
            }
        }
    }
}
