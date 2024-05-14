using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Acron_Paketleme
{
    
    public partial class FormMessageTxt : Form
    {
        public int number;
        FormMain main;
        public FormMessageTxt(FormMain _main)
        {
            InitializeComponent();
            main = _main;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            main.number1 = (int)numericUpDown1.Value;
            this.Close();
        }
    }
}
