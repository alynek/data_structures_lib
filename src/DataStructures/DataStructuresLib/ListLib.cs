namespace DataStructuresLib
{
    public class ListLib<T> where T : class
    {
        private T[] tempList = new T[1];
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
    }
}