using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AlifMidTermProject
{
    class Application
    {
        public static string conString = @"Data source = DESKTOP-SS5TGJO\SQLEXPRESS; initial catalog = AlifMidTermProjectDB; Integrated security = true;";
        public static int Id { get; set; }
        public static decimal SumOfCredit { get; set; }
        public static decimal SumOfPayment {get;set;}
        public static DateTime ApplicationDate { get; set; }
        public static DateTime Deadline { get; set; }
        public static int CreditStatus { get; set; }
        public static decimal TotalIncome { get; set; }
        public static string CreditAim { get; set; }
        public static int CreditTerm { get; set; }
        public static SqlConnection connection = new SqlConnection(conString);
        public static SqlCommand command = connection.CreateCommand();
        public int age;
        

        public static void creditApplicationForm()
        {
            Console.Clear();
            try
            {
                connection.Open();
                Console.WriteLine("Enter credit amount: ");
                decimal SumOfCredit = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Enter amount you can pay each month: ");
                decimal SumOfPayment = decimal.Parse (Console.ReadLine());
                Console.WriteLine("Application date");
                ApplicationDate = DateTime.Now;
                Console.WriteLine("Enter credit amount: ");
                Deadline = DateTime.Now;
                Console.WriteLine("Enter credit: ");
                int CreditStatus = int.Parse( Console.ReadLine());
                Console.WriteLine("Enter your income: ");
                decimal TotalIncome = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Enter credit purpose:1. Appliances 2. Construction 3. Cell Phone 4. Else");
                string CreditAim = Console.ReadLine();
                Console.WriteLine("Enter credit term: ");
                int CreditTerm = int.Parse(Console.ReadLine());

                int age = DateTime.Now.Year - Customers.DOB.Year;
                
                Console.WriteLine("Credit history");
                int creditHistory = int.Parse(Console.ReadLine());
                int overdueCreditHistory = int.Parse(Console.ReadLine());
                bool result = Calculator.GetResult(age, creditHistory, overdueCreditHistory);
                if (result == true)
                {
                    Console.WriteLine("You are approved for credit");
                    command.CommandText = "insert into Application(" +
                    "SumOfCredit, " +
                    "SumOfPayment, " +
                    "ApplicationDate, " +
                    "Deadline, " +
                    "CreditStatus, " +
                    "TotalIncome, " +
                    "CreditAim, " +
                    "CreditTerm ) Values (" +
                    $"'{SumOfCredit}'," +
                    $"'{SumOfPayment}'," +
                    $"'{ApplicationDate}'," +
                    $"'{Deadline}'," +
                    $"'{CreditStatus}'," +
                    $"'{TotalIncome}'," +
                    $"'{CreditAim}'," +
                    $"'{CreditTerm}')";
                    var result1 = command.ExecuteNonQuery();
                    if (result1 > 0)
                    {
                        Console.WriteLine("New application successfully added!");
                    }
                }
                else 
                    Console.WriteLine("We can not give you credit");

                
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
