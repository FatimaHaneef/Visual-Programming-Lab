using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace LAB_TASK_7
{
    public partial class Form1 : Form
    {
        //for countdown
        private int timeLeft;
        private System.Windows.Forms.Timer countdownTimer;
        //*******************
        double resultValue = 0;
        string operationPerformed = " ";
        bool isOperationPerformed = false;

        //for wall clock
        private System.Windows.Forms.Timer clockTimer;

        //for picture viewer
        //private System.Windows.Forms.Button btnset;
        private System.Windows.Forms.TextBox txtFolderPath;
        private PictureBox picBox;
        private Label lblTotalPhotos;
        private string[] imageFiles;

        // for characters count
        private const int MaxLength = 160;

        public Form1()
        {
            InitializeComponent();
            //for countdown
            InitializeTimer();
            //for wall clock
            InitializeClockTimer();

          
            button28 = new Button { Text = "Set", Left = 10, Top = 10, Width = 75 };
            txtFolderPath = new TextBox { Left = 100, Top = 10, Width = 400, ReadOnly = true };
            picBox = new PictureBox { Left = 10, Top = 40, Width = 500, Height = 300, SizeMode = PictureBoxSizeMode.StretchImage };
            lblTotalPhotos = new Label { Left = 10, Top = 350, Width = 500, Height = 30 };

            // Add controls to form
            Controls.Add(button28);
            Controls.Add(txtFolderPath);
            Controls.Add(picBox);
            Controls.Add(lblTotalPhotos);

      
            button28.Click += button28_Click;

    
            textBox10.MaxLength = MaxLength;

           
            label24.Text = $"Remaining characters: {MaxLength}";

            textBox10.TextChanged += textBox10_TextChanged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double num1 = double.Parse(textBox1.Text);
                double num2 = double.Parse(textBox2.Text);
                double result = num1 + num2;
                textBox3.Text = result.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers.");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                double num1 = double.Parse(textBox1.Text);
                double num2 = double.Parse(textBox2.Text);
                double result = num1 - num2;
                textBox3.Text = result.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers.");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                double num1 = double.Parse(textBox1.Text);
                double num2 = double.Parse(textBox2.Text);
                double result = num1 * num2;
                textBox3.Text = result.ToString();
            }

            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                double num1 = double.Parse(textBox1.Text);
                double num2 = double.Parse(textBox2.Text);
                if (num2 != 0)
                {
                    double result = num1 * num2;
                    textBox3.Text = result.ToString();
                }

                else
                {
                    MessageBox.Show("Can not divide by zero.");
                }
            }

            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers.");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox4.Text = "0";
            label6.Text = "";
            resultValue = 0;
            operationPerformed = "";
            isOperationPerformed = false;

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }
     
        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;
            if ((textBox4.Text == "0") || isOperationPerformed)
                textBox4.Text = "";

            isOperationPerformed = false;
            textBox4.Text += button.Text;
            label6.Text += button.Text;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;

            if (!string.IsNullOrEmpty(textBox4.Text))
            {
               
                if (resultValue != 0 && !isOperationPerformed)
                {
                    button21.PerformClick(); 
                }

                operationPerformed = button.Text; 
                resultValue = double.Parse(textBox4.Text); 

                label6.Text = resultValue + " " + operationPerformed + " "; 
                isOperationPerformed = true; 
                textBox4.Clear();
            }
            else
            {
                MessageBox.Show("Enter a number first.");
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the second operand
                double secondOperand = double.Parse(textBox4.Text);

                // Perform the operation
                switch (operationPerformed)
                {
                    case "+":
                        textBox4.Text = (resultValue + secondOperand).ToString();
                        break;
                    case "-":
                        textBox4.Text = (resultValue - secondOperand).ToString();
                        break;
                    case "*":
                        textBox4.Text = (resultValue * secondOperand).ToString();
                        break;
                    case "/":
                        if (secondOperand != 0)
                            textBox4.Text = (resultValue / secondOperand).ToString();
                        else
                            MessageBox.Show("Cannot divide by zero.");
                        break;
                    default:
                        break;
                }

               
                label6.Text += $"{resultValue} {operationPerformed} {secondOperand} = {textBox4.Text}";


                
                resultValue = double.Parse(textBox4.Text);
                operationPerformed = "";
                isOperationPerformed = false;
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        //calculating squares
        private void button22_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            CalculateSquares();


        }
        private void CalculateSquares()
        {
            listBox1.Items.Add("Number\tSquare ");
            for (int i = 1; i <= 10; i++)
            {
                int square = GetSquare(i);

                listBox1.Items.Add($" {i} \t{square}");
            }
        }


        private int GetSquare(int number)
        {
            return number * number;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {
            try
            {

                double fahrenheit = double.Parse(textBox5.Text);

                double celsius = (fahrenheit - 32) * 5 / 9;


                textBox6.Text = celsius.ToString("F2");
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number for Fahrenheit.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {
            {
                try
                {
                  
                    int number = int.Parse(textBox7.Text);

                  
                    if (number < 0)
                    {
                        MessageBox.Show("Please enter a non-negative integer.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    
                    long factorial = CalculateFactorial(number);

                    textBox8.Text = factorial.ToString();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please enter a valid integer.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private long CalculateFactorial(int number)
        {
            if (number == 0 || number == 1)
                return 1;

            long result = 1;
            for (int i = 2; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }

        // countdown timer
        private void InitializeTimer()
        {
            countdownTimer = new System.Windows.Forms.Timer();
            countdownTimer.Interval = 1000; 
            countdownTimer.Tick += CountdownTimer_Tick;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            timeLeft = (int)numericUpDown1.Value; 
            label16.Text = $"Time Left: {timeLeft} seconds";
            countdownTimer.Start(); 
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--; 
                label16.Text = $"Time Left: {timeLeft} seconds";
            }
            else
            {
                countdownTimer.Stop(); 
                MessageBox.Show("Time Over!", "Countdown", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // wall clock
        private void InitializeClockTimer()
        {
            clockTimer = new System.Windows.Forms.Timer();
            clockTimer.Interval = 1000; 
            clockTimer.Tick += ClockTimer_Tick;
            clockTimer.Start();
        }

        private void ClockTimer_Tick(object sender, EventArgs e)
        {
         
            label18.Text = DateTime.Now.ToString("dddd, MMMM d, yyyy"); // e.g., Sunday, March 7, 2017
            label19.Text = DateTime.Now.ToString("hh:mm:ss tt"); // e.g., 12:34:56 PM
        }

        private void button28_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png"; 
                openFileDialog.Title = "Select an Image";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName; 
                    txtFolderPath.Text = Path.GetDirectoryName(selectedFilePath); 

                    
                    picBox.Image = System.Drawing.Image.FromFile(selectedFilePath);

                   
                    picBox.Size = new Size(this.ClientSize.Width, this.ClientSize.Height / 2);


                    picBox.SizeMode = PictureBoxSizeMode.StretchImage;

                    lblTotalPhotos.Text = "Total Photos: 1"; 
                }
                else
                {
                    lblTotalPhotos.Text = "No image selected.";
                    picBox.Image = null;
                }
            }
            }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            int remainingCharacters = MaxLength - textBox10.Text.Length;
            label24.Text = $"Remaining characters: {remainingCharacters}";
        }
    }
  
    }


    
    

