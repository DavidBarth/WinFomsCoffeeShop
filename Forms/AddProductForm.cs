using System.Linq;
using System.Windows.Forms;

namespace CoffeeShop
{
    public partial class AddProductForm : Form
    {
        private CoffeeShopDBEntities _entities = new CoffeeShopDBEntities();


        public AddProductForm()
        {
            InitializeComponent();

            categoryCombobox.DataSource = _entities.tblProductTypes.ToList();
            categoryCombobox.DisplayMember = "Description";
            categoryCombobox.ValueMember = "ProductType";
            
            



        }
    }
}
