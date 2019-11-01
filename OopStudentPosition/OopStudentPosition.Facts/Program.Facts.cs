using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OopStudentPosition.Facts
{
    public class ProgramFacts
    {
        [Fact]
        public void TestForReadingOneNullStudent()
        {
            string studentData = "";
            Student st = new Student(-1, "-1");
            Student st2 = Program.ReadStudent(studentData);
            Assert.True(st.HasEqualValues(st2));
        }
    }
}
