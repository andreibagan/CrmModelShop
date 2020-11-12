using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrmBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBL.Model.Tests
{
    [TestClass()]
    public class CartTests
    {
        [TestMethod()]
        public void CartTest()
        {
            //Arrenge
            Customer customer = new Customer()
            {
                CustomerId = 1,
                Name = "TestUser",
            };

            Product product1 = new Product()
            {
                ProductId = 1,
                Name = "productTest1",
                Price = 100,
                Count = 10,
            };

            Product product2 = new Product()
            {
                ProductId = 2,
                Name = "productTest2",
                Price = 200,
                Count = 20,
            };

            Cart cart = new Cart(customer);

            List<Product> products = new List<Product>()
            {
                product1,
                product1,
                product2,
            };

            //Act
            cart.Add(product1);
            cart.Add(product1);
            cart.Add(product2);

            List<Product> carProducts = cart.GetAll();

            //Assert
            Assert.AreEqual(products.Count, carProducts.Count);

            for (int i = 0; i < products.Count; i++)
            {
                Assert.AreEqual(products[i], carProducts[i]);
            }
        }

    }
}