﻿using System;

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
                        Console.WriteLine(@"Please choose action: 
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
