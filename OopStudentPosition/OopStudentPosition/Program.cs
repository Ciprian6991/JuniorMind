using System;

namespace OopStudentPosition
{
    public class Program
    {
        public static void Main()
        {
            StudentsClass students = new StudentsClass(ReadStudent(Console.ReadLine()));
            Console.ReadLine();
        }

        public static Student ReadStudent(string studentString)
        {
            if (!string.IsNullOrEmpty(studentString))
            {
                string[] studentData = studentString.Split(":");
                return new Student(Convert.ToDouble(studentData[1]), studentData[0]);
            }

            return new Student(-1, "-1");
        }
    }
}
