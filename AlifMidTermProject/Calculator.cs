using System;
using System.Collections.Generic;
using System.Text;

namespace AlifMidTermProject
{
    public static class Calculator
    {
        public static bool GetResult(int age, char Gender, int creditHistory, int overdueCreditHistory, decimal SumOfCredit, decimal TotalIncome, string CreditAim )
        {
            int score = 0;
            if (Gender == 'F')
                score += 2;
            else
                score++;
            if (Customers.MaritalStatus == "Single")
                score++;
            else if (Customers.MaritalStatus == "Married")
                score += 2;
            else if (Customers.MaritalStatus == "Divorced")
                score++;
            else if (Customers.MaritalStatus == "Widow")
                score += 2;

            if (age <= 25)
                score += 0;
            else if (age >= 26 && age <= 35)
                score += 1;
            else if (age > 35 && age < 63)
                score += 2;
            else if (age >= 63)
                score += 1;

            if (Customers.Citizenship == "Tajikistan")
                score += 1;
            else if (Customers.Citizenship == "Foreigner")
                score+=0;

            decimal salaryFromCreditSum = SumOfCredit * 100 / TotalIncome;

            if (salaryFromCreditSum <= 80)
                score += 4;
            else if (salaryFromCreditSum > 80 && salaryFromCreditSum <= 150)
                score += 3;
            else if (salaryFromCreditSum > 150 && salaryFromCreditSum <= 250)
                score += 2;
            else
                score += 1;

            if (creditHistory >= 3)
                score += 2;
            else if (creditHistory == 1 || creditHistory == 2)
                score++;
            else if (creditHistory == 0)
                score--;

            if (overdueCreditHistory > 7)
                score -= 3;
            else if (overdueCreditHistory >= 5 && creditHistory <= 7)
                score -= 2;
            else if (overdueCreditHistory == 4)
                score -= 1;
            else if (overdueCreditHistory <= 3)
                score += 0;

            if (CreditAim == "Appliances")
                score += 2;
            else if (CreditAim == "Construction")
                score++;
            else if (CreditAim == "Cell Phone")
                score += 0;
            else
                score--;

            if (Application.CreditTerm >= 12)
                score++;
            else score++;
            if(score>11)
            {
                Console.WriteLine("Score = "+score);
                return true;
            }
            else
            {
                Console.WriteLine("Score = " + score);
                return false;
            }
        }
    }
}
