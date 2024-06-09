using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineOrdering
{
    // Address class
    public class Address
    {
        private string _streetAddress;
        private string _city;
        private string _state;
        private string _country;

        public Address(string streetAddress, string city, string state, string country)
        {
            _streetAddress = streetAddress;
            _city = city;
            _state = state;
            _country = country;
        }

        public string StreetAddress
        {
            get { return _streetAddress; }
            set { _streetAddress = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string State
        {
            get { return _state; }
            set { _state = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public bool IsInUSA()
        {
            return _country.ToLower() == "usa";
        }

        public string GetFullAddress()
        {
            return $"{_streetAddress}\n{_city}, {_state}\n{_country}";
        }
    }

    // Customer class
    public class Customer
    {
        private string _name;
        private Address _address;

        public Customer(string name, Address address)
        {
            _name = name;
            _address = address;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Address Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public bool IsInUSA()
        {
            return _address.IsInUSA();
        }
    }

    // Product class
    public class Product
    {
        private string _name;
        private string _productID;
        private decimal _price;
        private int _quantity;

        public Product(string name, string productID, decimal price, int quantity)
        {
            _name = name;
            _productID = productID;
            _price = price;
            _quantity = quantity;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string ProductID
        {
            get { return _productID; }
            set { _productID = value; }
        }

        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public decimal GetTotalCost()
        {
            return _price * _quantity;
        }
    }

    // Order class
    public class Order
    {
        private List<Product> _products;
        private Customer _customer;

        public Order(Customer customer)
        {
            _customer = customer;
            _products = new List<Product>();
        }

        public List<Product> Products
        {
            get { return _products; }
            set { _products = value; }
        }

        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public decimal GetTotalCost()
        {
            decimal totalCost = 0;
            foreach (var product in _products)
            {
                totalCost += product.GetTotalCost();
            }
            totalCost += _customer.IsInUSA() ? 5 : 35; // Shipping cost
            return totalCost;
        }

        public string GetPackingLabel()
        {
            StringBuilder packingLabel = new StringBuilder();
            foreach (var product in _products)
            {
                packingLabel.AppendLine($"{product.Name} ({product.ProductID})");
            }
            return packingLabel.ToString();
        }

        public string GetShippingLabel()
        {
            return $"{_customer.Name}\n{_customer.Address.GetFullAddress()}";
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
