using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrmBL.Model;
using System;

namespace CrmBL.Model.Tests
{
    [TestClass()]
    public class CashDeskTests
    {
        [TestMethod()]
        public void CashDeskTest()
        {
            //Arrange
            Customer customer1 = new Customer()
            {
                CustomerId = 1,
                Name = "testUser1"
            };

            Customer customer2 = new Customer()
            {
                CustomerId = 2,
                Name = "testUser2"
            };

            Seller seller = new Seller()
            {
                SellerId = 1,
                Name = "testSeller"
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

            Cart cart1 = new Cart(customer1);

            cart1.Add(product1);
            cart1.Add(product1);
            cart1.Add(product2);

            Cart cart2 = new Cart(customer2);

            cart2.Add(product1);
            cart2.Add(product2);
            cart2.Add(product2);

            CashDesk cashDesk = new CashDesk(1, seller);
            cashDesk.MaxQueueLenght = 10;
            cashDesk.Enqueue(cart1);
            cashDesk.Enqueue(cart2);

            int cartResult1 = 400;
            int cartResult2 = 500;

            //Act
            decimal cartActualResult1 = cashDesk.Dequeue();
            decimal cartActualResult2 = cashDesk.Dequeue();

            //Assert
            Assert.AreEqual(cartResult1, cartActualResult1);
            Assert.AreEqual(cartResult2, cartActualResult2);
            Assert.AreEqual(7, product1.Count);
            Assert.AreEqual(17, product2.Count);
        }
    }
}