namespace CreateAttributes
{
    using System;

    [Author("George")]
    public class StartUp
    {
        [Author("John")]
        public static void Main()
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}
