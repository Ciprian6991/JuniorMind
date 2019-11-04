using System;
using System.Collections.Generic;
using System.Text;

namespace OopStudentPosition
{
    public class StudentsClass
    {
        readonly Student[] students;
        readonly double[] topPositions;

        public StudentsClass(Student[] students)
        {
            this.students = students;
            topPositions = GetTopPositons();
        }

        public double SearchPositionOfStudentByName(string studentName)
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

        public double GetTopPositionByName(string studentName)
        {
            int position = -1;
            foreach (Student student in students)
            {
                position++;
                if (student.HasMatchedName(studentName))
                {
                    return topPositions[position];
                }
            }

            return -1;
        }

        public string GetNameByTopPosition(int position)
        {
            int searchedPosition = -1;
            for (int i = 0; i < topPositions.Length; i++)
            {
                if (topPositions[i].Equals(position))
                {
                    searchedPosition = i;
                }
            }

            int studentPosition = 0;
            foreach (Student student in students)
            {
                if (studentPosition == searchedPosition)
                {
                    return student.GetStudentName();
                }

                studentPosition++;
            }

            return "doesn't exist";
        }

        public double[] WriteGrades()
        {
            return topPositions;
        }

        private double[] GetTopPositons()
        {
            double[] finalGradesTop = new double[students.Length];
            double[] grades = new double[students.Length];
            for (int i = 0; i < students.Length; i++)
            {
                grades[i] = students[i].GetFinalGrade();
            }

            double[] gradesTop = GetDownSortedGrades(grades);
            for (int i = 0; i < gradesTop.Length; i++)
            {
                for (int j = 0; j < grades.Length; j++)
                {
                    if (gradesTop[i].Equals(grades[j]))
                    {
                        finalGradesTop[j] = i + 1;
                    }
                }
            }

            return finalGradesTop;
        }

        private double[] GetDownSortedGrades(double[] grades)
        {
            double[] gradesSorted = new double[grades.Length];
            for (int i = 0; i < gradesSorted.Length; i++)
            {
                gradesSorted[i] = grades[i];
            }

            for (int i = 0; i < gradesSorted.Length - 1; i++)
            {
                for (int j = i + 1; j < gradesSorted.Length; j++)
                {
                    if (gradesSorted[i] < gradesSorted[j])
                    {
                        double aux = gradesSorted[i];
                        gradesSorted[i] = gradesSorted[j];
                        gradesSorted[j] = aux;
                    }
                }
            }

            return gradesSorted;
        }
    }
}
