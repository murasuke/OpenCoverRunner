using OpenCoverWebForm.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OpenCoverWebForm
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        delegate bool ParseText(TextBox t, out decimal v);

        protected void Button1_Click(object sender, EventArgs e)
        {
            decimal lhv = 0;
            decimal rhv = 0;
            decimal result = 0;

            ParseText parseText = (TextBox textbox, out decimal value) =>
            {
                if (!decimal.TryParse(textbox.Text, out value))
                {
                    //MessageBox.Show("数値を入力してください", "入力エラー");
                    ClientScript.RegisterClientScriptBlock( this.GetType(), "alert", "alert('数値を入力してください');", true);
                    textbox.Focus();
                    return false;
                }
                return true;
            };

            if (!parseText(TextBox1, out lhv))
            {
                return;
            }

            if (!parseText(TextBox2, out rhv))
            {
                return;
            }

            switch (RadioButtonList1.SelectedValue)
            {
                case "0":
                    result = CalcLogic.Add(lhv, rhv);
                    break;
                case "1":
                    result = CalcLogic.Sub(lhv, rhv);
                    break;
                case "2":
                    result = CalcLogic.Mul(lhv, rhv);
                    break;
                case "3":
                    result = CalcLogic.Div(lhv, rhv);
                    break;
            }

            TextBox3.Text = result.ToString();
        }
    }
}