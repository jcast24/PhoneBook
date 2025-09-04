using System.Net.Mail;
using System.Text.RegularExpressions;

namespace PhonebookProj;

class Helper
{
    public static bool CheckPhoneNumber(string phoneNumber)
    {
        if (phoneNumber.Length != 14) return false;

        string phoneNumberFormat = $"{phoneNumber.Substring(0, 5)} {phoneNumber.Substring(6, 3)}-{phoneNumber.Substring(10, 4)}";

        if (phoneNumber.Equals(phoneNumberFormat))
        {
            return true;
        }
        return false;
    }

    public static string FormatPhoneNumber(string phoneNumber)
    {
        string cleanedNumber = Regex.Replace(phoneNumber, "[^0-9]", "");

        if (cleanedNumber.Length > 10)
        {
            return $"+{cleanedNumber.Substring(0, cleanedNumber.Length - 10)} " +
                $"{cleanedNumber.Substring(cleanedNumber.Length - 10, 3)}-" +
                $"{cleanedNumber.Substring(cleanedNumber.Length - 7, 3)}-" +
                $"{cleanedNumber.Substring(cleanedNumber.Length - 4, 4)}";
        }
        else if (cleanedNumber.Length == 10)
        {
            return $"({cleanedNumber.Substring(0, 3)}) {cleanedNumber.Substring(3, 3)}-" + $"{cleanedNumber.Substring(6, 4)}";
        }
        else
        {
            return cleanedNumber;
        }
    }

    public static bool ValidateEmail(string email)
    {
        var valid = true;

        try
        {
            var emailAddress = new MailAddress(email);
        }
        catch
        {
            valid = false;
        }

        return valid;
    }
}
