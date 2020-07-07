using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LINQ.Tests
{
    public class SudokuFacts
    {
        [Fact]
        public void CheckSudoku_Check_Line_True()
        {

            var line = new int[][]
            {
                new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9 }
            };

            var result = new Sudoku(line).HasAllLinesValid();
            
            Assert.True(result);
        }

        [Fact]
        public void CheckSudoku_Check_Line_DuplicateNumber_False()
        {

            var line = new int[][]
            {
                new int[] {1, 2, 3, 4, 5, 6, 7, 9, 9 }
            };

            var result = new Sudoku(line).HasAllLinesValid();

            Assert.False(result);
        }

        [Fact]
        public void CheckSudoku_Check_Line_MultipleLines()
        {

            var line = new int[][]
            {
                new int[] {1, 4, 7, 2, 5, 8, 9, 3, 6 },
                new int[] {2, 5, 8, 3, 6, 9, 1, 4, 7 },
                new int[] {3, 6, 9, 4, 7, 1, 2, 5, 8 },

            };

            var result = new Sudoku(line).HasAllLinesValid();

            Assert.True(result);
        }
    }
}
