using System;
using Xunit;

namespace OopStudentPosition.Facts
{
    public class StudentFacts
    {
        [Fact]
        public void Test1()
        {
            var st = new Student(9.88, "Adrian");
            Assert.True(st.HasMatchedGrade(9.88));
        }

        [Fact]
        public void Test2()
        {
            var st = new Student(9.88, "Maria");
            Assert.True(st.HasMatchedName("Maria"));
        }
    }
}
