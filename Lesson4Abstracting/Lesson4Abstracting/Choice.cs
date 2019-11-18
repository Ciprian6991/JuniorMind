using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson4Abstracting
{
    public class Choice : IPattern
    {
        readonly IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            Match matching = new Match(text, false);
            foreach (IPattern pattern in patterns)
            {
                if (pattern.Match(matching.RemainingText()).Success())
                {
                    matching = new Match(pattern.Match(matching.RemainingText()).RemainingText(), pattern.Match(matching.RemainingText()).Success());
                }
            }

            return matching;
        }
    }
}
