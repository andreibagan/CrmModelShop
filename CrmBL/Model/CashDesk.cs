using System;
using System.Collections.Generic;

namespace CrmBL.Model
{
    public class CashDesk
    {
        CrmContext _dbContext = new CrmContext();

        public int Number { get; set; }
        public Seller Seller { get; set; }
        public Queue<Cart> Queue { get; set; }
        public int MaxQueueLenght { get; set; }
        public int ExitCustomer { get; set; }
        public bool isModel { get; set; }

        public CashDesk(int number, Seller seller)
        {
            Number = number;
            Seller = seller;
            Queue = new Queue<Cart>();
            isModel = true;
        }

        public void Enqueue(Cart cart)
        {
            if (Queue.Count <= MaxQueueLenght)
            {
                Queue.Enqueue(cart);
            }
            else
            {
                ExitCustomer++;
            }
        }

        public decimal Dequeue()
        {
            decimal sum = 0;

            Cart cart = Queue.Dequeue();

            if (cart != null)
            {
                Check check = new Check()
                {
                    SellerId = Seller.SellerId,
                    Seller = Seller,
                    CustomerId = cart.Customer.CustomerId,
                    Customer = cart.Customer,
                    Created = DateTime.Now,
                };

                if (!isModel)
                {
                    _dbContext.Checks.Add(check);
                    _dbContext.SaveChanges();
                }
                else
                {
                    check.CheckId = 0;
                }

                List<Sell> sells = new List<Sell>();

                foreach (Product product in cart)
                {
                    if (product.Count > 0)
                    {
                        Sell sell = new Sell()
                        {
                            CheckId = check.CheckId,
                            Check = check,
                            ProductId = product.ProductId,
                            Product = product
                        };

                        sells.Add(sell);

                        if (!isModel)
                        {
                            _dbContext.Sells.Add(sell);
                        }

                        product.Count--;
                        sum += product.Price;
                    }
                }

                if (!isModel)
                {
                    _dbContext.SaveChanges();
                }
            }

            return sum;
        }
    }
}
