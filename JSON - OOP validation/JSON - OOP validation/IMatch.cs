using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson4Abstracting
{
    public interface IMatch
    {
        bool Success();

        string RemainingText();
    }
}
