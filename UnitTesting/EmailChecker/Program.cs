using System;

namespace EmailChecker
{
    public class Program
    {
        static void Main(string[] args)
        {
            string mailaddress = "ich@provider.com";
            if (IsEmailAddress(mailaddress))
                Console.WriteLine(mailaddress + "ist eine gültige Adresse.");
            else
                Console.WriteLine(mailaddress + "ist keine gültige Adresse.");
        }

        public static bool IsEmailAddress(string emailAddress)
        {
            int iAt = emailAddress.IndexOf('@');
            int iDot = emailAddress.LastIndexOf('.');
            return (iAt > 0 && iDot > iAt);
        }
    }
}
