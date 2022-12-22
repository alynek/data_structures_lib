using System.Collections;

namespace DataStructuresLib
{
    public class ListLib<T> : IEnumerator, IEnumerable where T : class
    {
        private T[] tempList = new T[0];

        int positionToMoveNext = -1;

        private int _count { get; set; } = 0;
        public int Count { get { return _count; } }
        public T this[int Count]
        {
            get { return tempList[Count]; }
        }

        public void Add(T item)
        {
            GuaranteeSpace();
            tempList[_count] = item;
            _count += 1;
        }

        public void AddRange(ListLib<T>  collection)
        {
            if(collection is null) throw new ArgumentNullException("collection is null.");
            for(int i = 0; i < collection._count; i++)
            {
                Add(collection[i]);
            }
        }

        public void Insert(int index, T item)
        {
            GuaranteeSpace();

            if (!IsValidPosition(index))
            {
                throw new ArgumentException("ArgumentOutOfRangeException: Index must be within the bounds of the List.");
            }

            for (int i = _count - 1; i >= index; i--)
            {
                tempList[i + 1] = tempList[i];
            }

            tempList[index] = item;
            _count++;
        }

        public void Clear()
        {
            tempList = new T[1];
            _count = 0;
        }

        public bool Contains(T item)
        {
            foreach (var i in tempList)
            {
                if(i.Equals(item)) return true;
            }
            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if(item.Equals(tempList[i])) return i;
            }
            return -1;
        }

        public void RemoveAt(int position)
        {
            if (!(position >= 0 && position <_count)) throw new ArgumentOutOfRangeException("Invalid index.");

            for (int i = position; i < _count - 1; i++)
            {
                tempList[i] = tempList[i+1];
            }
            _count--;
        }

        private void GuaranteeSpace()
        {
            if (_count == tempList.Length)
            {
                T[] copyTempList = new T[tempList.Length + 1];

                for (int i = 0; i < tempList.Length; i++)
                {
                    copyTempList[i] = tempList[i];
                }
                tempList = copyTempList;
            }
        }

        private bool IsValidPosition(int position)
        {
            return position >= 0 && position <= _count;
        }

        #region Methods for IEnumerable, IEnumerator
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        public bool MoveNext()
        {
            positionToMoveNext++;
            return (positionToMoveNext < tempList.Length);
        }
        public void Reset()
        {
            positionToMoveNext = -1;
        }

        public object Current
        {
            get { return tempList[positionToMoveNext]; }
        }
        #endregion
    }
}