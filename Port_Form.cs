using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shallow_Learning_Frame
{
    public partial class Port_Form : Form
    {
        public Port_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty)
            {
                Data_Base.port_number = textBox1.Text;
                Data_Base.host_name = textBox2.Text;
                this.Close();
            }
        }
    }
}
