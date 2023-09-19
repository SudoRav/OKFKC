using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OKFKC.forms
{
    public partial class _6 : Form
    {
        public _6()
        {
            InitializeComponent();
            new TTimer().Timer(timer_pole);

            DBF.fillRacer(racer);
        }

        private void _6_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void sum_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Stat._6_sum = lvzn.Text;
            if(DBF.crtSponsorship(name, racer, card, num_card, activ_1, activ_2, cvc, sum))
            {
                this.Hide();
                new forms._7().Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (sum.Text == "")
                sum.Text = "0";

            sum.Text = (Convert.ToInt32(sum.Text) + 50).ToString();
            lvzn.Text = "$ " + sum.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (sum.Text == "")
                sum.Text = "0";

            sum.Text = (Convert.ToInt32(sum.Text) - 50).ToString();
            if ((Convert.ToInt32(sum.Text) < 0))
                sum.Text = "0";

            lvzn.Text = "$ " + sum.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }
    }
}
