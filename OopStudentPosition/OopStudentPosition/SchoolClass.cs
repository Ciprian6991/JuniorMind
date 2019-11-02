using System;
using System.Collections.Generic;
using System.Text;

namespace OopStudentPosition
{
    public class SchoolClass
    {
        readonly string className;
        readonly double[] grades;

        public SchoolClass(string className, double[] grades)
        {
            this.className = className;
            this.grades = grades;
        }

        public double GetAverageGrade()
        {
            double average = 0;
            for (int i = 0; i < grades.Length; i++)
            {
                average += grades[i];
            }

            if (grades.Length == 0)
            {
                return 0;
            }

            return average / grades.Length;
        }

        public bool HasSameName(SchoolClass cls)
        {
            return cls != null && className == cls.GetName();
        }

        private string GetName()
        {
            return className;
        }
    }
}
