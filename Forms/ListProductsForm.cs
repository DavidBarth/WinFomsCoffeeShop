using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CoffeeShop.Forms
{
    public partial class ListProductsForm : Form
    {
        private Database _entities = new Database();
         
        public ListProductsForm()
        {
            InitializeComponent();
        }

        private void ListProductsForm_Load(object sender, EventArgs e)
        {
            var products = new List<tblProduct>();
            foreach(var product in _entities.tblProducts)
            {
                products.Add(product);
            }

            chosenProductListBox.DataSource = products;

        }

        private void FormatListItem(object sender, ListControlConvertEventArgs e)
        {
            string currentDescription = ((tblProduct)e.ListItem).Description;
            string currentPrice =String.Format("{0:c}",((tblProduct)e.ListItem).Price);
            currentDescription += currentDescription.PadRight(30);
            string formattedString = currentDescription + currentPrice;
            e.Value = formattedString;
            



        }
    }
}
