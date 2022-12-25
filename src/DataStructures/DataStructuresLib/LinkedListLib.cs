
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

        //O(n) - linear search
        public bool Contains(T value)
        {
            Node<T> firstNode = this.First;

            while(firstNode != null){
                if(firstNode.Value.Equals(value)){
                    return true;
                }
                firstNode = firstNode.Next;
            }
            return false;
        }

        //O(n) - linear search
        public Node<T> Find(T value)
        {
            Node<T> firstNode = this.First;

            while(firstNode != null){
                if(firstNode.Value.Equals(value)){
                    return firstNode;
                }
                firstNode = firstNode.Next;
            }
            return null;
        }

        public void RemoveFirst()
        {
            if(!this.isAValidIndex(0)){
                throw new InvalidOperationException("The LinkedList<T> is empty.");
            }

            _first = _first.Next;
            _count --;

            if(_count == 0){
                _first = null;
            }
        }

        private bool isAValidIndex(int index)
        {
            return index >= 0 && index < _count;
        }
    }
}