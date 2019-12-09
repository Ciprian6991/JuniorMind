using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson4Abstracting
{
    public class Many : IPattern
    {
        readonly IPattern pattern;

        public Many(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text).Success()
                ? GetTrimmedPattern(text)
                : new Match(text, true);
        }

        private Match GetTrimmedPattern(string text)
        {
            while (pattern.Match(text).Success())
            {
                text = text.Substring(1);
            }

            return new Match(text, true);
        }
    }
}
