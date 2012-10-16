using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace WebApplication1
{
    public struct EnumArraySegment<T>
    {
        ArraySegment<T> arraySegment;

        public EnumArraySegment(T[] array)
        {
            arraySegment = new ArraySegment<T>(array);
        }

        public EnumArraySegment(T[] array, int offset, int count)
        {
            arraySegment = new ArraySegment<T>(array, offset, count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = arraySegment.Offset; i < arraySegment.Offset + arraySegment.Count; i++)
            {
                yield return arraySegment.Array[i];
            }
        }
    }
}