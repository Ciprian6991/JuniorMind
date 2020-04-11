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
            IMatch matchingBackup = new Match(text, false);
            IMatch matchingUsed = new Match(text, false);
            foreach (IPattern pattern in patterns)
            {
                matchingUsed = pattern.Match(matchingUsed.RemainingText());

                if (!matchingUsed.Success())
                {
                    return matchingBackup;
                }
            }

            return matchingUsed;
        }
    }
}