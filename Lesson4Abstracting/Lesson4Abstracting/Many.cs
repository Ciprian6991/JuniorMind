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
            while (pattern.Match(text).Success())
            {
                text = pattern.Match(text).RemainingText();
            }

            return new Match(text, true);
        }
    }
}
