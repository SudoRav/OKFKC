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
    public partial class _15 : Form
    {
        public _15()
        {
            InitializeComponent();
            new TTimer().Timer(timer_pole);

            DBF.fillGender(gen);
            DBF.fillCountry(comboBox2);

            label13.Text = Stat.Email_C_User;
            f_name.Text = Stat.FirstName_C_User;
            l_name.Text = Stat.LastName_C_User;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void _15_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DBF.updRacer(Stat.Email_C_User, Stat.Password_C_User, repas, f_name, l_name, gen, date, image, comboBox2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DBF.logout(this);
        }
    }
}
