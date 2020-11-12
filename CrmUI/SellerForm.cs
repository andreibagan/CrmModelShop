using CrmBL.Model;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class SellerForm : Form
    {
        public Seller Seller { get; set; }
        public SellerForm()
        {
            InitializeComponent();
        }

        public SellerForm(Seller seller) : this()
        {
            Seller = seller;
            textBox1.Text = seller.Name;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Seller seller = Seller ?? new Seller()
            {
                Name = textBox1.Text,
            };
            Seller = seller;
            Close();
        }
    }
}
