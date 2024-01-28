using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace hesap_makine
{
    public partial class Form1 : Form
    {
        bool optState = false;
        double Result = 0;
        string opt = "";

        public Form1()
        {
            InitializeComponent();
            txtResult.Text = "0";
        }

        private void numbers(object sender, EventArgs e)
        {
            if (txtResult.Text == "0" || optState)
            {
                txtResult.Clear();
            }
            optState = false;
            Button btn = (Button)sender;
            txtResult.Text += btn.Text;
        }

        private void operations(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string newOpt = btn.Text;
            lbResult.Text = lbResult.Text + " " + txtResult.Text + " " + newOpt;
            switch (opt)
            {
                case "+": txtResult.Text = (Result + Double.Parse(txtResult.Text)).ToString(); break;
                case "-": txtResult.Text = (Result - Double.Parse(txtResult.Text)).ToString(); break;
                case "/": txtResult.Text = (Result / Double.Parse(txtResult.Text)).ToString(); break;
                case "x": txtResult.Text = (Result * Double.Parse(txtResult.Text)).ToString(); break;
                default: break;
            }
            Result = Double.Parse(txtResult.Text);
            optState = true;
            opt = newOpt;
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
            Result = 0;
            lbResult.Text = "";
            opt = "";
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            lbResult.Text = "";
            optState = true;
            switch (opt)
            {
                case "+": txtResult.Text = (Result + Double.Parse(txtResult.Text)).ToString(); break;
                case "-": txtResult.Text = (Result - Double.Parse(txtResult.Text)).ToString(); break;
                case "/": txtResult.Text = (Result / Double.Parse(txtResult.Text)).ToString(); break;
                case "x": txtResult.Text = (Result * Double.Parse(txtResult.Text)).ToString(); break;
                default: break;
            }

            Result = Double.Parse(txtResult.Text);
            txtResult.Text = Result.ToString();

            string Results = Convert.ToString(Result);
            string[] memoryS = { Results };
            ListViewItem memory = new ListViewItem(memoryS);
            LvMemory.Items.Add(memory);

            Result = 0;
            opt = "";
        }

        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            if (optState)
            {
                txtResult.Text = "0";
            }
            if (!txtResult.Text.Contains(","))
            {
                txtResult.Text += ",";
            }
            optState = false;
        }

        private void buttonMemory_Click(object sender, EventArgs e)
        {
            if (LvMemory.Visible != false)
            {
                LvMemory.Visible = false;
            }
            else
            {
                LvMemory.Visible = true;
            }
        }

        private void txtResult_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void buttonPN_Click(object sender, EventArgs e)
        {
            if (txtResult.Text != "0")
            {
                if (txtResult.Text.StartsWith("-"))
                {
                    txtResult.Text = txtResult.Text.Replace("-", "");
                }
                else if (txtResult.Text.StartsWith(""))
                {
                    txtResult.Text = "-" + txtResult.Text;
                }
            }
        }
    }
}