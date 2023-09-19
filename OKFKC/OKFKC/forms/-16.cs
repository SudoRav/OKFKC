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
    public partial class _16 : Form
    {
        public _16()
        {
            InitializeComponent();
            new TTimer().Timer(timer_pole);

            DBF.getGender(gen);
        }

        private void _16_Load(object sender, EventArgs e)
        {
            // event event_name id_event-type
        }
    }
}
