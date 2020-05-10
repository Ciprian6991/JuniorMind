﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LINQ.Tests
{
    public class StringOperationsFacts
    {
        [Fact]
        public void Test_CountVocals()
        {
            (int, int) count = StringOperations.CountVocalsConsonants("Four Words Seven Vocals");

            Assert.Equal(7, count.Item1);
        }

        [Fact]
        public void Test_CountConsonants()
        {
            (int, int) count = StringOperations.CountVocalsConsonants("Four Words Seventeen Consonant");

            Assert.Equal(17, count.Item2);
        }

        [Fact]
        public void Test_CountVocalsConsonants_WhenStringContainsDigits()
        {
            (int, int) count = StringOperations.CountVocalsConsonants("Four Words Seventeen Consonant 0123");

            Assert.Equal(17, count.Item2);
            Assert.Equal(10, count.Item1);
        }
    }
}
