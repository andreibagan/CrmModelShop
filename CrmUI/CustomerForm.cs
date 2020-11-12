﻿using CrmBL.Model;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class CustomerForm : Form
    {
        public Customer Customer { get; set; }
        public CustomerForm()
        {
            InitializeComponent();
        }

        public CustomerForm(Customer customer) : this()
        {
            Customer = customer;
            textBox1.Text = customer.Name;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Customer customer = Customer ?? new Customer()
            {
                Name = textBox1.Text,
            };
            Customer = customer;
            Close();
        }
    }
}
