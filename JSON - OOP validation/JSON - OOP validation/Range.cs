using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson4Abstracting
{
    public class Range : IPattern
    {
        readonly char start;
        readonly char end;
        readonly string excepted;

        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
            this.excepted = string.Empty;
        }

        public Range(char start, char end, string excepted)
        {
            this.start = start;
            this.end = end;
            this.excepted = excepted;
        }

        public IMatch Match(string text)
        {
            if (!string.IsNullOrEmpty(text) && !excepted.Contains(text[0]) &&
                text[0] >= start && text[0] <= end)
            {
                return new Match(text.Substring(1), true);
            }

            return new Match(text, false);
        }
    }
}
