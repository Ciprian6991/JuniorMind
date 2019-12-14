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
            pattern = new Sequence(
                new Optional(new Character('-')), new Many(new Range('0', '9')), new Optional(new Sequence(new Character('.'), new Many(new Range('0', '9')))));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
