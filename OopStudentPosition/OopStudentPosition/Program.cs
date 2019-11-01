using System;

namespace OopStudentPosition
{
    public class Program
    {
        public static void Main()
        {
            string studentsNumbers = Console.ReadLine();
            StudentsClass students = new StudentsClass(ReadStudents(studentsNumbers));
            string nameOfSoughtStudent = Console.ReadLine();
            int positionOfSoughtStudent = students.SearchPositionOfStudentByName(nameOfSoughtStudent);
            Console.WriteLine(positionOfSoughtStudent);
            Console.Read();
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

        public static Student[] ReadStudents(string studentNumbers)
        {
            if (!string.IsNullOrEmpty(studentNumbers) && IsIntNumber(studentNumbers))
            {
                int studentsNumber = Convert.ToInt32(studentNumbers);
                Student[] result = new Student[studentsNumber];

                for (int i = 0; i < studentsNumber; i++)
                {
                    string studentString = Console.ReadLine();
                    result[i] = ReadStudent(studentString);
                }

                return result;
            }

            return Array.Empty<Student>();
        }

        private static bool IsIntNumber(string v)
        {
            if (string.IsNullOrEmpty(v))
            {
                return false;
            }

            for (int i = 0; i < v.Length; i++)
            {
                if (v[i] < '0' || v[i] > '9')
                {
                    return false;
                }
            }

            return true;
        }
    }
}