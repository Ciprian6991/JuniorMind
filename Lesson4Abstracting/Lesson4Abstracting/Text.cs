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

            if (!string.IsNullOrEmpty(text)
                && text.Length >= prefix.Length
                && text.Contains(prefix, StringComparison.Ordinal))
            {
                return prefix.Length != text.Length
                    ? new Match(text.Substring(text.LastIndexOf(text[prefix.Length])), true)
                    : new Match("", true);
            }

            return new Match(text, false);
        }
    }
}
