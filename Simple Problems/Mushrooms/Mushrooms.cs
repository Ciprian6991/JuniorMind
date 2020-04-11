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

        [Fact]
        public void NumberOfRedMushroomsWhenMultiplyingFactorHasABiggerPositiveValue()
        {
            int redMushrooms = CalculateNumberOfRedMushrooms(15, 2);
            Assert.Equal(10, redMushrooms);
        }

        int CalculateNumberOfRedMushrooms(int numberOfMushrooms, int xFactorForWhiteMushrooms)
        {
            int whiteMushrooms = numberOfMushrooms / (xFactorForWhiteMushrooms + 1);
            return whiteMushrooms * xFactorForWhiteMushrooms;
        }
    }
}
