using System;
using Xunit;

namespace OopStudentPosition.Facts
{
    public class StudentFacts
    {
        [Fact]
        public void TestToVerifyIfTwoIdenticalStudentsReturnsTrue()
        {
            var st1 = new Student(9.88, "Adrian");
            var st2 = new Student(9.88, "Adrian");
            Assert.True(st1.HasEqualValues(st2));
        }

        [Fact]
        public void TestToVerifyIfStudentReturnsCorrectName()
        {
            var st = new Student(9.88, "Maria");
            Assert.True(st.HasMatchedName("Maria"));
        }
    }
}
