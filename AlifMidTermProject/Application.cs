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
                Console.Write("Age: ");
                int age = int.Parse(Console.ReadLine());

                Console.WriteLine("Marital status: 1. Single, 2. Married, 3. Divorced 4. Widow");
                switch (Console.ReadLine())
                {
                    case "1": Customers.MaritalStatus = "Single"; break;
                    case "2": Customers.MaritalStatus = "Married"; break;
                    case "3": Customers.MaritalStatus = "Divorced"; break;
                    case "4": Customers.MaritalStatus = "Widow"; break;
                }

                Console.WriteLine("Enter country of citizenship: 1. Tajikistan, 2. Foreigner");
                switch (Console.ReadLine())
                {
                    case "1": Customers.Citizenship = "Tajikistan"; break;
                    case "2": Customers.Citizenship = "Foreigner"; break;
                }
                Console.WriteLine("Gender: ");
                char Gender = char.Parse(Console.ReadLine());
                Console.WriteLine("Enter credit amount: ");
                decimal SumOfCredit = decimal.Parse(Console.ReadLine());
                ApplicationDate = DateTime.Now;
                Console.WriteLine("Enter CreditStatus: ");
                int CreditStatus = int.Parse( Console.ReadLine());
                Console.WriteLine("Enter your income: ");
                decimal TotalIncome = decimal.Parse(Console.ReadLine());
                
                Console.WriteLine("Enter credit purpose:1. Appliances 2. Construction 3. Cell Phone 4. Else");
                int creditAim = int.Parse(Console.ReadLine());
                switch (creditAim)
                {
                    case 1:
                        CreditAim = "Appliances";
                            break;
                    case 2:
                        CreditAim = "Construction";
                        break;
                    case 3:
                        CreditAim = "Cell Phone";
                            break;
                    case 4:
                        CreditAim = "Else";
                        break;

                }
                Console.WriteLine("Enter credit term: ");
                int CreditTerm = int.Parse(Console.ReadLine());
                               
                Console.WriteLine("Credit history");
                int creditHistory = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Overdue: ");
                int overdueCreditHistory = int.Parse(Console.ReadLine());
                bool result = Calculator.GetResult(age, Gender, creditHistory, overdueCreditHistory, SumOfCredit, TotalIncome, CreditAim);
                if (result == true)
                {
                    Console.WriteLine("You are approved for credit");
                    command.CommandText = "insert into Application(" +
                    "SumOfCredit, " +
                    "SumOfPayment, " +
                    "ApplicationDate, " +
                    "CreditStatus, " +
                    "TotalIncome, " +
                    "CreditAim, " +
                    "CreditTerm ) Values (" +
                    $"'{SumOfCredit}'," +
                    $"'{SumOfPayment}'," +
                    $"'{ApplicationDate}'," +
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
