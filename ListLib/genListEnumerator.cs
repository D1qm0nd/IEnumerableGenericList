using System.Collections;

namespace ListLib
{
#nullable disable
    public class genListEnumerator<T> : IEnumerator
    {

        GenList<T> list;
        int position = 1;

        public T Current
        {
            get { 
                try 
                {
                    return list.Item(position);
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current 
        { 
            get 
            { 
                return Current; 
            } 
        }
        

        public bool MoveNext()
        {
            return (++position < list.Count);
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public genListEnumerator(GenList<T> items)
        {
            list = items;
        }
    }
}
