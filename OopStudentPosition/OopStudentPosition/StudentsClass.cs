using System;
using System.Collections.Generic;
using System.Text;

namespace OopStudentPosition
{
    public class StudentsClass
    {
        readonly Student[] students;

        public StudentsClass(Student[] students)
        {
            this.students = students;
        }

        public StudentsClass(Student student)
        {
            this.students[students.Length + 1] = student;
        }

        public int SearchPositionOfStudentByName(string studentName)
        {
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].HasMatchedName(studentName))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
