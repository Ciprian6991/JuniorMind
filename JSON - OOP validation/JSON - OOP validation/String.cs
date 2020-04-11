using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Lesson4Abstracting
{
    public class String : IPattern
    {
        private readonly IPattern pattern;

        public String()
        {
            var onenine = new Range('1', '9');

            var digit = new Range('0', '9');

            var hex = new Choice(
                                 digit,
                                 new Range('A', 'F'),
                                 new Range('a', 'f'));

            var escape = new Choice(
                new Any("bfnrt\"\\/"),
                new Sequence(new Character('u'), hex, hex, hex, hex));

            var character = new Choice(
                    new Range(' ', '\uffff', "\"\\"),
                    new Sequence(new Character('\\'), escape));

            var characters = new Many(character);

            pattern = new Sequence(new Character('\"'), characters, new Character('\"'));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
