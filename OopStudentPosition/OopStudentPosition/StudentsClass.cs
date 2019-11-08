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

        public void AddGradeToStudent(string studentName, string className, double grade)
        {
            foreach (Student st in students)
            {
                if (st.HasMatchedName(studentName))
                {
                    st.AddGradeByClassName(className, grade);
                }
            }
        }

        public void SortStudentsByGradesDescending()
        {
            for (int i = 0; i < students.Length - 1; i++)
            {
                Student student1 = students[i];
                for (int i1 = i + 1; i1 < students.Length; i1++)
                {
                    Student student2 = students[i1];
                    if (student2.GetFinalGrade() > student1.GetFinalGrade())
                    {
                        Swap(i, i1);
                    }
                }
            }
        }

        public Student GetStudentByTopPosition(int position)
        {
            return GetStudentFromPosition(position - 1);
        }

        public Student GetStudentFromPosition(int i)
        {
            return students[i];
        }

        private void Swap(int i, int i1)
        {
            Student aux = students[i];
            students[i] = students[i1];
            students[i1] = aux;
        }
    }
}
