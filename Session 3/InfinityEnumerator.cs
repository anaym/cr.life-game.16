using System.Collections;
using System.Collections.Generic;

namespace CR_Life.Session_3
{
    public class InfinityEnumrable<T> : IEnumerable<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            return new InfinityEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class InfinityEnumerator : IEnumerator<T>
        {
            public void Dispose()
            { }

            public bool MoveNext()
            {
                return true;
            }

            public void Reset()
            { }

            public T Current => default(T);

            object IEnumerator.Current => Current;
        }
    }
}