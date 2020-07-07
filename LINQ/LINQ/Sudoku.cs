using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ
{
    public class Sudoku
    {
        private readonly int[][] square;

        public Sudoku(int[][] square)
        {
            this.square = square;
        }

        public bool IsValidSudoku()
        {
            throw new NotImplementedException();
        }

        public bool HasAllLinesValid()
        {
            var lines = GetLines();

            return lines.All(line => CheckLine(line));
        }

        private bool CheckLine(IEnumerable<int> line)
        {
            return Enumerable.Range(1, line.Count()).All(digit => line.Contains(digit));
        }

        private IEnumerable<IEnumerable<int>> GetLines()
        {
            return square.Select(x => x);
        }
    }
}
