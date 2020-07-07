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

            var line = new int[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9
            };

            var result = Sudoku.CheckLine(line);
            
            Assert.True(result);
        }

        [Fact]
        public void CheckSudoku_Check_Line_DuplicateNumber_False()
        {

            var line = new int[]
            {
                1, 2, 3, 4, 5, 6, 7, 9, 9
            };

            var result = Sudoku.CheckLine(line);

            Assert.False(result);
        }
    }
}
