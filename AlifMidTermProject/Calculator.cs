using System;
using System.Collections.Generic;
using System.Text;

namespace AlifMidTermProject
{
    public static class Calculator
    {
        public static bool GetResult(int age, int creditHistory, int overdueCreditHistory)
        {
            int score = 0;
            if (Customers.Gender == 'F')
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
            else if (age >= 36 && age <= 62)
                score += 2;
            else if (age > 63)
                score += 1;

            if (Customers.Citizenship == "Tajikistan")
                score += 1;
            else if (Customers.Citizenship == "Foreigner")
                score+=0;

            decimal salaryFromCreditSum = Application.SumOfCredit * 100 / Application.TotalIncome;

            if (creditHistory >= 3)
                score += 2;
            else if (creditHistory == 1 || creditHistory == 2)
                score++;
            else if (creditHistory == 0)
                score--;

            if (overdueCreditHistory > 7)
                score -= 3;
            else if (overdueCreditHistory == 5 || overdueCreditHistory == 6 || overdueCreditHistory == 7)
                score -= 2;
            else if (overdueCreditHistory == 4)
                score -= 1;
            else if (overdueCreditHistory < 3)
                score += 0;

            if (Application.CreditAim == "Appliances")
                score += 2;
            else if (Application.CreditAim == "Construction")
                score++;
            else if (Application.CreditAim == "Cell Phone")
                score += 0;
            else
                score--;
            if (Application.CreditTerm >= 12)
                score++;
            else score++;

            return (score > 12) ? true : false;
        }
    }
}
