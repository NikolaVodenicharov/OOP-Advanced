namespace _01.Database
{
    public class Person
    {
        public Person (string id, string username)
        {
            this.Id = id;
            this.Username = username;
        }

        public string Id { get; private set; }
        public string Username { get; private set; }
    }
}
