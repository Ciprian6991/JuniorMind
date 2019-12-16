using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson4Abstracting
{
    public class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {
            var onenine = new Range('1', '9');
            var digit = new Choice(
                                    new Character('0'),
                                    onenine);

            var digits = new OneOrMore(digit);

            var integer = new Choice(
                                        new Sequence(new Character('-'), onenine, digits),
                                        new Sequence(new Character('-'), digit),
                                        new Sequence(onenine, digits),
                                        digit);

            var fraction = new Optional(
                                        new Choice(
                                                new Sequence(new Character('.'), digits)));

            var sign = new Optional(
                                     new Choice(
                                                new Character('+'),
                                                new Character('-')));

            var exponent = new Optional(
                                        new Choice(
                                                    new Sequence(new Character('E'), sign, digits),
                                                    new Sequence(new Character('e'), sign, digits)));

            pattern = new Sequence(integer, fraction, exponent);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
