using System.Windows.Forms;

namespace CoffeeShop.Forms
{
    public partial class PayForm : Form
    {
        public PayForm()
        {
            InitializeComponent();
            amountToPayTextBox.ReadOnly = true;
        }
    }
}
