using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AlifMidTermProject
{
    public static class AdminCredentials
    {
        public static string conString = @"Data source = DESKTOP-SS5TGJO\SQLEXPRESS; initial catalog = AlifMidTermProjectDB; Integrated security = true;";

        public static int Id { get; set; }
        public static string Login { get; set; }
        public static string Password { get; set; }
        public static SqlConnection connection = new SqlConnection(conString);
        public static SqlCommand command = connection.CreateCommand();

        public static void insertAdmin()
        {
            Console.Clear();
            try
            {
                connection.Open();
                
                Console.WriteLine("Enter login");
                string Login = Console.ReadLine();
                Console.WriteLine("Enter password");
                string Password = Console.ReadLine();
                command.CommandText = "insert into AdminCredentials(" +
                    "Login," +
                    "Password ) Values(" +
                    $"'{Login}'," +
                    $"'{Password}')";
                var result = command.ExecuteNonQuery();
                if (result > 0)
                {

                    Console.WriteLine("New admin successfully added!");

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
        public static void selectAllAdmin()
        {
            Console.Clear();
            try
            {
                connection.Open();
                
                command.CommandText = $"select * from AdminCredentials";
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["Id"]}, Login: {reader["Login"]}, Password: {reader["Password"]} ");
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
        public static void deleteByIdAdmin()
        {
            Console.Clear();
            try
            {
                connection.Open();
                Console.Write("Please enter id you would like to delete ");
                int id = int.Parse(Console.ReadLine());
                command.CommandText = $"delete AdminCredentials where Id = {id}";
                var reader = command.ExecuteNonQuery();
                if (reader > 0)
                {
                    Console.WriteLine("Person deleted successfully");
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
        public static bool adminValidityCheck()
        {
            Console.Clear();
            try
            {
                connection.Open();
                Console.WriteLine("Enter admin login: ");
                string login = Console.ReadLine();
                Console.WriteLine("Enter admin password: ");
                string password = Console.ReadLine();
                command.CommandText = $"select * from AdminCredentials";
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (login == reader.GetValue(1).ToString() && password == reader.GetValue(2).ToString())
                    {
                        return true;
                    }
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
            return false;
        }
    }
}

