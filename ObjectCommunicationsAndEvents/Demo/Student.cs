namespace Demo
{
    using System;

    public class Student
    {
        public string Name { get; set; }

        public Student (string name)
        {
            this.Name = name;
        }

        public void AttendClass(Teacher teacher)
        {
            teacher.StartTalking += Teacher_StartTalking;
        }

        private void Teacher_StartTalking(object sender, EventArgs e)
        {
            var teacherName = ((Teacher)sender).Name;
            var className = ((TeacherEventArgs)e).ClassName;

            Console.WriteLine($"{this.Name} is listening the teacher {teacherName} in {className} class");
        }
    }
}
