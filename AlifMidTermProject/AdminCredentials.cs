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
            try
            {
                connection.Open();

                //if (connection.State == System.Data.ConnectionState.Open)
                //{
                //    Console.WriteLine("Succesfully Connected to Data Base");
                //}

                Console.WriteLine("Please enter login");
                string Login = Console.ReadLine();
                Console.WriteLine("Please enter password");
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
            try
            {
                connection.Open();
                //if (connection.State == System.Data.ConnectionState.Open)
                //{
                //    Console.WriteLine("Succesfully Connected to Data Base");
                //}
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
        

        }

            }
        
    

