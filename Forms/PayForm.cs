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
            decimal outstanding = amountToPay - paymentAmount;
            if(outstanding < _nullAmount)
            {
                outstanding = Math.Abs(outstanding);
                MessageBox.Show("You've got " + outstanding.ToString() + " change!");
                paymentAmountTextBox.Text = amountToPayTextBox.Text = 0.ToString();

            }
            else
            {
                paymentAmountTextBox.Text = amountToPayTextBox.Text = outstanding.ToString();
            }
            
            if(outstanding == _nullAmount)
            {
                MessageBox.Show("Amount fully paid!");
            }
           

        }
    }
}
