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


        [Fact]
        public void CheckSudoku_Check_Columns_MultipleLines()
        {

            var line = new int[][]
            {
                new int[] { 4, 3, 5, 2, 6, 9, 7, 8, 1 },
                new int[] { 6, 8, 2, 5, 7, 1, 4, 9, 3 },
                new int[] { 1, 9, 7, 8, 3, 4 ,5, 6, 2 },
                new int[] { 8, 2, 6, 1, 9, 5, 3, 4, 7 },
                new int[] { 3, 7, 4, 6, 8, 2, 9, 1, 5 },
                new int[] { 9, 5, 1, 7, 4, 3, 6, 2, 8 },
                new int[] { 5, 1, 9, 3, 2, 6, 8, 7, 4 },
                new int[] { 2, 4, 8, 9, 5, 7, 1, 3, 6 },
                new int[] { 7, 6, 3, 4, 1, 8, 2, 5, 9 },

            };

            var result = new Sudoku(line).HasAllColumnsValid();

            Assert.True(result);
        }

        [Fact]
        public void CheckSudoku_Check_Blocks_MultipleLines()
        {

            var line = new int[][]
            {
                new int[] { 4, 3, 5, 2, 6, 9, 7, 8, 1 },
                new int[] { 6, 8, 2, 5, 7, 1, 4, 9, 3 },
                new int[] { 1, 9, 7, 8, 3, 4 ,5, 6, 2 },
                new int[] { 8, 2, 6, 1, 9, 5, 3, 4, 7 },
                new int[] { 3, 7, 4, 6, 8, 2, 9, 1, 5 },
                new int[] { 9, 5, 1, 7, 4, 3, 6, 2, 8 },
                new int[] { 5, 1, 9, 3, 2, 6, 8, 7, 4 },
                new int[] { 2, 4, 8, 9, 5, 7, 1, 3, 6 },
                new int[] { 7, 6, 3, 4, 1, 8, 2, 5, 9 },

            };

            var result = new Sudoku(line).HasAllBlocksValid();

            Assert.True(result);
        }

        [Fact]
        public void CheckSudoku_IsValidSudoku_RepeatedValuesOnColumns()
        {

            var line = new int[][]
            {
                new int[] { 4, 3, 5, 2, 6, 9, 7, 8, 1 },
                new int[] { 6, 8, 2, 5, 7, 1, 4, 9, 3 },
                new int[] { 1, 9, 7, 8, 3, 4 ,5, 6, 2 },
                new int[] { 8, 2, 6, 1, 9, 5, 3, 4, 7 },
                new int[] { 3, 7, 4, 6, 8, 2, 9, 5, 5 },
                new int[] { 9, 5, 1, 7, 4, 3, 6, 2, 8 },
                new int[] { 5, 1, 9, 3, 2, 6, 8, 7, 4 },
                new int[] { 2, 4, 8, 9, 5, 7, 1, 3, 6 },
                new int[] { 7, 6, 3, 4, 1, 8, 2, 5, 9 },

            };

            var result = new Sudoku(line).IsValidSudoku();

            Assert.False(result);
        }

        [Fact]
        public void CheckSudoku_IsValidSudoku_3x4_False()
        {

            var line = new int[][]
            {
                new int[] { 1, 2, 3, 4 },
                new int[] { 2, 3, 4, 1 },
                new int[] { 3, 4, 1, 2 },
            };

            var result = new Sudoku(line).IsValidSudoku();

            Assert.False(result);
        }
    }
}
