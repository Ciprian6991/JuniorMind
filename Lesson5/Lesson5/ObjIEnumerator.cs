using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lesson5
{
    public class ObjIEnumerator : IEnumerator
    {
        private readonly object[] objArray;
        private int position = -1;

        public ObjIEnumerator(object[] objectArray)
        {
            this.objArray = objectArray;
        }

        public object Current => objArray[position];

        public bool MoveNext()
        {
            position++;
            return position < objArray.Length;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
