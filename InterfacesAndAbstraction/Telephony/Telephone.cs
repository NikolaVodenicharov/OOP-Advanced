using System;

namespace Telephony
{
    public class Telephone : ICall, IBrowse
    {
        public string Browse(string site)
        {
            if (isSite(site))
            {
                string format = $"Browsing: {site}!";
                return format;
            }

            return "Invalid URL!";
        }

        public string Call(string number)
        {
            if (isPhoneNumber(number))
            {
                return "Calling... " + number;
            }

            return "Invalid number!";
        }

        private bool isSite(string site)
        {
            for (int i = 0; i < site.Length; i++)
            {
                if (char.IsDigit(site[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private bool isPhoneNumber (string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (!char.IsDigit(number[i]))
                {
                    return false;
                }
            }

            return true;
        }
        
    }
}
