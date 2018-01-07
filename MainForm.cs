using CoffeeShop.Enum;
using CoffeeShop.Forms;
using CoffeeShop.Model;
using System;
using System.Windows.Forms;

namespace CoffeeShop
{
    public partial class Form1 : Form
    {
        private UserSimulation UserSimulation;

        public Form1()
        {
            InitUserSimulationClass();
            InitializeComponent();
            IntializeContextMenu();
            
        }

        private void InitUserSimulationClass()
        {
            UserSimulation = new UserSimulation();
            UserSimulation.User = new User();
        }

        private void IntializeContextMenu()
        {
            this.ContextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem("Exit App",null, onClick: exitMenuItem_Click);
            ToolStripMenuItem timeMenuItem = new ToolStripMenuItem("Get Time", null, onClick: timeMenuItem_Click);

            this.ContextMenuStrip.Items.Add(exitMenuItem);
            this.ContextMenuStrip.Items.Add(timeMenuItem);
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            if(UserSimulation.User.Role == UserRole.Super)
            Application.Exit();
        }

        private void timeMenuItem_Click(object sender, EventArgs e)
        {
            if (!(UserSimulation.User.Role == UserRole.Super))
            MessageBox.Show(DateTime.Now.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm();
            addProductForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TillForm tillForm = new TillForm();
            tillForm.ShowDialog();
        }
    }
}
