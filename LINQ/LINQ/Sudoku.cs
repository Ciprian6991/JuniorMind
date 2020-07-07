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
            return HasAllLinesValid()
                && HasAllColumnsValid()
                && HasAllBlocksValid();
        }

        public bool HasAllLinesValid() => Has_All_Lines_Values_Valid(GetLines());

        public bool HasAllColumnsValid() => Has_All_Lines_Values_Valid(GetColumns());

        public bool HasAllBlocksValid() => Has_All_Lines_Values_Valid(GetBlocks());

        private bool Has_All_Lines_Values_Valid(IEnumerable<IEnumerable<int>> lines)
        {
            return lines.All(line => CheckLine(line));
        }

        private IEnumerable<IEnumerable<int>> GetBlocks()
        {
            int squareSize = (int)Math.Sqrt(square.Length);

            return Enumerable.Range(0, squareSize).SelectMany(lineIndex =>
                             Enumerable.Range(0, squareSize).Select(columnIndex => GetBlock(
                                                                                            lineIndex / squareSize * squareSize,
                                                                                            columnIndex % squareSize * squareSize,
                                                                                            squareSize)));
        }

        private IEnumerable<int> GetBlock(int lineIndex, int columnIndex, int count)
        {
            return Enumerable.Range(lineIndex, count)
                             .SelectMany(x => Enumerable.Range(columnIndex, count)
                             .Select(y => square[x][y]));
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
