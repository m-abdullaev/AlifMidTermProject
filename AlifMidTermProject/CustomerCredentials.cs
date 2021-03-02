using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AlifMidTermProject
{
    class CustomerCredentials
    {
        public static string conString = @"Data source = DESKTOP-SS5TGJO\SQLEXPRESS; initial catalog = AlifMidTermProjectDB; Integrated security = true;";        
        public static int Id { get; set; }
        public static string Login { get; set; }
        public static string Password { get; set; }
        public static SqlConnection connection = new SqlConnection(conString);
        public static SqlCommand command = connection.CreateCommand();

        public static void insertCustomerLogin()
        {
            Console.Clear();
            try
            {
                connection.Open();
                Console.WriteLine("Enter login: ");
                string Login = Console.ReadLine();
                Console.WriteLine("Enter password: ");
                string Password = Console.ReadLine();
                command.CommandText = "insert into CustomerCredentials(" +
                    "Login, " +
                    "Password ) Values(" +
                    $"'{Login}'," +
                    $"'{Password}')";
                var result = command.ExecuteNonQuery();
                if(result > 0)
                {
                    Console.WriteLine("New Customer added!");
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
