namespace Stealer
{
    using System;

    public class StealerExecution
    {
        public static void Main()
        {
            var spy = new Spy();
            var result = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
            Console.WriteLine(result);
        }
    }
}
