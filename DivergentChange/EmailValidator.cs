using System.Text.RegularExpressions;

namespace DivergentChange;

public class EmailValidator
{
    public bool IsValidEmail(string email)
    {
        if (email == null)
        {
            return false;
        }

        return Regex.IsMatch(
            email,
            @"^[A-Za-z0-9+_.-]+@[A-Za-z0-9.-]+$");
    }
}
