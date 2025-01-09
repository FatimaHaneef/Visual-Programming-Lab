using Microsoft.Data.SqlClient;
using System.Configuration; // Updated to Microsoft.Data.SqlClient

public static class DatabaseHelper
{
    // Method to get the connection string from App.config
    public static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["StudentsDatabase"].ConnectionString;
    }

    // Method to create and return a SqlConnection object
    public static SqlConnection GetConnection()
    {
        string connectionString = GetConnectionString();
        return new SqlConnection(connectionString);
    }
}
