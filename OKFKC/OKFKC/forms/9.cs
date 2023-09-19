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
    public partial class _9 : Form
    {
        public _9()
        {
            InitializeComponent();
            new TTimer().Timer(timer_pole);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new forms.tforms.contacts().Show();
        }

        private void _9_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DBF.logout(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new forms._5().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new forms._15().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new forms._17().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new forms._16().Show();
        }
    }
}
