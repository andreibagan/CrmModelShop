using CrmBL.Model;
using System;
using System.Data.Entity;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class Catalog<T> : Form
        where T : class
    {
        CrmContext _dbContext;
        DbSet<T> _set;

        public Catalog(DbSet<T> set, CrmContext dbcontext)
        {
            InitializeComponent();

            _set = set;
            _dbContext = dbcontext;
            set.Load();
            dataGridView1.DataSource = set.Local.ToBindingList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (typeof(T) == typeof(Product))
            {
                ProductForm productForm = new ProductForm();
                //ProductForm productForm = new ProductForm();

                //if (productForm.ShowDialog() == DialogResult.OK)
                //{
                //    db.Products.Add(productForm.Product);
                //    db.SaveChanges();
                //}
            }
            else if (typeof(T) == typeof(Seller))
            {

            }
            else if (typeof(T) == typeof(Customer))
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;

            if (typeof(T) == typeof(Product))
            {
                Product product = _set.Find(id) as Product;

                if (product != null)
                {
                    ProductForm productForm = new ProductForm(product);

                    if (productForm.ShowDialog() == DialogResult.OK)
                    {
                        product = productForm.Product; 
                        _dbContext.SaveChanges();
                        dataGridView1.Update(); 
                    }
                }
            }
            else if (typeof(T) == typeof(Seller))
            {
                Seller seller = _set.Find(id) as Seller;

                if (seller != null)
                {
                    SellerForm sellerForm = new SellerForm(seller);

                    if (sellerForm.ShowDialog() == DialogResult.OK)
                    {
                        seller = sellerForm.Seller;
                        _dbContext.SaveChanges();
                        dataGridView1.Update();
                    }
                }
            }
            else if (typeof(T) == typeof(Customer))
            {
                Customer customer = _set.Find(id) as Customer;

                if (customer != null)
                {
                    CustomerForm customerForm = new CustomerForm(customer);

                    if (customerForm.ShowDialog() == DialogResult.OK)
                    {
                        customer = customerForm.Customer;
                        _dbContext.SaveChanges();
                        dataGridView1.Update();
                    }
                }
            }
        }
    }
}
