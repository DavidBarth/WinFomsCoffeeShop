using CoffeeShop.Forms;
using System;
using System.Windows.Forms;

namespace CoffeeShop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm();
            addProductForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListProductsForm listProductForm = new ListProductsForm();
            listProductForm.ShowDialog();
        }
    }
}
