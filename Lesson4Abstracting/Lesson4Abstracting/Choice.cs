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
            IMatch matching = new Match(text, false);
            foreach (IPattern pattern in patterns)
            {
                matching = pattern.Match(matching.RemainingText());

                if (matching.Success())
                {
                    return matching;
                }
            }

            return new Match(text, false);
        }
    }
}