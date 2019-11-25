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
            if (string.IsNullOrEmpty(prefix))
            {
                return new Match(text, true);
            }

            if (string.IsNullOrEmpty(text))
            {
                return new Match(text, false);
            }

            if (text.StartsWith(prefix))
            {
                return new Match(text.Substring(prefix.Length), true);
            }

            return new Match(text, false);
        }
    }
}
