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

            if (!string.IsNullOrEmpty(text) && text.Length >= prefix.Length)
            {
                return GetRemainingText(text);
            }

            return new Match(text, false);
        }

        private IMatch GetRemainingText(string text)
        {
            if (text.Length == prefix.Length && string.Equals(prefix, text, StringComparison.Ordinal))
            {
                return new Match("", true);
            }

            for (int i = 0; i < prefix.Length; i++)
            {
                if (prefix[i] == text[i] && i == prefix.Length - 1)
                {
                    return new Match(text.Substring(i + 1), true);
                }
            }

            return new Match(text, false);
        }
    }
}
