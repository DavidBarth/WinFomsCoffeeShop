using System.Windows.Forms;

namespace CoffeeShop
{
    public partial class AddProductForm : Form
    {
        private CoffeeShopDatabaseEntities entities = new CoffeeShopDatabaseEntities();

        public AddProductForm()
        {
            InitializeComponent();
            
            categoryCombobox.ValueMember = "ProductType";
            categoryCombobox.DataSource = entities.ProductTypes;
            categoryCombobox.DisplayMember = "Description";
            


        }
    }
}
