using System;
using Xunit;

namespace OopStudentPosition.Facts
{
    public class StudentFacts
    {
        [Fact]
        public void TestToVerifyIfTwoIdenticalNamedStudentsReturnsTrue()
        {
            double[] grades1 = { 5, 8, 9, 10 };
            string className1 = "Math";
            double[] grades2 = { 2, 1, 5, 7 };
            string className2 = "English";
            SchoolClass class1 = new SchoolClass(className1, grades1);
            SchoolClass class2 = new SchoolClass(className2, grades2);
            SchoolClass[] finalClasses1 = { class1, class2 };
            double[] grades3 = { 7, 6, 9, 6 };
            string className3 = "Sport";
            double[] grades4 = { 9, 1, 3, 2 };
            string className4 = "Biology";
            SchoolClass class3 = new SchoolClass(className3, grades3);
            SchoolClass class4= new SchoolClass(className4, grades4);
            SchoolClass[] finalClasses2 = { class1, class2 };
            var st1 = new Student("Adrian", finalClasses1);
            var st2 = new Student("Adrian", finalClasses2);
            Assert.True(st1.HasEqualValues(st2));
        }

        [Fact]
        public void TestToVerifyIfTwoDiferentNamedStudentsReturnsFalse()
        {
            double[] grades1 = { 5, 8, 9, 10 };
            string className1 = "Math";
            double[] grades2 = { 2, 1, 5, 7 };
            string className2 = "English";
            SchoolClass class1 = new SchoolClass(className1, grades1);
            SchoolClass class2 = new SchoolClass(className2, grades2);
            SchoolClass[] finalClasses1 = { class1, class2 };
            double[] grades3 = { 7, 6, 9, 6 };
            string className3 = "Sport";
            double[] grades4 = { 9, 1, 3, 2 };
            string className4 = "Biology";
            SchoolClass class3 = new SchoolClass(className3, grades3);
            SchoolClass class4 = new SchoolClass(className4, grades4);
            SchoolClass[] finalClasses2 = { class1, class2 };
            var st1 = new Student("Adrian", finalClasses1);
            var st2 = new Student("Sabin", finalClasses2);
            Assert.False(st1.HasEqualValues(st2));
        }

        [Fact]
        public void TestToVerifyIfGetFinalGradeFunctionIsCorrect()
        {
            double[] grades1 = { 10, 6 };
            string className1 = "Math";
            double[] grades2 = { 10, 10 };
            string className2 = "English";
            SchoolClass class1 = new SchoolClass(className1, grades1);
            SchoolClass class2 = new SchoolClass(className2, grades2);
            SchoolClass[] finalClasses1 = { class1, class2 };
            var st1 = new Student("Sabin", finalClasses1);
            Assert.Equal(9, st1.GetFinalGrade());
        }
    }
}
