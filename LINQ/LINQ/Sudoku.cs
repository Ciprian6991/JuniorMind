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

        public bool HasAllLinesValid() => Has_All_Lines_Values_Valid(GetLines());

        public bool HasAllColumnsValid() => Has_All_Lines_Values_Valid(GetColumns());

        private bool Has_All_Lines_Values_Valid(IEnumerable<IEnumerable<int>> lines)
        {
            return lines.All(line => CheckLine(line));
        }

        private IEnumerable<IEnumerable<int>> GetColumns()
        {
            return Enumerable.Range(0, square.Length - 1).Select(index => square.Select(col => col[index]));
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
