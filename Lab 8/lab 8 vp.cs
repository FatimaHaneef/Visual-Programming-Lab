using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace CUSTOMER_DATA_PROJECT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1. address of sql server and databse
            string ConnectionString = "Data Source=DESKTOP-9HU6DH7\\SQLEXPRESS;Initial Catalog=\"Customer Database\";Integrated Security=True; TrustServerCertificate=True";
            //2. establish connection
            SqlConnection con = new SqlConnection(ConnectionString);
            //3.open connection 
            con.Open();
            //4.prepare query
            string strCommand = "Select * From CustomerTable";
            //5.execute query
            SqlCommand objCommand = new SqlCommand(strCommand, con);
            objCommand.ExecuteNonQuery();
            //6.close connection
           // con.Close();

            MessageBox.Show("Data has been saved.");
            // Bind Data with UI
            DataSet objDataSet = new DataSet();
            SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
            objAdapter.Fill(objDataSet);

        
        
        dataGridView1.DataSource = objDataSet.Tables[0];
            con.Close();
            if (textBox1.Text.Length >10)
            {
                MessageBox.Show("Customer name should not be longer than 10 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Form2 previewForm = new Form2();
            previewForm.CustomerName = textBox1.Text;
            previewForm.Country = textBox2.Text;
            previewForm.Gender = radioButton1.Checked ? "Male" : "Female";
            previewForm.Hobbies = (checkBox1.Checked ? "Reading " : "") + (checkBox2.Checked ? "Painting" : "");
            previewForm.Status = checkBox3.Checked ? "Married" : "Unmarried";
            previewForm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'customer_DatabaseDataSet.CustomerTable' table. You can move, or remove it, as needed.
            this.customerTableTableAdapter.Fill(this.customer_DatabaseDataSet.CustomerTable);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Gender = radioButton1.Checked ? "Male" : "Female";
            string Hobby = checkBox1.Checked ? "Reading" : (checkBox2.Checked ? "Painting" : "");
            string Status = checkBox3.Checked ? "1" : "0";

            // Step 2: Set up the connection string
            string strConnection = "Data Source=DESKTOP-9HU6DH7\\SQLEXPRESS;Initial Catalog=\"Customer Database\";Integrated Security=True";
            SqlConnection objConnection = new SqlConnection(strConnection);

            try
            {
                // Step 3: Open the connection
                objConnection.Open();

                // Step 4: Prepare the SQL Insert command
                string strCommand = "INSERT INTO CustomerTable (CustomerName, Country, Gender, Hobbies, Status) " +
                                    "VALUES (@Name, @Country, @Gender, @Hobbies, @Status)";
                SqlCommand objCommand = new SqlCommand(strCommand, objConnection);

                // Step 5: Add parameters to the command
                objCommand.Parameters.AddWithValue("@Name", textBox1.Text);
                objCommand.Parameters.AddWithValue("@Country", textBox2.Text);
                objCommand.Parameters.AddWithValue("@Gender", Gender);
                objCommand.Parameters.AddWithValue("@Hobbies", Hobby);
                objCommand.Parameters.AddWithValue("@Status", Status);

                // Step 6: Execute the command
                objCommand.ExecuteNonQuery();

                // Step 7: Close the connection
                objConnection.Close();

                // Step 8: Provide feedback to the user
                MessageBox.Show("Data has been saved.");

                // Optionally, refresh the UI or clear the input fields
                loadCustomer();  // If you have a method to reload the data into a DataGridView
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the process
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void loadCustomer()
{
    string strConnection = "Data Source=.\\sqlexpress;Initial Catalog=CustomerDB;Integrated Security=True";
    SqlConnection con = new SqlConnection(strConnection);
    SqlDataAdapter objAdapter = new SqlDataAdapter("SELECT * FROM CustomerTable", con);
    DataSet objDataSet = new DataSet();
    objAdapter.Fill(objDataSet);

    // Bind data to DataGridView
    dataGridView1.DataSource = objDataSet.Tables[0];
}
    }
}
