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
            double[] grades1 = { 5, 8, 9, 10 };
            string className1 = "Math";
            double[] grades2 = { 2, 1, 5, 7 };
            string className2 = "Math";
            SchoolClass class1 = new SchoolClass(className1, grades1);
            SchoolClass class2 = new SchoolClass(className2, grades2);
            Assert.True(class1.HasSameName(class2));
        }

        [Fact]
        public void TestForTwoClassesThatHaveDifferentNamesReturnsFalse()
        {
            double[] grades1 = { 5, 8, 9, 10 };
            string className1 = "Math";
            double[] grades2 = { 2, 1, 5, 7 };
            string className2 = "Sport";
            SchoolClass class1 = new SchoolClass(className1, grades1);
            SchoolClass class2 = new SchoolClass(className2, grades2);
            Assert.False(class1.HasSameName(class2));
        }

        [Fact]
        public void TestForAverageGrade()
        {
            double[] grades1 = { 8, 10 };
            string className1 = "Math";
            SchoolClass class1 = new SchoolClass(className1, grades1);
            Assert.Equal(9, class1.GetAverageGrade());
        }

        [Fact]
        public void TestForAverageGradeIfThereAreNoGrades()
        {
            double[] grades1 = Array.Empty<double>();
            string className1 = "Math";
            SchoolClass class1 = new SchoolClass(className1, grades1);
            Assert.Equal(0, class1.GetAverageGrade());
        }
    }
}
