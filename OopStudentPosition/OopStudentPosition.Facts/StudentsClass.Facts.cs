using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OopStudentPosition.Facts
{
        public class StudentsClassFacts
        {
            [Fact]
            public void NullStudentNumbersValueIsInvalid()
            {
                Student[] sts = Array.Empty<Student>();
                StudentsClass students = new StudentsClass(sts);
                Assert.Equal(-1, students.SearchPositionOfStudentByName(""));
            }

            [Fact]
            public void ShowsThePositionsForASingleStudentWithValidParameters()
            {
                Student st1 = new Student(9.81, "Sabin");
                Student[] sts = new Student[1];
                sts[0] = st1;
                StudentsClass students = new StudentsClass(sts);
                Assert.Equal(0, students.SearchPositionOfStudentByName("Sabin"));
            }

            [Fact]
            public void ShowsThePositionsForASingleStudentWithInvalidParameters()
            {
                Student st1 = new Student(9.81, "Sabin");
                Student[] sts = new Student[1];
                sts[0] = st1;
                StudentsClass students = new StudentsClass(sts);
                Assert.Equal(-1, students.SearchPositionOfStudentByName("Zabin"));
            }

            [Fact]
            public void ShowsThePositionsForFiveStudentsWithValidParameters()
            {
                Student st1 = new Student(9.81, "Sabin");
                Student st2 = new Student(5.31, "Adrian");
                Student st3 = new Student(9.01, "Elena");
                Student st4 = new Student(8.43, "Costas");
                Student st5 = new Student(7.13, "Andreea");
                Student[] sts = { st1, st2, st3, st4, st5 };
                StudentsClass students = new StudentsClass(sts);
                Assert.Equal(4, students.SearchPositionOfStudentByName("Andreea"));
            }

            [Fact]
            public void ShowsThePositionsForFiveStudentsWithInvalidParameters()
            {
                Student st1 = new Student(9.81, "Sabin");
                Student st2 = new Student(5.31, "Adrian");
                Student st3 = new Student(9.01, "Elena");
                Student st4 = new Student(8.43, "Costas");
                Student st5 = new Student(7.13, "Andreea");
                Student[] sts = { st1, st2, st3, st4, st5 };
                StudentsClass students = new StudentsClass(sts);
                Assert.Equal(-1, students.SearchPositionOfStudentByName("Daniela"));
            }
        }
}
