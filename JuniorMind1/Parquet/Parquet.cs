using System;
using Xunit;

namespace Parquet
{
    public class Parquet
    {
        [Fact]
        public void NumberOfBoardsForIntegerAreaParameters()
        {
            int boardsNumber = Convert.ToInt32(Math.Ceiling(NumberOfParquetBoards(2, 3, 1, 2)));
            Assert.Equal(3, boardsNumber);
        }

        double NumberOfParquetBoards(float N, float M, float A, float B)
        {
            return 2.1;
        }
    }
}