
namespace DataStructuresLib
{
    public class LinkedListLib<T>
    {
        private Node<T>  _first;
        public Node<T> First{get{return _first;}}

        private Node<T>  _last;
        public Node<T> Last{get{return _last;}}

        private int _count{ get; set; } = 0;
        public int Count{get{return _count;}}

        public LinkedListLib<T> AddFirst(T value)
        {
            Node<T>  newNode = new Node<T> (_first, value);

            _first = newNode;

            if(_count == 0) _last = newNode;

            _count++;

            return this;
        }

        public LinkedListLib<T> AddLast(T value)
        {
            if(_count == 0) return AddFirst(value);
            else
            {
                Node<T> newNode = new Node<T>(value);

                _last.Next = newNode;
                _last = newNode;

                _count++;

                return this;
            } 
        }
    }
}