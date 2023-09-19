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
    public partial class _18 : Form
    {
        public _18()
        {
            InitializeComponent();
            new TTimer().Timer(timer_pole);
        }

        private void _18_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DBF.logout(this);
        }
    }
}
