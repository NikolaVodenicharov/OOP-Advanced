namespace EventImplementation
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var dispatcher = new Dispatcher();
            var handler = new Handler();
            dispatcher.NameChange += handler.OnDispatcherNameChange;

            while (true)
            {
                var inputName = Console.ReadLine();

                var isEndOfLoop = inputName == "End";
                if (isEndOfLoop)
                {
                    break;
                }

                dispatcher.Name = inputName;
            }
        }
    }
}
