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
            string workingString = text;
            while (pattern.Match(workingString).Success())
            {
                workingString = workingString.Substring(1);
            }

            return new Match(workingString, true);
        }
    }
}
