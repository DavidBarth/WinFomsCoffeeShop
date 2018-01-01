using System;
using System.Windows.Forms;

namespace CoffeeShop.Forms
{
    public partial class PayForm : Form
    {
        private decimal _transactionTotal;

        public PayForm()
        {
            
        }

        public PayForm(decimal transactionTotal)
        {
            InitializeComponent();
            amountToPayTextBox.ReadOnly = true;
            this._transactionTotal = transactionTotal;
            amountToPayTextBox.Text = transactionTotal.ToString();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            var amountToPay =  Convert.ToDecimal(amountToPayTextBox.Text);
            var paymentAmount = Convert.ToDecimal(paymentAmountTextBox.Text);
            decimal outstanding = 0;
            if(paymentAmount > amountToPay)
            {
                outstanding = amountToPay - paymentAmount;
                outstanding = Math.Abs(outstanding);
                MessageBox.Show("You've got " + outstanding.ToString() + " change!");
                paymentAmountTextBox.Text = amountToPayTextBox.Text = 0.ToString();

            }
            else
            {
                outstanding = amountToPay - paymentAmount;
                paymentAmountTextBox.Text = amountToPayTextBox.Text = outstanding.ToString();
            }
           

        }
    }
}
