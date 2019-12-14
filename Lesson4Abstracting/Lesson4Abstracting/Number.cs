using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson4Abstracting
{
    public class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {
            pattern = new Many(new Range('0', '9'));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
