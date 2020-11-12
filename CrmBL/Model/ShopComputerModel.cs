using System;
using System.Collections.Generic;

namespace CrmBL.Model
{
    public class ShopComputerModel
    {
        Generator Generator = new Generator();
        Random random = new Random();

        public List<CashDesk> CashDesks { get; set; } = new List<CashDesk>();
        public List<Cart> Carts { get; set; } = new List<Cart>();
        public List<Check> Checks { get; set; } = new List<Check>();
        public List<Sell> Sells { get; set; } = new List<Sell>();
        public Queue<Seller> Sellers { get; set; } = new Queue<Seller>(); 

        public ShopComputerModel()
        {
            List<Seller> sellers = Generator.GetNewSellers(20);
            Generator.GetNewProducts(1000);
            Generator.GetNewCustomers(100);

            foreach (Seller seller in sellers)
            {
                Sellers.Enqueue(seller);
            }

            for (int i = 0; i < 3; i++)
            {
                CashDesks.Add(new CashDesk(CashDesks.Count, Sellers.Dequeue()));
            }
        }

        public void Start()
        {
            List<Customer> customers = Generator.GetNewCustomers(10);

            Queue<Cart> carts = new Queue<Cart>();

            foreach (Customer customer in customers)
            {
                Cart cart = new Cart(customer);

                foreach (Product product in Generator.GetRandomProduct(10, 30))
                {
                    cart.Add(product);
                }

                carts.Enqueue(cart);
            }

            while(carts.Count > 0)
            { 
                CashDesk cashDesk = CashDesks[random.Next(CashDesks.Count - 1)];
                cashDesk.Enqueue(carts.Dequeue()); 
            }

            while(true)
            {
                CashDesk cashDesk = CashDesks[random.Next(CashDesks.Count - 1)];
                cashDesk.Dequeue();
            }
        }
    }
}
