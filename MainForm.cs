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
            IntializeContextMenu();
        }

        private void IntializeContextMenu()
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem toolstripMenuItem = new ToolStripMenuItem("Exit App");
            toolstripMenuItem.Name = "Exit";
            contextMenuStrip.Items.Add(toolstripMenuItem);
            toolstripMenuItem.Click += menuItem_Click;
            this.ContextMenuStrip = contextMenuStrip;
        }

        private void menuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
