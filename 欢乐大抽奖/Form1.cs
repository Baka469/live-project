using System;
using System.Collections;
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

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {
                label7.Visible = true;
            }
            else
            {
                label7.Visible = false;
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
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked)
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
            if (label7.Visible == false && label9.Visible == false && label23.Visible == false && label25.Visible == false && label29.Visible == false)
            {
                string awardWord = textBox1.Text;//抽奖关键词
                string bDate = string.Format("{0:D4}-{1:D2}-{2:D2}", comboBox1.Text, comboBox2.Text, comboBox3.Text);//抽奖发言开始时段,
                string bTime = string.Format("{0:D2}:{1:D2}:{2:D2},", comboBox10.Text, comboBox11.Text, "00");//UI类传进来的开始时间和日期
                string eDate = string.Format("{0:D4}-{1:D2}-{2:D2}", comboBox6.Text, comboBox5.Text, comboBox4.Text);
                string eTime = string.Format("{0:D2}:{1:D2}:{2:D2}", comboBox8.Text, comboBox12.Text, "00"); ;//UI类传进来的结束时间和日期

                Dictionary<string, int> awardNameAndNumber = new Dictionary<string, int>();//奖品与人数字典 这里用奖品名做主键，所以奖品名不能重复
                awardNameAndNumber.Add("一等奖:" + textBox7.Text, int.Parse(textBox10.Text));
                awardNameAndNumber.Add("二等奖:" + textBox8.Text, int.Parse(textBox11.Text));
                awardNameAndNumber.Add("三等奖:" + textBox9.Text, int.Parse(textBox12.Text));
                int filterFlag = 0;//过滤规则标识符 初始化{0}不过滤 {1}过滤10天内未发言的 {2}过滤20天内未发言的
                if (radioButton2.Checked)
                {
                    filterFlag = 1;
                }
                else if (radioButton3.Checked)
                {
                    filterFlag = 2;
                }
                else
                {
                    filterFlag = 0;
                }
                string filterWord = textBox5.Text;//过滤关键词

                Dictionary<string, int> nameAndWeight = Filter.filter(awardWord, filterFlag,filterWord , bDate, bTime, eDate, eTime);//过滤传进来
                Dictionary<string, ArrayList> winningInfo = PrizeDraw.prizeDrawAll(awardNameAndNumber, nameAndWeight);

                Form2 resultForm = new Form2();

                foreach (var award in winningInfo)
                {
                    //追加
                    resultForm.RichTextBoxValue = award.Key + "\n";
                    ArrayList winners = award.Value;
                    foreach (var winner in winners)
                    {
                        resultForm.RichTextBoxValue = winner + "、";
                    }
                    resultForm.RichTextBoxValue = "\n";
                }

                this.Hide();
                resultForm.ShowDialog();
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
