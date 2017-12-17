using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CoffeeShop
{
    public partial class AddProductForm : Form
    {
        private CoffeeShopDBEntities _entities = new CoffeeShopDBEntities();

        private byte[] _dataBlob;

        public AddProductForm()
        {
            InitializeComponent();

            categoryCombobox.DataSource = _entities.tblProductTypes.ToList();
            categoryCombobox.DisplayMember = "Description";
            categoryCombobox.ValueMember = "ProductType";
        }

        private void uploadButton_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog fileUploadDialog = new OpenFileDialog();
            fileUploadDialog.Title = "Image Upload Window";
            fileUploadDialog.Filter = "Jpeg files (*.jpg)|*.jpg|Png files (*.png)|*.png|All files (*.*)|*.*";

            if(fileUploadDialog.ShowDialog() == DialogResult.OK)
            {
                Stream fileStream = new FileStream(fileUploadDialog.FileName,FileMode.Open, FileAccess.Read);

                _dataBlob = new byte[fileStream.Length];

                fileStream.Read(_dataBlob, 0, _dataBlob.Length);

                fileStream.Close();

                MemoryStream memoryStream = new MemoryStream(_dataBlob);

                pictureBox1.Image = Image.FromStream(memoryStream);
            }
        }

        private void saveButton_Click(object sender, System.EventArgs e)
        {
            tblProduct productToSave = new tblProduct();
            productToSave.Description = DescriptionTextBox.Text;
            productToSave.Price = decimal.Parse(priceTextBox.Text);
            productToSave.Image = _dataBlob;
            productToSave.ProductType = (int)categoryCombobox.SelectedValue;



            _entities.tblProducts.Add(productToSave);
            _entities.SaveChanges();
        }
    }
}
