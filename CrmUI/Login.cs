using System;
using System.Windows.Forms;
using CrmBL.Model;

namespace CrmUI
{
    public partial class Login : Form
    {
        public Customer Customer { get; set; }

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer = new Customer()
            {
                Name = textBox1.Text,
            };

            DialogResult = DialogResult.OK;
        }
    }
}
