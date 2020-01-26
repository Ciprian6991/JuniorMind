using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson4Abstracting
{
    public class Choice : IPattern
    {
        IPattern[] patterns;

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

        public void Add(IPattern patternToAdd)
        {
            IPattern[] finalPatterns = new IPattern[patterns.Length + 1];
            uint index = 0;
            foreach (IPattern pattern in patterns)
            {
                finalPatterns[index] = pattern;
                index++;
            }

            finalPatterns[index] = patternToAdd;
            patterns = finalPatterns;
        }
    }
}