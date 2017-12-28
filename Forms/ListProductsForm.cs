using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CoffeeShop.Forms
{
    public partial class ListProductsForm : Form
    {
        private Database _entities = new Database();
         
        public ListProductsForm()
        {
            InitializeComponent();
            PopulateTabs();
            
        }

        private void PopulateTabs()
        {
            int i = 1;
            foreach(tblProductType productType in _entities.tblProductTypes)
            {
                tabControl1.TabPages.Add(productType.ProductType.ToString(), productType.Description);
            }

            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                var filteredProducts = _entities.tblProducts.Where(p => (int)p.tblProductType.ProductType == i);
                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                flowLayoutPanel.Dock = DockStyle.Fill;
                foreach(var product in filteredProducts)
                {
                    Button flowLayoutPanelButton = new Button();
                    flowLayoutPanel.Controls.Add(flowLayoutPanelButton);
                    tabPage.Controls.Add(flowLayoutPanel);
                }
                i++;
            }         
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
