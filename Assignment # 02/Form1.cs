using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment___02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  MessageBox.Show("Hello World!");
           // MessageBox.Show("Clicking Button!");
            MessageBox.Show("Hello World!", "Help");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World!", "Help", MessageBoxButtons.OKCancel);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World!", "Help", MessageBoxButtons.YesNo);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World!", "Help", MessageBoxButtons.AbortRetryIgnore);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World!", "Help", MessageBoxButtons.OK , MessageBoxIcon.Information);
        }

        // ********* LABEL CONTROL ************
        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = "Hello World !";
        }
        // ********** TEXTBOX CONTROL *************
        private void button6_Click(object sender, EventArgs e)
        {
          label3.Text = "Your Name is " + textBox1.Text;
            //can use any both or any
            MessageBox.Show(textBox1.Text);
        }
        // *********** RICH TEXTBOX CONTROL ***********
        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Italic);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Underline);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            String item = string.Empty;
            if (checkBox1.Checked)
            {
                item += checkBox1.Text;
            }
            if (checkBox2.Checked)
            {
                item += checkBox2.Text;
            }
            if (checkBox3.Checked)
            {
                item += checkBox3.Text;
            }

            MessageBox.Show("You have bought : " + item);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string Gender = " ";
            if(radioButton1.Checked)
            {
                Gender = radioButton1.Text;
            }
            if (radioButton2.Checked)
            {
                Gender = radioButton2.Text;
            }
            MessageBox.Show(Gender.ToString());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            decimal price = numericUpDown1.Value;
            int quantity = (int)numericUpDown2.Value;

            decimal total;
            total = price * quantity;
            MessageBox.Show(String.Format("The Total Price is {0} ", total));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                OpenFileDialog o = new OpenFileDialog();
                if (o.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = new Bitmap(o.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] names = { "Pakistan", "India", "Turkey", "Palestine" };
            foreach(string name in names)
            {
                comboBox1.Items.Add(name);

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
             string name;
             name = comboBox1.SelectedItem.ToString();
             // for index:
             //name = comboBox1.SelectedIndex.ToString();
             MessageBox.Show(name);

            comboBox2.Items.Clear();
            if(comboBox1.SelectedItem.ToString()=="Pakistan")
            {
                comboBox2.Items.Add("Multan");
                comboBox2.Items.Add("Islamabad");
                comboBox2.Items.Add("Peshawar");
            }
            if (comboBox1.SelectedItem.ToString() == "India")
            {
                comboBox2.Items.Add("Mumbai");
                comboBox2.Items.Add("Delhi");
                comboBox2.Items.Add("Kolkata");
            }
            if (comboBox1.SelectedItem.ToString() == "Turkey")
            {
                comboBox2.Items.Add("Istanbul");
                comboBox2.Items.Add("Ankara");
                comboBox2.Items.Add("Bursa");
            }
        }
        //************ DATE TIME PICKER CONTROL ***********
        private void button14_Click(object sender, EventArgs e)
        {
            string date;
            date = dateTimePicker1.Text;
            MessageBox.Show(date);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string date;
            date = dateTimePicker1.Value.ToLongTimeString();
            MessageBox.Show(date);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string date;
            date = dateTimePicker1.Value.ToShortDateString();
            MessageBox.Show(date);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string date;
            date = dateTimePicker1.Value.ToString("MM-dd-yyyy");
            MessageBox.Show(date);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            string date;
            date = dateTimePicker1.Value.ToShortTimeString();
            MessageBox.Show(date);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string date;
            date = dateTimePicker1.Value.ToString();
            MessageBox.Show(date);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            string date;
            date = monthCalendar1.SelectionStart.ToShortDateString();
            label18.Text= date;
            date = monthCalendar1.SelectionStart.ToString("MM-dd-yyyy");
            label19.Text = date;
            //applied range in this
            date = monthCalendar1.SelectionEnd.ToString("MM-dd-yyyy");
            label20.Text = date;

            //starting and end date in range
            string date1, date2;
            date1 = monthCalendar1.SelectionStart.ToLongDateString();
            date2 = monthCalendar1.SelectionEnd.ToLongDateString();
            label21.Text = "Your Selection Is :\nStart Date:  " + date1 + "\nEnd Date: " + date2;

        }
    }
}
