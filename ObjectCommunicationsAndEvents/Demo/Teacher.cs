namespace Demo
{
    using System;

    public class Teacher
    {
        public event EventHandler StartTalking;

        public Teacher(string name)
        {
            this.Name = name;
        }
            
        public string Name { get; set; }

        public void StartClass(string className)
        {
            this.StartTalking(this, new TeacherEventArgs
            {
                ClassName = className
            });


        }
    }
}
