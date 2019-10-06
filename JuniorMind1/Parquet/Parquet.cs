using System;
using Xunit;

namespace Parquet
{
    public class Parquet
    {
        [Fact]
        public void NumberOfBoardsForIntegerAreaParameters()
        {
            int boardsNumber = Convert.ToInt32((NumberOfParquetBoards(2, 3, 1, 2)));
            Assert.Equal(4, boardsNumber);
        }

        double NumberOfParquetBoards(double N, double M, double A, double B)
        {
            return Math.Ceiling((N * M + (0.15 * N * M)) / (A * B));
        }
    }
}
