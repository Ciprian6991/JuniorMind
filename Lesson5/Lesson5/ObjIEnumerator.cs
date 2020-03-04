using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lesson5
{
    public class ObjIEnumerator : IEnumerator
    {
        private readonly ObjectArrayCollection objArray = new ObjectArrayCollection();
        private int position = -1;

        public ObjIEnumerator(object[] array)
        {
            this.objArray.Add(array);
        }

        public object Current => objArray[position];

        public bool MoveNext()
        {
            position++;
            return position < objArray.Count;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
