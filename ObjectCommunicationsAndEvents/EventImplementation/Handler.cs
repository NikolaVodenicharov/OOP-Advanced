namespace EventImplementation
{
    using System;

    public class Handler
    {
        public void OnDispatcherNameChange(object sender, NameChangeEventArgs args)
        {
            var name = args.Name;
            Console.WriteLine($"Dispatcher’s name changed to {name}");
        }
    }
}
