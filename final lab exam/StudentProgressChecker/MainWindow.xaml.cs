/*using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Data.SqlClient; // Updated to use Microsoft.Data.SqlClient

namespace StudentProgressTracker
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Student> Students { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Students = new ObservableCollection<Student>();
            LoadStudentsFromDatabase();
            StudentDataGrid.ItemsSource = Students;
        }

        private void FilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FilterComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string filterType = selectedItem.Content.ToString();

                if (filterType == "Grade")
                {
                    StudentDataGrid.ItemsSource = Students.Where(s => s.Grade == "A").ToList();
                }
                else if (filterType == "Subject")
                {
                    StudentDataGrid.ItemsSource = Students.Where(s => s.Subject == "Math").ToList();
                }
            }
        }

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            var newStudent = new Student
            {
                Name = "New Student",
                Grade = "C",
                Subject = "History",
                Marks = 60,
                Attendance = 80.0
            };

            // Add student to collection and database
            Students.Add(newStudent);
            AddStudentToDatabase(newStudent);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private async Task SaveDataAsync()
        {
            TaskProgressBar.Visibility = Visibility.Visible; // Show the progress bar
            await Task.Run(() =>
            {
                // Simulate a long-running operation (e.g., saving data)
                System.Threading.Thread.Sleep(3000); // Replace with actual save logic
            });
            TaskProgressBar.Visibility = Visibility.Collapsed; // Hide the progress bar
            MessageBox.Show("Data saved successfully!");
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            await SaveDataAsync();
        }

        private void LoadStudentsFromDatabase()
        {
            try
            {
                using (Microsoft.Data.SqlClient.SqlConnection connection = DatabaseHelper.GetConnection()) // Explicitly use Microsoft.Data.SqlClient.SqlConnection
                {
                    connection.Open();
                    string query = "SELECT Name, Grade, Subject, Marks, Attendance FROM Students";
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Students.Add(new Student
                        {
                            Name = reader["Name"].ToString(),
                            Grade = reader["Grade"].ToString(),
                            Subject = reader["Subject"].ToString(),
                            Marks = int.Parse(reader["Marks"].ToString()),
                            Attendance = double.Parse(reader["Attendance"].ToString())
                        });
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database Error: {ex.Message}");
            }
        }

        private void AddStudentToDatabase(Student student)
        {
            try
            {
                using (Microsoft.Data.SqlClient.SqlConnection connection = DatabaseHelper.GetConnection()) // Explicitly use Microsoft.Data.SqlClient.SqlConnection
                {
                    connection.Open();
                    string query = "INSERT INTO Students (Name, Grade, Subject, Marks, Attendance) VALUES (@Name, @Grade, @Subject, @Marks, @Attendance)";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@Name", student.Name);
                    command.Parameters.AddWithValue("@Grade", student.Grade);
                    command.Parameters.AddWithValue("@Subject", student.Subject);
                    command.Parameters.AddWithValue("@Marks", student.Marks);
                    command.Parameters.AddWithValue("@Attendance", student.Attendance);

                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database Error: {ex.Message}");
            }
        }
    }

    public static class DatabaseHelper
    {
       /* public static SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["StudentsDatabase"].ConnectionString;
            return new SqlConnection(connectionString);  // Correctly instantiate the SqlConnection
        }
    }*/

using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Data.SqlClient; // Ensures usage of Microsoft.Data.SqlClient

namespace StudentProgressTracker
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Student> Students { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Students = new ObservableCollection<Student>();
            LoadStudentsFromDatabase();
            StudentDataGrid.ItemsSource = Students;
        }

        private void FilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FilterComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string filterType = selectedItem.Content.ToString();

                if (filterType == "Grade")
                {
                    StudentDataGrid.ItemsSource = Students.Where(s => s.Grade == "A").ToList();
                }
                else if (filterType == "Subject")
                {
                    StudentDataGrid.ItemsSource = Students.Where(s => s.Subject == "Math").ToList();
                }
                else
                {
                    StudentDataGrid.ItemsSource = Students;
                }
            }
        }

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            var newStudent = new Student
            {
                Name = "New Student",
                Grade = "C",
                Subject = "History",
                Marks = 60,
                Attendance = 80.0
            };

            // Add student to collection and database
            Students.Add(newStudent);
            AddStudentToDatabase(newStudent);
        }

        private void EditStudentButton_Click(object sender, RoutedEventArgs e)
        {
            if (StudentDataGrid.SelectedItem is Student selectedStudent)
            {
                selectedStudent.Name = "Updated Name"; // Example update
                UpdateStudentInDatabase(selectedStudent);
                StudentDataGrid.Items.Refresh(); // Refresh the DataGrid
            }
        }

        private void DeleteStudentButton_Click(object sender, RoutedEventArgs e)
        {
            if (StudentDataGrid.SelectedItem is Student selectedStudent)
            {
                Students.Remove(selectedStudent);
                DeleteStudentFromDatabase(selectedStudent);
                StudentDataGrid.Items.Refresh();
            }
        }

        private async Task SaveDataAsync()
        {
            TaskProgressBar.Visibility = Visibility.Visible; // Show the progress bar
            await Task.Run(() =>
            {
                // Simulate a long-running operation (e.g., saving data)
                System.Threading.Thread.Sleep(3000); // Replace with actual save logic
            });
            TaskProgressBar.Visibility = Visibility.Collapsed; // Hide the progress bar
            MessageBox.Show("Data saved successfully!");
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            await SaveDataAsync();
        }

        private void LoadStudentsFromDatabase()
        {
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT Name, Grade, Subject, Marks, Attendance FROM Students";
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Students.Add(new Student
                        {
                            Name = reader["Name"].ToString(),
                            Grade = reader["Grade"].ToString(),
                            Subject = reader["Subject"].ToString(),
                            Marks = int.Parse(reader["Marks"].ToString()),
                            Attendance = double.Parse(reader["Attendance"].ToString())
                        });
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database Error: {ex.Message}");
            }
        }

        private void AddStudentToDatabase(Student student)
        {
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO Students (Name, Grade, Subject, Marks, Attendance) VALUES (@Name, @Grade, @Subject, @Marks, @Attendance)";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@Name", student.Name);
                    command.Parameters.AddWithValue("@Grade", student.Grade);
                    command.Parameters.AddWithValue("@Subject", student.Subject);
                    command.Parameters.AddWithValue("@Marks", student.Marks);
                    command.Parameters.AddWithValue("@Attendance", student.Attendance);

                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database Error: {ex.Message}");
            }
        }

        private void UpdateStudentInDatabase(Student student)
        {
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE Students SET Grade = @Grade, Subject = @Subject, Marks = @Marks, Attendance = @Attendance WHERE Name = @Name";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@Name", student.Name);
                    command.Parameters.AddWithValue("@Grade", student.Grade);
                    command.Parameters.AddWithValue("@Subject", student.Subject);
                    command.Parameters.AddWithValue("@Marks", student.Marks);
                    command.Parameters.AddWithValue("@Attendance", student.Attendance);

                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database Error: {ex.Message}");
            }
        }

        private void DeleteStudentFromDatabase(Student student)
        {
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM Students WHERE Name = @Name";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@Name", student.Name);

                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database Error: {ex.Message}");
            }
        }
    }

    public static class DatabaseHelper
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["StudentsDatabase"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'StudentsDatabase' not found in the configuration file.");
            }

            return new SqlConnection(connectionString);
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public string Grade { get; set; }
        public string Subject { get; set; }
        public int Marks { get; set; }
        public double Attendance { get; set; }
    }
}


