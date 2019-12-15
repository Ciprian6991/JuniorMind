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
            pattern = new Sequence(
                                               new Optional(new Character('-')),
                                               new Choice(
                                                          new Sequence(
                                                              new Range('1', '9'),
                                                              new Many(new Range('0', '9')),
                                                              new Optional(new Sequence(new Character('.'), new Many(new Range('0', '9'))))),
                                                          new Sequence(
                                                                  new Text("0."), new Many(new Range('0', '9'))),
                                                          new Sequence(new Character('0'))),
                                               new Optional(new Sequence(
                                                                       new Choice(
                                                                                  new Character('e'),
                                                                                  new Character('E')),
                                                                       new Choice(
                                                                                  new Character('+'),
                                                                                  new Character('-')),
                                                                       new Optional(new Range('0', '9')))));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
