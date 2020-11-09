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

        private void button1_Click(object sender, System.EventArgs e)
        {
            Seller = new Seller()
            {
                Name = textBox1.Text,
            };
            Close();
        }
    }
}
