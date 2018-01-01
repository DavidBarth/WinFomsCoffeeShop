using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace CoffeeShop.Forms
{
    public partial class TillForm : Form
    {
        private Database _entities = new Database();
        private BindingList<tblProduct> _productsList = new BindingList<tblProduct>();

        private decimal _transactionTotal;
        public decimal TransactionTotal
        {
            get { return _transactionTotal; }
            set
            {
                _transactionTotal = value;
                totalTextBox.Text = _transactionTotal.ToString();
            }
        }
         
        public TillForm()
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
            TransactionTotal += (decimal)product.Price;
                         
        }

        private void FormatListItem(object sender, ListControlConvertEventArgs e)
        {
            string currentDescription = ((tblProduct)e.ListItem).Description;
            string currentPrice = String.Format("{0:c}",((tblProduct)e.ListItem).Price);
            currentDescription += currentDescription.PadRight(30);
            string formattedString = currentDescription + currentPrice;
            e.Value = formattedString;
        }

        private void removeItemButton_Click(object sender, EventArgs e)
        {
            if(chosenProductListBox.SelectedItem == null) 
            {
                MessageBox.Show("Product list is empty");
            }
            else
            {
                var product = chosenProductListBox.SelectedItem as tblProduct;
                if (product == null) return;
                if (product.Price.HasValue)
                {
                    TransactionTotal -= (decimal)product.Price;
                    _productsList.Remove(product);
                }
            }

        }

        private void payButton_Click(object sender, EventArgs e)
        {
            PayForm payForm = new PayForm(TransactionTotal);
            payForm.ShowDialog();
        }
    }
}
