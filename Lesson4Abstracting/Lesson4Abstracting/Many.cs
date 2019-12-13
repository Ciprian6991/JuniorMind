using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson4Abstracting
{
    public class Many : IPattern
    {
        readonly IPattern pattern;

        public Many(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            IMatch matchingUsed = new Match(text, true);
            while (matchingUsed.Success())
            {
                matchingUsed = pattern.Match(matchingUsed.RemainingText());

                if (matchingUsed.Success())
                {
                    matchingUsed = pattern.Match(matchingUsed.RemainingText());
                }
            }

            return new Match(matchingUsed.RemainingText(), true);
        }
    }
}
