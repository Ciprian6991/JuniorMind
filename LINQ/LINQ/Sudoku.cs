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

        public static bool CheckLine(IEnumerable<int> line)
        {
            return line.All(digit => Enumerable.Range(1, line.Count()).Contains(digit));
        }

        private IEnumerable<IEnumerable<int>> GetLines()
        {
            return square.Select(x => x);
        }
    }
}
