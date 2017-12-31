using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace CoffeeShop.Forms
{
    public partial class ListProductsForm : Form
    {
        private Database _entities = new Database();
        private BindingList<tblProduct> _productsList = new BindingList<tblProduct>();
         
        public ListProductsForm()
        {
            InitializeComponent();
            chosenProductListBox.DataSource = _productsList;
            chosenProductListBox.DisplayMember = "Description";
            PopulateTabs();
            
        }

        private void PopulateTabs()
        {
            
            foreach(tblProductType productType in _entities.tblProductTypes)
            {
                tabControl1.TabPages.Add(productType.ProductType.ToString(), productType.Description);
            }

            int i = 1;
            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                var filteredProducts = _entities.tblProducts.Where(p => (int)p.tblProductType.ProductType == i);
                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                flowLayoutPanel.Dock = DockStyle.Fill;
                foreach(tblProduct product in filteredProducts)
                {
                    Button flowLayoutPanelButton = new Button();
                    flowLayoutPanelButton.Click += FlowLayoutPanelButton_Click;
                    flowLayoutPanelButton.Tag = product;
                    flowLayoutPanelButton.Text = product.Description;
                    flowLayoutPanel.Controls.Add(flowLayoutPanelButton);
                    tabPage.Controls.Add(flowLayoutPanel);
                }
                i++;
            }         
        }

        private void FlowLayoutPanelButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            tblProduct product = (tblProduct)button.Tag;
            _productsList.Add(product);
                         
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
