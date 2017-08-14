namespace Telephony
{
    using System;

    public class TelephonyExecution
    {
        public static void Main(string[] args)
        {
            var myPhone = new Telephone();

            var numbersToCall = Console.ReadLine().Split();
            foreach (var phoneNumber in numbersToCall)
            {
                Console.WriteLine(myPhone.Call(phoneNumber));
            }

            var sitesToVisit = Console.ReadLine().Split();
            foreach (var site in sitesToVisit)
            {
                Console.WriteLine(myPhone.Browse(site));
            }
        }
    }
}
