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
                matching = pattern.Match(matching.RemainingText()).Success()
                    ? new Match(pattern.Match(matching.RemainingText()).RemainingText(), true)
                    : new Match(text, false);
            }

            return matching;
        }
    }
}
