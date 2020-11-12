using System;
using System.Collections.Generic;

namespace CrmBL.Model
{
    public class Generator
    {
        Random random = new Random();

        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Seller> Sellers { get; set; } = new List<Seller>();

        public List<Customer> GetNewCustomers(int count)
        {
            List<Customer> result = new List<Customer>();

            for (int i = 0; i < count; i++)
            {
                Customer customer = new Customer()
                {
                    CustomerId = Customers.Count,
                    Name = GetRandomText(),
                };

                Customers.Add(customer);
                result.Add(customer);
            }

            return result;
        }

        public List<Seller> GetNewSellers(int count)
        {
            List<Seller> result = new List<Seller>();

            for (int i = 0; i < count; i++)
            {
                Seller seller = new Seller()
                {
                    SellerId = Sellers.Count,
                    Name = GetRandomText(),
                };

                Sellers.Add(seller);
                result.Add(seller);
            }

            return result;
        }

        public List<Product> GetNewProducts(int count)
        {
            List<Product> result = new List<Product>();

            for (int i = 0; i < count; i++)
            {
                Product product = new Product()
                {
                    ProductId = Products.Count,
                    Name = GetRandomText(),
                    Price = Convert.ToDecimal(random.Next(5, 100000) + random.NextDouble()),
                    Count = random.Next(10, 1000),
                };

                Products.Add(product);
                result.Add(product);
            }

            return result;
        }

        private static string GetRandomText()
        {
            return Guid.NewGuid().ToString().Substring(0, 5);
        }

        public List<Product> GetRandomProduct(int min, int max)
        {
            List<Product> products = new List<Product>();

            int count = random.Next(min, max);
            for (int i = 0; i < count; i++)
            {
                products.Add(Products[random.Next(Products.Count - 1)]);
            }

            return products;
        }
    }
    
}
