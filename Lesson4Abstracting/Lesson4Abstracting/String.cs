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
            var quatation_mark = (char)uint.Parse("022", System.Globalization.NumberStyles.AllowHexSpecifier);
            var finalHex = (char)uint.Parse("10FFFF", System.Globalization.NumberStyles.AllowHexSpecifier);

            var onenine = new Range('1', '9');

            var digit = new Choice(
                                    new Character('0'),
                                    onenine);

            var hex = new Choice(
                                 digit,
                                 new Range('A', 'F'),
                                 new Range('a', 'f'));

            var escape = new Choice(
                new Any("bfnrt\\\"/"),
                new Sequence(new Character('u'), hex, hex, hex, hex));

            var character = new Choice(
                    new Range(space, (char)(quatation_mark - 1)),
                    new Range((char)(quatation_mark + 1), (char)(reverse_solidus - 1)),
                    new Range((char)(reverse_solidus + 1), finalHex),
                    new Sequence(new Any("\\"), escape));

            var characters = new Many(character);

            pattern = new Sequence(new Character('\"'), characters, new Character('\"'));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
