using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CUSTOMER_DATA_PROJECT
{
    public partial class Form2 : Form
    {
        public string CustomerName { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public string Hobbies { get; set; }
        public string Status { get; set; }
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = $"Customer Name: {CustomerName}";
            label2.Text = $"Country: {Country}";
            label3.Text = $"Gender: {Gender}";
            label4.Text = $"Hobbies: {Hobbies}";
            label5.Text = $"Status: {Status}";
        }
    }
}
