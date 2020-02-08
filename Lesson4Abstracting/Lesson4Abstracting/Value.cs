﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson4Abstracting
{
    public class Value : IPattern
    {
        private readonly IPattern pattern;

        public Value()
        {
            pattern = new Choice(
                                new String(),
                                new Number(),
                                new Text("true"),
                                new Text("false"),
                                new Text("null"));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
