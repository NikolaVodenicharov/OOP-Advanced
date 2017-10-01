namespace Stealer
{
    using System;

    public class StealerExecution
    {
        public static void Main()
        {
            var spy = new Spy();
            var result = spy.AnalyzeAcessModifiers("Stealer.Hacker");
            Console.WriteLine(result);
        }
    }
}
