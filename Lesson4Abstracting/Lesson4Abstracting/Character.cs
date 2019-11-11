﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson4Abstracting
{
    public class Character
    {
        readonly char pattern;

        public Character(char pattern)
        {
            this.pattern = pattern;
        }

        public bool Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            return text[0] == pattern;
        }
    }
}