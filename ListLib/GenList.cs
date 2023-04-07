using System;
using System.Collections;
using System.Reflection.Metadata;

namespace ListLib
{
    public class GenList<T> : IEnumerable<T>, IEnumerator<T>
    {
        #nullable disable
        private GenListItem<T> items;
        private GenListItem<T> end;
        private int position = 0;
        public int Count = 0;

        public T Current 
        {
            get 
            {
                return Item(position);
            }
        }

        object IEnumerator.Current => Current; 

        public GenList()
        {
        }

        public void Add(T item)
        {
            if (this.items == null)
            {
                this.items = new GenListItem<T>(item);
            }
            else
            end = this.items.Add(item);
            this.Count++;
        }

        private GenListItem<T> GetNode(int index)
        {
            unsafe
            {
                GenListItem<T> node = end;
                if (index > 0 && index < Count)
            {
                if (index >= Count / 2)
                {
                    GenListItem<T> sup = this.end;
                    for (int i = Count; i > index; i--)
                    {
                        sup = sup.previus;
                    }
                    node = sup;
                }
                else
                {
                    GenListItem<T> sup = this.items;
                    for (int i = 1; i < index; i++)
                    {
                        sup = sup.next;
                    }
                    node = sup;
                }
            }
            return node;
        }
        }
        public ref T Item(int index)
        {
            return ref GetNode(index)._item;
        }

        public void Remove(int index)
        {
            if (Count == 1)
            {
                items = null;
            }
            else if (index != Count && index > 1)
            {
                GenListItem<T> delNode = GetNode(index);
                GenListItem<T> prev = delNode.previus;
                GenListItem<T> next = delNode.next;
                prev.next = delNode.next;
                next.previus = delNode.previus;
                delNode.previus = null;
                delNode.next = null;
            }
            else if (index == Count)
            { 
            }
            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            return (position++ < Count);
        }

        public void Reset()
        {
            position = 0; 
        }

        public void Dispose()
        {
            Console.WriteLine($"foreach dispose");
        }
    }
}