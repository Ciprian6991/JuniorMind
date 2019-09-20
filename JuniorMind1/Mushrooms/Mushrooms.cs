using System;
using Xunit;

namespace Mushrooms
{
    public class Mushrooms
    {
        [Fact]
        public void NumberOfRedMushroomsForEquality()
        {
            int redMushrooms = CalculateNumberOfRedMushrooms(10, 1);
            Assert.Equal(5, redMushrooms);
        }

        int CalculateNumberOfRedMushrooms(int numberOfMushrooms, int xFactorForWhiteMushrooms)
        {
            return numberOfMushrooms / (xFactorForWhiteMushrooms + 1) * xFactorForWhiteMushrooms;
        }
    }
}
