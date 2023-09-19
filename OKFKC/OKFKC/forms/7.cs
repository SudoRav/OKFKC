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
    public partial class _7 : Form
    {
        public _7()
        {
            InitializeComponent();
            new TTimer().Timer(timer_pole);

            label4.Text = Stat._6_sum;
        }

        private void _7_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new forms._6().Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
