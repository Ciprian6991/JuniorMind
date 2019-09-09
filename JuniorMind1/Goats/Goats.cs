using System;
using Xunit;

namespace Goats
{
    public class Goats
    {
        [Fact]
        public void KgOfGrassSimpleTest()
        {
            float kg = CalculateKgOfGrass(10, 15, 10, 15, 5);
            Assert.Equal(5, kg);
        }

        float CalculateKgOfGrass(int dayX, int goatY, int kgZ, int dayW, int goatQ)
        {
            return (((dayW * kgZ) / dayX) * goatQ) / goatY;
        }

    }
}
