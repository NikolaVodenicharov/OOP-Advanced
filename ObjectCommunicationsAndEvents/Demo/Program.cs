namespace Demo
{
    using System;

    public class Program
    {
        //public delegate void WorkPerformedDelegate(int hours, string woker);

        public static void Main()
        {


            var firstStudent = new Student("George");
            var secondStudent = new Student("Erik");
            var thirdStudent = new Student("John");
            var forthStudent = new Student("Charles");

            var teacher = new Teacher("Michael");
            firstStudent.AttendClass(teacher);
            secondStudent.AttendClass(teacher);

            teacher.StartClass("Math");


            //    //WorkPerformedDelegate dele = WorkPerformed;

            //    //dele(15, "Charles");

            //    WorkPerformedDelegate anonymousDelegate = delegate (int hours, string worker)
            //    {
            //        Console.WriteLine("Hi");
            //    };

            //    anonymousDelegate(15, "wtf");

            //    WorkPerformedDelegate some = (h, t) => Console.WriteLine("fo?");
            //    some(5, "gg");
            //}

            //public static void WorkPerformed(int hours, string worker)
            //{
            //    Console.WriteLine("Work performed for: " + hours + " hours for " + worker);
            //}
        }
    }
}
