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
            if (!string.IsNullOrEmpty(text))
            {
                char character = text[0];
                if (accepted.Contains(character, StringComparison.Ordinal))
                {
                    return new Match(text.Substring(1), true);
                }
            }

            return new Match(text, false);
        }
    }
}
