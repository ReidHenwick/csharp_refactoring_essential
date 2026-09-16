namespace DivergentChange;

using System;
using System.Text.RegularExpressions;

public class CustomerService
{
    public string FormatDisplayName(string firstName, string lastName)
    {
        return firstName.Trim() + " " + lastName.Trim().ToUpper();
    }

    public int CalculateLoyaltyPoints(int numberOfPurchases)
    {
        return numberOfPurchases * 10;
    }

    public string DetermineAccountStatus(int daysSinceLastLogin)
    {
        if (daysSinceLastLogin > 365)
        {
            return "INACTIVE";
        }
        else if (daysSinceLastLogin > 30)
        {
            return "DORMANT";
        }

        return "ACTIVE";
    }
}