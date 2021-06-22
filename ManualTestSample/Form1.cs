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
            if( rdoAdd.Checked)
            {
                numericUpDown3.Value = Add(numericUpDown1.Value, numericUpDown2.Value);
            }
            else if (rdoSub.Checked)
            {
                numericUpDown3.Value = Sub(numericUpDown1.Value, numericUpDown2.Value);
            }
            else if (rdoMul.Checked)
            {
                numericUpDown3.Value = Mul(numericUpDown1.Value, numericUpDown2.Value);
            }
            else if (rdoDiv.Checked)
            {
                numericUpDown3.Value = Div(numericUpDown1.Value, numericUpDown2.Value);
            }
            
        }

        public decimal Add(decimal a, decimal b)
        {
            return a + b;
        }



        public decimal Sub(decimal a, decimal b)
        {
            return a - b;
        }



        public decimal Mul(decimal a, decimal b)
        {
            return a * b;
        }



        public decimal Div(decimal a, decimal b)
        {
            if (b == 0)
            {
                return 0;
            }

            return a / b;
        }




    }
}
