using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS140_Project_1 {
    public partial class whataLottaSprinklesForm: Form {
        public whataLottaSprinklesForm() {
            InitializeComponent();
        }

        private void otherLocationsButton_Click(object sender, EventArgs e) {
            //this is to show two other ice cream locations that we recommand that have simliar flavors to ours.
            MessageBox.Show("Sorry no other locations. We don't make enough to open other stores.\n\nBut you can check out these other locations.\n\t18030 Brookhurst St, Fountain Valley, CA 92708\n\t7451 Warner Ave, Huntington Beach, CA 92647");
        }

        //when a user clicks on the apply online button they get hired
        private void applyButton_Click(object sender, EventArgs e) {
            if (applyCheckBox.Checked == true) {
                MessageBox.Show("Congratulation! You applied for this job");
                //reset the check box to empty
                applyCheckBox.Checked = false;
            } else {
                //if the user doesn't agree with our terms of service they can work somewhere else.
                MessageBox.Show("Please Agree to our Terms of Service.");
            }
        }

        private bool nextLabelWasClicked = false;

        private void nextLabel_Click(object sender, EventArgs e) {
            nextLabelWasClicked = true;

            if (nextLabelWasClicked == true && defaultConePictureBox.Visible == true) {
                defaultConePictureBox.Visible = false;
                flavorsPictureBox.Visible = false;
                smallConePictureBox.Visible = true;
                previousLabel.Visible = true;
                nextLabelWasClicked = false;
            }
            if (smallConePictureBox.Visible == true && nextLabelWasClicked == true) {
                defaultConePictureBox.Visible = false;
                smallConePictureBox.Visible = false;
                flavorsPictureBox.Visible = true;
                nextLabel.Visible = false;
                previousLabel.Visible = true;
                //nextLabelWasClicked = false;
            }
        }

        private void previousLabel_Click(object sender, EventArgs e) {
            if (smallConePictureBox.Visible == true) {
                previousLabel.Visible = false;
                smallConePictureBox.Visible = false;
                defaultConePictureBox.Visible = true;
            }
            if (flavorsPictureBox.Visible == true) {
                smallConePictureBox.Visible = true;
                defaultConePictureBox.Visible = false;
                flavorsPictureBox.Visible = false;
                previousLabel.Visible = true;
                nextLabel.Visible = true;
            }
        }

        private void chocolateCheckBox_CheckedChanged(object sender, EventArgs e) {
            calculateSales();
        }

        private void vanillaCheckBox_CheckedChanged(object sender, EventArgs e) {
            calculateSales();
        }

        private void strawberryCheckBox_CheckedChanged(object sender, EventArgs e) {
            calculateSales();
        }

        private void sprinklesCheckbox_CheckedChanged(object sender, EventArgs e) {
            calculateSales();
        }

        private void fudgeCheckbox_CheckedChanged(object sender, EventArgs e) {
            calculateSales();
        }

        //this method/function will run an advanced algorithm to determin the ammount of money a user will pay for their ice cream.
        private void calculateSales() {
            //sales tax is 7.5% rounded up to 0.08
            double salesTax = 0.08;
            double iceCreamTax = 0.00;

            int iceCreamSales = 0;
            int extraSales = 0;

            double totalSale = 0.00;

            //here we want to see if the check boxes are checked
            if (chocolateCheckBox.Checked || vanillaCheckBox.Checked || strawberryCheckBox.Checked) {
                iceCreamSales = 1;
            }

            if ((chocolateCheckBox.Checked && vanillaCheckBox.Checked) || (chocolateCheckBox.Checked && strawberryCheckBox.Checked) || (vanillaCheckBox.Checked && strawberryCheckBox.Checked)) {
                iceCreamSales = 2;
            }

            if (chocolateCheckBox.Checked && vanillaCheckBox.Checked && strawberryCheckBox.Checked) {
                iceCreamSales = 3;
            }

            if (sprinklesCheckbox.Checked || fudgeCheckbox.Checked) {
                extraSales = 5;

                if (sprinklesCheckbox.Checked && fudgeCheckbox.Checked) {
                    extraSales = 10;
                }
            }

            //this is where all the linear algerbra and applied mathimatics come into play.
            int calSalesAndExtra = iceCreamSales + extraSales;

            iceCreamTax = calSalesAndExtra * salesTax;

            totalSale = calSalesAndExtra + iceCreamTax;

            //once all the advanced calculus and physics part of the program is done calculating we change the Labels to display
            //the ice cream price, sales tax, and total.
            salesTotalLabel.Text = "$" + calSalesAndExtra;
            salesTaxlabel.Text = "$" + iceCreamTax;
            totalCostLabel.Text = "$" + totalSale;
        }

        private void placeOrderButton_Click(object sender, EventArgs e) {
            //the user must check at least one flavor of ice cream to complete their order
            if (chocolateCheckBox.Checked == false && vanillaCheckBox.Checked == false && strawberryCheckBox.Checked == false) {
                MessageBox.Show("Please Select at least one flavor of Ice Cream.");
            } else {
                /*
                 * this is where the invisible magic code that this program uses to 
                 * look up the user's IP address to charge their credit card.
                 * */
                MessageBox.Show("Thank you. Your order has been placed. Your credit card linked to you IP has been charged.");
                //now we reset the check boxes if the users wants to make another order.
                chocolateCheckBox.Checked = false;
                vanillaCheckBox.Checked = false;
                strawberryCheckBox.Checked = false;
                sprinklesCheckbox.Checked = false;
                fudgeCheckbox.Checked = false;
            }
        }

        private void exitButton_Click(object sender, EventArgs e) {
            //this is the end of the program.
            this.Close();
        }
    }
}
