using System;
using System.Windows.Forms;
using CrmBL.Model;

namespace CrmUI
{
    public partial class Main : Form
    {
        CrmContext db;

        public Main()
        {
            InitializeComponent();
            db = new CrmContext();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalog<Product> catalog = new Catalog<Product>(db.Products);
            catalog.Show();
        }    

        private void sellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalog<Seller> catalog = new Catalog<Seller>(db.Sellers);
            catalog.Show();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalog<Customer> catalog = new Catalog<Customer>(db.Customers);
            catalog.Show();
        }

        private void checkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalog<Check> catalog = new Catalog<Check>(db.Checks);
            catalog.Show();
        }

        private void customerAddToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();

            if (customerForm.ShowDialog() == DialogResult.OK)
            {
                db.Customers.Add(customerForm.Customer);
                db.SaveChanges();
            }
        }
    }
}
