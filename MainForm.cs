using CoffeeShop.Forms;
using System;
using System.Windows.Forms;

namespace CoffeeShop
{
    public partial class Form1 : Form
    {
        //private ContextMenuStrip _contextMenuStrip;
        public Form1()
        {
            InitializeComponent();
            IntializeContextMenu();
        }

        private void IntializeContextMenu()
        {
            this.ContextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem("Exit App");
            ToolStripMenuItem timeMenuItem = new ToolStripMenuItem("Get Time");

            this.ContextMenuStrip.Items.Add(exitMenuItem);
            this.ContextMenuStrip.Items.Add(timeMenuItem);

            exitMenuItem.Click += exitMenuItem_Click;
            timeMenuItem.Click += timeMenuItem_Click;
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timeMenuItem_Click(object sender, EventArgs e)
        {
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
