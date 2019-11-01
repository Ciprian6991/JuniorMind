using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OopStudentPosition.Facts
{
    public class SchoolClassFacts
    {
        [Fact]
        public void ImplementTwoClassesByVectorGrades()
        {
            double[] grades = { 5, 8, 9, 10 };
            SchoolClass class1 = new SchoolClass("Math", grades);
            SchoolClass class2 = new SchoolClass("Math", grades);
            Assert.True(class1.HasSameName(class2));
        }

        [Fact]
        public void TestForAddingGradeByClassName()
        {
            double[] grades = { 8, 10 };
            SchoolClass class1 = new SchoolClass("Math", grades);
            Assert.Equal(9, class1.GetAverageGrade());
        }

        [Fact]
        public void TestForAverageGradeIfThereAreNoGrades()
        {
            double[] grades = Array.Empty<double>();
            SchoolClass class1 = new SchoolClass("Math", grades);
            Assert.Equal(0, class1.GetAverageGrade());
        }
    }
}
