using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ticketing
{
    public partial class TicketsForm : Form
    {
        TicketPrice mTicketPrice;
        int mSection = 2;
        int mQuantity = 0;
        bool mDiscount = false;
        decimal discount = 5;
        bool mChild = false;


        public TicketsForm()
        {
            InitializeComponent();
        }

        private void TicketsForm_Load(object sender, EventArgs e)
        {

        }

        private void cmdCalculate_Click(object sender, EventArgs e)
        {
            mDiscount = false;
            mChild = false;
            mQuantity = int.Parse(txtQuantity.Text);
            discount = decimal.Parse(txtDiscount.Text);

            if (chkDiscount.Checked)
                { mDiscount = true; }
            if(chkChild.Checked)
            {
                mChild = true;
            }
            if (radBalcony.Checked)
            {
                mSection = 1;            
            }
            if (radGeneral.Checked)
                { mSection = 2; }
            if (radBox.Checked)
                { mSection = 3; }

            mTicketPrice = new TicketPrice(mSection, mQuantity, mDiscount, mChild,discount);

            mTicketPrice.calculatePrice();
            lblAmount.Text = System.Convert.ToString(mTicketPrice.AmountDue);
        }
    }
}
