using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManualTestSample
{
    public partial class ManualTestSample : Form
    {
        public ManualTestSample()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numericUpDown3.Value = Div(numericUpDown1.Value, numericUpDown2.Value);
        }

        public decimal Div(decimal a, decimal b)
        {
            if (b == 0)
            {
                return 0;
            }

            return a / b;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numericUpDown6.Value = Mul(numericUpDown5.Value, numericUpDown4.Value);
        }

        public decimal Mul(decimal a, decimal b)
        {
            var result = a * b;
            return result;
        }


    }
}
