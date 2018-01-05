using System;
using System.Windows.Forms;

namespace CoffeeShop.Forms
{
    public partial class PayForm : Form
    {

        public PayForm()
        {
            
        }

        public PayForm(decimal transactionTotal)
        {
            InitializeComponent();
            amountToPayTextBox.ReadOnly = true;
            amountToPayTextBox.Text = transactionTotal.ToString();
        }

        private void okButton_Click(object sender, System.EventArgs e)
        {
            var amountToPay =  Convert.ToDecimal(amountToPayTextBox.Text);
            var paymentAmount = Convert.ToDecimal(paymentAmountTextBox.Text);
            decimal outstanding = 0;
            if(amountToPay < paymentAmount)
            {
                outstanding = Math.Abs(amountToPay - paymentAmount);
                MessageBox.Show("You've got " + outstanding.ToString() + " change!");
                paymentAmountTextBox.Text = amountToPayTextBox.Text = 0.ToString();
                MessageBox.Show("Amount fully paid!");

            }
            else
            {
                outstanding = amountToPay - paymentAmount;
                paymentAmountTextBox.Text = amountToPayTextBox.Text = outstanding.ToString();
            }
        }
    }
}
