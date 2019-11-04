using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OopStudentPosition.Facts
{
    public class StudentsClassFacts
    {
        [Fact]
        public void TestToVerifyIfWeHaveCorrectTopPositionFromAThreeStudentsClass()
        {
            double[] grades1 = { 9, 9, 9, 9 };
            const string className1 = "Math";
            double[] grades2 = { 9, 9, 9, 9 };
            const string className2 = "English";
            SchoolClass class1 = new SchoolClass(className1, grades1);
            SchoolClass class2 = new SchoolClass(className2, grades2);
            SchoolClass[] finalClasses1 = { class1, class2 };

            double[] grades3 = { 10, 10, 10, 10 };
            const string className3 = "Sport";
            double[] grades4 = { 10, 10, 10, 10 };
            const string className4 = "Biology";
            SchoolClass class3 = new SchoolClass(className3, grades3);
            SchoolClass class4 = new SchoolClass(className4, grades4);
            SchoolClass[] finalClasses2 = { class3, class4 };

            double[] grades5 = { 6, 6, 6, 6 };
            const string className5 = "Logic";
            double[] grades6 = { 6, 6, 6, 6 };
            const string className6 = "Electro";
            SchoolClass class5 = new SchoolClass(className5, grades5);
            SchoolClass class6 = new SchoolClass(className6, grades6);
            SchoolClass[] finalClasses3 = { class5, class6 };

            var st1 = new Student("Adrian", finalClasses1);
            var st2 = new Student("Sabin", finalClasses2);
            var st3 = new Student("Larisa", finalClasses3);
            Student[] sts = { st1, st2, st3 };
            StudentsClass clasaDinScoala = new StudentsClass(sts);
            Assert.Equal(1, clasaDinScoala.GetTopPositionByName("Sabin"));
        }

        [Fact]
        public void TestToVerifyIfWeHaveCorrectNamebyGivenTopPosition()
        {
            double[] grades1 = { 9, 9, 9, 9 };
            const string className1 = "Math";
            double[] grades2 = { 9, 9, 9, 9 };
            const string className2 = "English";
            SchoolClass class1 = new SchoolClass(className1, grades1);
            SchoolClass class2 = new SchoolClass(className2, grades2);
            SchoolClass[] finalClasses1 = { class1, class2 };

            double[] grades3 = { 10, 10, 10, 10 };
            const string className3 = "Sport";
            double[] grades4 = { 10, 10, 10, 10 };
            const string className4 = "Biology";
            SchoolClass class3 = new SchoolClass(className3, grades3);
            SchoolClass class4 = new SchoolClass(className4, grades4);
            SchoolClass[] finalClasses2 = { class3, class4 };

            double[] grades5 = { 6, 6, 6, 6 };
            const string className5 = "Logic";
            double[] grades6 = { 6, 6, 6, 6 };
            const string className6 = "Electro";
            SchoolClass class5 = new SchoolClass(className5, grades5);
            SchoolClass class6 = new SchoolClass(className6, grades6);
            SchoolClass[] finalClasses3 = { class5, class6 };

            var st1 = new Student("Adrian", finalClasses1);
            var st2 = new Student("Sabin", finalClasses2);
            var st3 = new Student("Larisa", finalClasses3);
            Student[] sts = { st1, st2, st3 };
            StudentsClass clasaDinScoala = new StudentsClass(sts);
            Assert.Equal("Sabin", clasaDinScoala.GetNameByTopPosition(1));
        }
    }
}
