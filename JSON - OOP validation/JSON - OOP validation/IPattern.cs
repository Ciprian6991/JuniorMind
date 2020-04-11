using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson4Abstracting
{
    public interface IPattern
    {
        IMatch Match(string text);
    }
}
