using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson4Abstracting
{
    public class Sequence : IPattern
    {
        readonly IPattern[] patterns;

        public Sequence(params IPattern[] patterns)
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
                    matching = new Match(pattern.Match(matching.RemainingText()).RemainingText(), true);
                }
            }

            return matching;
        }
    }
}
