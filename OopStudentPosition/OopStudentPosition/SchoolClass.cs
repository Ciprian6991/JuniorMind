﻿using System;
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
            for (int i = 0; i < GetGradesLength(); i++)
            {
                average += grades[i];
            }

            if (GetGradesLength() == 0)
            {
                return 0;
            }

            return average / GetGradesLength();
        }

        public bool HasSameName(SchoolClass cls)
        {
            return cls != null && className == cls.GetName();
        }

        private string GetName()
        {
            return className;
        }

        private int GetGradesLength()
        {
            return grades.Length;
        }
    }
}
