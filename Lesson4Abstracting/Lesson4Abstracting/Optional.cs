using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson4Abstracting
{
    public class Optional
    {
        readonly IPattern pattern;

        public Optional(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            string workingText = text;

            if (pattern.Match(workingText).Success())
            {
                workingText = workingText.Substring(1);
            }

            return new Match(workingText, true);
        }
    }
}
