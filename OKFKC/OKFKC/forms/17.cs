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
    public partial class _17 : Form
    {
        public _17()
        {
            InitializeComponent();
            new TTimer().Timer(timer_pole);

            DBF.loadSponsor(dataGridView1, label3, name, des, logo);
        }

        private void _17_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }
    }
}
