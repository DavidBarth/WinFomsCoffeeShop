using System;
using System.Windows.Forms;

namespace CoffeeShop.Forms
{
    public partial class PayForm : Form
    {
        private const int _nullAmount = 0;

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
            decimal outstanding = _nullAmount;
            if(paymentAmount >= amountToPay)
            {
                outstanding = Math.Abs(amountToPay - paymentAmount);
                MessageBox.Show("You've got " + outstanding.ToString() + " change!");
                paymentAmountTextBox.Text = amountToPayTextBox.Text = _nullAmount.ToString();
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
