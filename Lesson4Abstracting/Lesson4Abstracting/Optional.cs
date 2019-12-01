using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson4Abstracting
{
    public class Optional : IPattern
    {
        readonly IPattern pattern;

        public Optional(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text).Success() ?
                new Match(text.Substring(1), true) :
                new Match(text, true);
        }
    }
}
