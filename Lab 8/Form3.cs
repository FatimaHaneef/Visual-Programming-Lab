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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void cUSTOMERDATAINFORMATIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 dataEntryForm = new Form1();
            dataEntryForm.ShowDialog();
        }
    }
}
