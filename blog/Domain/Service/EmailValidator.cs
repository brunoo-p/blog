using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace blog.Domain.Service
{
    public class EmailValidator
    {
        public static bool Validate(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}