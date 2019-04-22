using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 欢乐大抽奖
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected bool isNumberic(string message)
        {
            System.Text.RegularExpressions.Regex rex =
            new System.Text.RegularExpressions.Regex(@"^\d+$");
            if (rex.IsMatch(message))
            {
                return true;
            }
            else
                return false;
        }

        private void textBox8_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == String.Empty || textBox10.Text == String.Empty)
            {
                textBox8.Enabled = false;
                textBox11.Enabled = false;
                textBox9.Enabled = false;
                textBox12.Enabled = false;
            }
            else
            {
                textBox8.Enabled = true;
                textBox11.Enabled = true;
                textBox9.Enabled = true;
                textBox12.Enabled = true;
            }
        }

        private void textBox11_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == String.Empty || textBox10.Text == String.Empty)
            {
                textBox8.Enabled = false;
                textBox11.Enabled = false;
                textBox9.Enabled = false;
                textBox12.Enabled = false;
            }
            else
            {
                textBox8.Enabled = true;
                textBox11.Enabled = true;
                textBox9.Enabled = true;
                textBox12.Enabled = true;
            }
        }

        private void textBox9_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == String.Empty || textBox10.Text == String.Empty || textBox8.Text == String.Empty || textBox11.Text == String.Empty)
            {
                textBox9.Enabled = false;
            }
            else
            {
                textBox9.Enabled = true;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(textBox1.Text == String.Empty)
            {
                label7.Visible = true;
            }
            else
            {
                label7.Visible = false;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == String.Empty || !isNumberic(textBox2.Text))
            {
                label8.Visible = true;
            }
            else
            {
                label8.Visible = false;
            }
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == String.Empty || textBox10.Text == String.Empty)
            {
                label29.Visible = true;
            }
            else
            {
                label29.Visible = false;
            }
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked )
            {
                label23.Visible = true;
            }
            else
            {
                label23.Visible = false;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == String.Empty)
            {
                label25.Visible = true;
            }
            else
            {
                label25.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(label7.Visible == false && label8.Visible == false && label9.Visible == false && label23.Visible == false && label25.Visible == false && label29.Visible == false)
            {
                Form f1 = new Form2();
                this.Hide();
                f1.ShowDialog();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("没有正确填写信息，请返回重写");
            }
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || !isNumberic(comboBox1.Text))
            {
                label9.Visible = true;
            }
            else
            {
                label9.Visible = false;
            }
        }

        private void comboBox2_Leave(object sender, EventArgs e)
        {
            if (comboBox2.Text == "" || !isNumberic(comboBox2.Text))
            {
                label9.Visible = true;
            }
            else
            {
                label9.Visible = false;
            }
        }

        private void comboBox3_Leave(object sender, EventArgs e)
        {
            if (comboBox3.Text == "" || !isNumberic(comboBox3.Text))
            {
                label9.Visible = true;
            }
            else
            {
                label9.Visible = false;
            }
        }


        private void comboBox10_Leave(object sender, EventArgs e)
        {
            if (comboBox10.Text == "" || !isNumberic(comboBox10.Text))
            {
                label9.Visible = true;
            }
            else
            {
                label9.Visible = false;
            }
        }

        private void comboBox11_Leave(object sender, EventArgs e)
        {
            if (comboBox11.Text == "" || !isNumberic(comboBox11.Text))
            {
                label9.Visible = true;
            }
            else
            {
                label9.Visible = false;
            }
        }

        private void comboBox6_Leave(object sender, EventArgs e)
        {
            if (comboBox6.Text == "" || !isNumberic(comboBox6.Text))
            {
                label9.Visible = true;
            }
            else
            {
                label9.Visible = false;
            }
        }

        private void comboBox5_Leave(object sender, EventArgs e)
        {
            if (comboBox5.Text == "" || !isNumberic(comboBox5.Text))
            {
                label9.Visible = true;
            }
            else
            {
                label9.Visible = false;
            }
        }

        private void comboBox4_Leave(object sender, EventArgs e)
        {
            if (comboBox4.Text == "" || !isNumberic(comboBox4.Text))
            {
                label9.Visible = true;
            }
            else
            {
                label9.Visible = false;
            }
        }

        private void comboBox8_Leave(object sender, EventArgs e)
        {
            if (comboBox8.Text == "" || !isNumberic(comboBox8.Text))
            {
                label9.Visible = true;
            }
            else
            {
                label9.Visible = false;
            }
        }

        private void comboBox12_Leave(object sender, EventArgs e)
        {
            if (comboBox12.Text == "" || !isNumberic(comboBox12.Text))
            {
                label9.Visible = true;
            }
            else
            {
                label9.Visible = false;
            }
        }

    }
}
