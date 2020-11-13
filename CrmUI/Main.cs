using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrmBL.Model;

namespace CrmUI
{
    public partial class Main : Form
    {
        CrmContext _dbContext;
        Cart cart;
        Customer customer;
        CashDesk cashDesk;

        public Main()
        {
            InitializeComponent();
            _dbContext = new CrmContext();

            cart = new Cart(customer);
            cashDesk = new CashDesk(1, _dbContext.Sellers.FirstOrDefault(), _dbContext)
            {
                isModel = false,
            };
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

        private void modelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ModelForm();
            form.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                listBox1.Invoke((Action)delegate
                {
                    listBox1.Items.AddRange(_dbContext.Products.ToArray());
                    UpdateLists();
                });
             
            });
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Product product)
            {
                cart.Add(product);
                listBox2.Items.Add(product);
                UpdateLists();
            }
        }

        private void UpdateLists()
        {
            listBox2.Items.Clear();
            listBox2.Items.AddRange(cart.GetAll().ToArray());
            label1.Text = "Итого: " + cart.Price;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new Login();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                var tempCustomer = _dbContext.Customers.FirstOrDefault(c => c.Name.Equals(form.Customer.Name));
                if (tempCustomer != null)
                {
                    customer = tempCustomer;
                }
                else
                {
                    _dbContext.Customers.Add(form.Customer);
                    _dbContext.SaveChanges();
                    customer = form.Customer;
                }

                cart.Customer = customer;
            }

            linkLabel1.Text = $"Здравствуй, {customer.Name}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (customer != null)
            {
                cashDesk.Enqueue(cart);
                var price = cashDesk.Dequeue();
                listBox2.Items.Clear();
                cart = new Cart(customer);

                MessageBox.Show("Покупка выполнена успешно. Сумма: " + price, "Покупка выполнена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Авторизуйтесь, пожалуйста!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
