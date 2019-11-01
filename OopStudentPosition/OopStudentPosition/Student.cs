using System;
using System.Collections.Generic;
using System.Text;

namespace OopStudentPosition
{
    public class Student
    {
            readonly double grade;
            readonly string name;

            public Student(double grade, string name)
            {
                this.grade = grade;
                this.name = name;
            }

            public bool HasMatchedName(string name)
            {
                return this.name == name;
            }

            public bool HasMatchedGrade(double grade)
            {
                return this.grade.Equals(grade);
            }

            public bool HasEqualValues(Student student2)
            {
                return student2 != null && this.grade.Equals(student2.grade) && name == student2.name;
            }
    }
}
