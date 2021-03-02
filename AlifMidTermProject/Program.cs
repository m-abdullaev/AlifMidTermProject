using System;

namespace AlifMidTermProject
{
    class Program
    {
        static void Main(string[] args)
        {
            switch (ShowMainMenu())
            {
                case "1":
                    {
                        if (AdminCredentials.adminValidityCheck() == true)
                        {
                            Console.WriteLine("Welcome!");
                            Console.WriteLine(@"Choose action: 
                                 1. Create new Admin
                                 2. List of admins
                                 3. Delete admin by id
                                 ");
                            int action = Convert.ToInt32(Console.ReadLine());
                            switch (action)
                            {
                                case 1:
                                    AdminCredentials.insertAdmin();
                                    break;
                                case 2:
                                    AdminCredentials.selectAllAdmin();
                                    break;
                                case 3:
                                    AdminCredentials.deleteByIdAdmin();
                                    break;
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid data!");
                        }                       
                    }
                    break;
                case "2":
                    
                    Console.WriteLine(@"Choose action: 
                                    1. Customer Login
                                    2. Create new customer
                                    3. Exit");
                    int action2 = Convert.ToInt32(Console.ReadLine());
                    switch (action2)
                    {
                        case 1:
                            {
                                if (Customers.customerValidityCheck() == true)
                                {
                                    Console.WriteLine(@"Please choose
                                                1. Apply for credit
                                                2. My info
                                                        ");
                                }                                
                            }
                            
                            break;
                        case 2:
                            {
                                Customers.insertCustomer();
                            }
                            break;
                        case 3:
                            {
                                return;
                            }
                            break;
                    }
                    //Customers.insertCustomer();
                    //Customers.selectAllCustomers();
                    break;


            }
        }
        static string ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine($"{new string('-', 5)}Welcome to our bank{new string('-', 5)}");
            Console.Write("1. Admin\n" +
                          "2. Client\n" +                          
                          "3. Exit\n" +
                          "Choice:");
            return Console.ReadLine();
        }
    }
}
