using System;
using System.Windows.Forms;
using CrmBL.Model;

namespace CrmUI
{
    public partial class Main : Form
    {
        CrmContext _dbContext;

        public Main()
        {
            InitializeComponent();
            _dbContext = new CrmContext();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalog<Product> catalog = new Catalog<Product>(_dbContext.Products, _dbContext);
            catalog.Show();
        }    

        private void sellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalog<Seller> catalog = new Catalog<Seller>(_dbContext.Sellers, _dbContext);
            catalog.Show();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalog<Customer> catalog = new Catalog<Customer>(_dbContext.Customers, _dbContext);
            catalog.Show();
        }

        private void checkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalog<Check> catalog = new Catalog<Check>(_dbContext.Checks, _dbContext);
            catalog.Show();
        }

        private void customerAddToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();

            if (customerForm.ShowDialog() == DialogResult.OK)
            {
                _dbContext.Customers.Add(customerForm.Customer);
                _dbContext.SaveChanges();
            }
        }

        private void sellerAddToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SellerForm sellerForm = new SellerForm();

            if (sellerForm.ShowDialog() == DialogResult.OK)
            {
                _dbContext.Sellers.Add(sellerForm.Seller);
                _dbContext.SaveChanges();
            }
        }

        private void productAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm();

            if (productForm.ShowDialog() == DialogResult.OK)
            {
                _dbContext.Products.Add(productForm.Product);
                _dbContext.SaveChanges();
            }
        }
    }
}
