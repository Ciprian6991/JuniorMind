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
            return string.IsNullOrEmpty(prefix)
                ? new Match(text, true)
                : string.IsNullOrEmpty(text)
                ? new Match(text, false)
                : text.StartsWith(prefix)
                ? new Match(text.TrimStart(prefix.ToCharArray()), true)
                : new Match(text, false);
        }
    }
}
