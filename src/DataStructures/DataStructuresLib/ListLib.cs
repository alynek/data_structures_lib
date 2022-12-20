using System.Text;

namespace DataStructuresLib
{
    public class ListLib<T> where T : class
    {
        private T[] tempList = new T[1];
        private int _count { get; set; } = 0;
        public int Count{ get{return _count;} }

        public void Add(T item)
        {
            GuaranteeSpace();
            tempList[_count] = item;
            _count += 1;
        }

        public string Print()
        {
            if(_count == 0)
            {
                return "";
            }

            StringBuilder builder = new StringBuilder();
            builder.Append("[");

            for(int i = 0; i < _count - 1; i++)
            {
                builder.Append(tempList[i]);
                builder.Append(", ");
            }
            
            builder.Append(tempList[_count - 1]);
            builder.Append("]");
            return builder.ToString();
        }

        private void GuaranteeSpace()
        {
            if(_count == tempList.Length)
            {
                T[] copyTempList = new T[tempList.Length + 1];

                for(int i = 0; i < tempList.Length; i++)
                {
                    copyTempList[i] = tempList[i];
                }
                tempList = copyTempList;
            }
        }
    }
}