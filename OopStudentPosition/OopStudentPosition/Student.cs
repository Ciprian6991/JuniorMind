using System;
using System.Collections.Generic;
using System.Text;

namespace OopStudentPosition
{
    public class Student
    {
        private string name;
        private SchoolClass[] classes;

        public Student(string name, SchoolClass[] classes)
        {
            this.name = name;
            this.classes = classes;
        }

        public bool HasMatchedName(string name)
        {
            return this.name == name;
        }

        public bool HasEqualValues(Student student2)
        {
            return student2 != null && name == student2.name;
        }

        public double GetFinalGrade()
        {
            if (classes.Length == 0)
            {
                return 0;
            }

            double grade = 0;
            foreach (SchoolClass var in classes)
            {
                grade += var.GetAverageGrade();
            }

            if (classes.Length == 0)
            {
                return 0;
            }

            return grade / classes.Length;
        }

        public void AddGradeByClassName(string className, double grade)
        {
            foreach (SchoolClass var in classes)
            {
                if (var.HasSameName(className))
                {
                    var.AddGrade(grade);
                }
            }
        }

        public void SwapStudent(Student st)
            {
            if (st == null)
            {
                return;
            }

            string auxName = name;
            SchoolClass[] auxclasses = classes;

            this.name = st.name;
            this.classes = st.classes;

            st.name = auxName;
            st.classes = auxclasses;
        }
    }
}
