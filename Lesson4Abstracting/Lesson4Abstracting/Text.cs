using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson4Abstracting
{
    public class Text : IPattern
    {
        readonly string prefix;

        public Text(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            if (string.Equals(prefix, text, StringComparison.Ordinal))
            {
                return new Match("", true);
            }

            return new Match(text, false);
        }
    }
}
