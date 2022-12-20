using System.Text;

namespace DataStructuresLib
{
    public class ListLib<T> where T : class
    {
        private T[] tempList = new T[1];
        private int total { get; set; } = 0;

        public string Print()
        {
            if(total == 0)
            {
                return "";
            }

            StringBuilder builder = new StringBuilder();
            builder.Append("[");

            for(int i = 0; i < total - 1; i++)
            {
                builder.Append(tempList[i]);
                builder.Append(", ");
            }
            
            builder.Append(tempList[total - 1]);
            builder.Append("]");
            return builder.ToString();
        }
    }
}