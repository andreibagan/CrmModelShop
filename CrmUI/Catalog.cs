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

        public Catalog(DbSet<T> set, CrmContext dbcontext)
        {
            InitializeComponent();
            _dbContext = dbcontext;
            set.Load();
            dataGridView1.DataSource = set.Local.ToBindingList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (typeof(T) == typeof(Product))
            {
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

        }
    }
}
