using System.Collections;

namespace DataStructuresLib
{
    public class ListLib<T> : IEnumerator, IEnumerable
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

        public void RemoveAt(uint position)
        {
            if (!IsAValidPosition(position)) throw new ArgumentOutOfRangeException("Invalid index.");

            for (uint i = position; i < _count - 1; i++)
            {
                tempList[i] = tempList[i+1];
            }
            _count--;
        }

        public bool Remove(T item)
        {
            for(uint i = 0; i < _count; i++){
                if(item.Equals(tempList[i]))
                {
                    RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public void RemoveRange(uint index, uint count)
        {
            if((!IsAValidPosition(index)) & (!IsAValidAmount(count))) throw new ArgumentOutOfRangeException("Invalid index");

            uint rangeSum = index+count;

            for(uint i = index; i < rangeSum; rangeSum--)
            {
                RemoveAt(i);
            }
        }

        public void Reverse()
        {
            T[] copyTempList = new T[_count];

            int first, last;

            for(first = 0, last = _count-1; first < _count || last >= 0; first++, last--)
            {
                copyTempList[first] = tempList[last];
            }
            tempList = copyTempList;
        }

        private bool IsAValidAmount(uint count)
        {
            return count > 1 && count <=_count;
        }

        private bool IsAValidPosition(uint position)
        {
           return position >= 0 && position <_count;
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