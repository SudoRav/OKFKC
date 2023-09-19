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
    public partial class _5 : Form
    {
        int vzn = 0;

        public _5()
        {
            InitializeComponent();
            new TTimer().Timer(timer_pole);

            DBF.fillCharity(charity);
        }

        private void m25_CheckedChanged(object sender, EventArgs e)
        {
            if (m25.Checked)
                vzn += 25;
            else
                vzn -= 25;
            sum.Text = "$" + vzn.ToString();
        }

        private void m40_CheckedChanged(object sender, EventArgs e)
        {
            if (m40.Checked)
                vzn += 40;
            else
                vzn -= 40;
            sum.Text = "$" + vzn.ToString();
        }

        private void m65_CheckedChanged(object sender, EventArgs e)
        {
            if (m65.Checked)
                vzn += 65;
            else
                vzn -= 65;
            sum.Text = "$" + vzn.ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                vzn += 0;
            else
                vzn -= 0;
            sum.Text = "$" + vzn.ToString();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                vzn += 30;
            else
                vzn -= 30;
            sum.Text = "$" + vzn.ToString();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
                vzn += 50;
            else
                vzn -= 50;
            sum.Text = "$" + vzn.ToString();
        }

        private void _5_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DBF.crtRegistaration(m65, m40, m25, vzn.ToString(), targ, charity);

            this.Hide();
            new _8().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }
    }
}
