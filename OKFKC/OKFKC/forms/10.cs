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
    public partial class _10 : Form
    {
        public _10()
        {
            InitializeComponent();
            new TTimer().Timer(timer_pole);
        }

        private void _10_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new forms._13().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new forms._11().Show();
        }
    }
}
