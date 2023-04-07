using System.Collections;

namespace ListLib
{
    public class GenListItem<T> : IEnumerable<T>
    {
        #nullable disable
        public GenListItem<T> previus;

        public T _item = default(T);

        public GenListItem<T> next;

        public GenListItem(T item)
        {
            previus = null;
            _item = item;
            next = null;
        }

        public GenListItem(GenListItem<T> prev, T item) 
        {
            previus = prev;
            _item = item;
            next = null;
        }

        public GenListItem<T> Add(T item)
        {
            GenListItem<T> sup = this;
            if (sup != null)
            { 
                while (sup.next != null)
                {
                    sup = sup.next;
                }
                sup.next = (new GenListItem<T>(sup, item));
            }
            return sup.next;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}
