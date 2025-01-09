using System.Collections.Generic;
using Microsoft.Data.SqlClient;

public class StudentService
{
    // Method to fetch all students
    public List<string> GetStudents()
    {
        List<string> students = new List<string>();

        using (SqlConnection connection = DatabaseHelper.GetConnection())
        {
            connection.Open();
            string query = "SELECT * FROM Students";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                students.Add(reader["Name"].ToString());
            }
        }

        return students;
    }
}
