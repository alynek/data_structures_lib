
namespace DataStructuresLib
{
    public class LinkedListLib<T>
    {
        private Node<T>  _first;
        public Node<T>  First{get{return _first;}}
        private Node<T>  _last;

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
    }
}