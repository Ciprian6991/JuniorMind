using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson4Abstracting
{
    public class List : IPattern
    {
        private readonly IPattern pattern;

        public List(IPattern element, IPattern separator)
        {
            this.pattern = new Sequence(element, separator, element, separator, element);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
