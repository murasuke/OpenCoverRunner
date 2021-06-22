using System;
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
                numericUpDown3.Value = CalcLogic.Add(numericUpDown1.Value, numericUpDown2.Value);
            }
            else if (rdoSub.Checked)
            {
                numericUpDown3.Value = CalcLogic.Sub(numericUpDown1.Value, numericUpDown2.Value);
            }
            else if (rdoMul.Checked)
            {
                numericUpDown3.Value = CalcLogic.Mul(numericUpDown1.Value, numericUpDown2.Value);
            }
            else if (rdoDiv.Checked)
            {
                numericUpDown3.Value = CalcLogic.Div(numericUpDown1.Value, numericUpDown2.Value);
            }
            
        }




    }
}
