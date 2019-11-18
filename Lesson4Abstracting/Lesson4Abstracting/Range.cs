using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson4Abstracting
{
    public class Range : IPattern
    {
        readonly char start;
        readonly char end;

        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new Match(text, false);
            }

            if (text[0] >= start && text[0] <= end)
            {
                return new Match(text.Substring(1), true);
            }

            return new Match(text, false);
        }
    }
}
