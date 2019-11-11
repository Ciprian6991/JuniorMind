using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson4Abstracting
{
    public class Choice
    {
        readonly Character character;
        readonly Range range;

        public Choice(Character character, Range range)
        {
            this.character = character;
            this.range = range;
        }

        public bool Match(string text)
        {
            return character.Match(text) || range.Match(text);
        }
    }
}
