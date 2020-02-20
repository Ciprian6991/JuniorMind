using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson4Abstracting
{
    public class Value : IPattern
    {
        private readonly IPattern pattern;

        public Value()
        {
            var value = new Choice(
                                new String(),
                                new Number(),
                                new Text("true"),
                                new Text("false"),
                                new Text("null"));

            var ws = new Many(new Any("\u0020\u000A\u000A\u000D\u0009"));

            var element = new Sequence(ws, value, ws);
            var elements = new List(element, new Character(','));

            var array = new Choice(
                                    new Sequence(new Character('['), ws, new Character(']')),
                                    new Sequence(new Character('['), elements, new Character(']')));

            value.Add(array);

            pattern = value;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
