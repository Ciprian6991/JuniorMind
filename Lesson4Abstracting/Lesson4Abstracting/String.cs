using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson4Abstracting
{
    public class String
    {
        private readonly IPattern pattern;

        public String()
        {
            pattern = new Sequence(new Character('"'), new Character('"'));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
