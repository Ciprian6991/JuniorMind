using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Lesson4Abstracting
{
    public class String
    {
        private readonly IPattern pattern;

        public String()
        {
            var space = (char)uint.Parse("0020", System.Globalization.NumberStyles.AllowHexSpecifier);
            var reverse_solidus = (char)uint.Parse("005C", System.Globalization.NumberStyles.AllowHexSpecifier);
            var quatation_mark = (char)uint.Parse("0222", System.Globalization.NumberStyles.AllowHexSpecifier);
            var finalHex = (char)uint.Parse("10FFFF", System.Globalization.NumberStyles.AllowHexSpecifier);

            var character = new Choice(
                    new Range(space, (char)(quatation_mark - 1)),
                    new Range((char)(quatation_mark + 1), (char)(reverse_solidus - 1)),
                    new Range((char)(reverse_solidus + 1), finalHex));

            var characters = new Many(character);

            pattern = new Sequence(characters);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
