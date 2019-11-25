using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson4Abstracting
{
    public class Any : IPattern
    {
        readonly string accepted;

        public Any(string accepted)
        {
            this.accepted = accepted;
        }

        public IMatch Match(string text)
        {
        return !string.IsNullOrEmpty(text) && accepted.Contains(text[0])
                ? new Match(text.Substring(1), true)
                : new Match(text, false);
        }
    }
}
