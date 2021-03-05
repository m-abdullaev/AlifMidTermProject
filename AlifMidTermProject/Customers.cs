using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AlifMidTermProject
{
    public static class Customers
    {
        public static string conString = @"Data source = DESKTOP-SS5TGJO\SQLEXPRESS; initial catalog = AlifMidTermProjectDB; Integrated security = true;";
        public static SqlConnection connection = new SqlConnection(conString);
        public static SqlCommand command = connection.CreateCommand();
        public static int Id { get; set; }
        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static string MiddleName { get; set; }
        public static int PhoneNumber { get; set; }
        public static DateTime DOB { get; set; }
        public static string Citizenship { get; set; }
        public static string DocNumber { get; set; }
        public static char Gender { get; set; }
        public static string MaritalStatus { get; set; }

        public static void insertCustomer()
        {
            Console.Clear();
            try
            {
                connection.Open();
                Console.WriteLine("Enter first name: ");
                string FirstName = Console.ReadLine();
                Console.WriteLine("Enter last name: ");
                string LastName = Console.ReadLine();
                Console.WriteLine("Enter middle name: ");
                string MiddleName = Console.ReadLine();
                Console.WriteLine("Enter phone number: ");
                int phoneNumber = int.Parse(Console.ReadLine());
                if(phoneNumber >= 9)
                {
                    PhoneNumber = phoneNumber;
                }
                Console.WriteLine("Enter date of birth (yyyy-mm-dd): ");
                DOB = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter country of citizenship: 1. Tajikistan, 2. Foreigner");
                switch (Console.ReadLine())
                {
                    case "1": Citizenship = "Tajikistan"; break;
                    case "2": Citizenship = "Foreigner"; break;
                }
                Console.WriteLine("Enter document number: ");
                string DocNumber = Console.ReadLine();
                Console.WriteLine("Enter gender (M/F): ");
                char Gender = char.Parse(Console.ReadLine());
                Console.WriteLine("Marital status: 1. Single, 2. Married, 3. Divorced 4. Widow");
                switch (Console.ReadLine())
                {
                    case "1": MaritalStatus = "Single"; break;
                    case "2": MaritalStatus = "Married"; break;
                    case "3": MaritalStatus = "Divorced"; break;
                    case "4": MaritalStatus = "Widow"; break;
                }
                command.CommandText = "insert into Customers(" +
                    "FirstName, " +
                    "LastName, " +
                    "MiddleName, " +
                    "PhoneNumber, " +
                    "DOB, " +
                    "Citizenship, " +
                    "DocNumber, " +
                    "Gender, " +
                    "MaritalStatus ) Values(" +
                    $"'{FirstName}'," +
                    $"'{LastName}'," +
                    $"'{MiddleName}'," +
                    $"'{PhoneNumber}'," +
                    $"'{DOB}'," +
                    $"'{Citizenship}'," +
                    $"'{DocNumber}'," +
                    $"'{Gender}'," +
                    $"'{MaritalStatus}')";
                var result = command.ExecuteNonQuery();
                if (result > 0)
                {

                    Console.WriteLine("New customer successfully added!");

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
        public static void selectAllCustomers()
        {
            
            Console.Clear();
            try
            {
                connection.Open();
                command.CommandText = $"select * from Customers";
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["Id"]}, First name: {reader["FirstName"]}, Last name: {reader["LastName"]}, Middle name: {reader["MiddleName"]}, Phone number: {reader["PhoneNumber"]} Date of birth: {reader["DOB"]}, Citizenship: {reader["Citizenship"]}, Document Number: {reader["DocNumber"]}, Gender: {reader["Gender"]}, Marital status: {reader["MaritalStatus"]}");
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
        public static void selectCustomerByDocNumber()
        {
            Console.WriteLine("Enter Customer document number ");
            string docNumber = Console.ReadLine();
           
            try
            {
                connection.Open();
                command.CommandText = $"select * from Customers where DocNumber = {docNumber}";
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["Id"]}, First name: {reader["FirstName"]}, " +
                        $"Last name: {reader["LastName"]}, Middle name: {reader["MiddleName"]}, " +
                        $"Phone number: {reader["PhoneNumber"]} Date of birth: {reader["DOB"]}, " +
                        $"Citizenship: {reader["Citizenship"]}, Document Number: {reader["DocNumber"]}, " +
                        $"Gender: {reader["Gender"]}, Marital status: {reader["MaritalStatus"]}");
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

        public static bool customerValidityCheck()
        {
            Console.Clear();
            try
            {
                connection.Open();
                Console.WriteLine("Enter login: ");
                string login = Console.ReadLine();
                Console.WriteLine("Enter password: ");
                string password = Console.ReadLine();
                command.CommandText = $"select * from CustomerCredentials";
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
