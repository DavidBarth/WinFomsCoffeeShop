namespace CoffeeShop.Forms
{
    partial class ListProductsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chosenProductListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // chosenProductListBox
            // 
            this.chosenProductListBox.FormattingEnabled = true;
            this.chosenProductListBox.Location = new System.Drawing.Point(270, 12);
            this.chosenProductListBox.Name = "chosenProductListBox";
            this.chosenProductListBox.Size = new System.Drawing.Size(312, 225);
            this.chosenProductListBox.TabIndex = 0;
            this.chosenProductListBox.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.FormatListItem);
            // 
            // ListProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 308);
            this.Controls.Add(this.chosenProductListBox);
            this.Name = "ListProductsForm";
            this.Text = "ListProductsForm";
            this.Load += new System.EventHandler(this.ListProductsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox chosenProductListBox;
    }
}