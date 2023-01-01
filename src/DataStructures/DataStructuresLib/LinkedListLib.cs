
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

        public void RemoveLast()
        {
            if(!this.isAValidIndex(0)){
                throw new InvalidOperationException("The LinkedList<T> is empty.");
            }

            if(_count == 1){
                RemoveFirst();
                return;
            }

            else{
                Node<T> prevNode = _first;
                Node<T> newNode = prevNode.Next;

                while(newNode.Next is not null)
                {
                    prevNode = prevNode.Next;
                    newNode = newNode.Next;
                }
                prevNode.Next = null;
                _last = prevNode;
                _count --;
            }
        }

        //O(n) - linear search
        public bool Remove(T value)
        {
            if(_count == 0) return false;

            Node<T> currentNode = _first;
            Node<T> prevNode = _first;
            
            (bool wasFound, int index) = findItem(currentNode, value);
            bool needToRemove = index > 0 & index < _count-1;

            if(wasFound && needToRemove)
            {
                for(int i = 0; i < index-1; ++i)
                {
                    prevNode = prevNode.Next;
                }

                Node<T> node = prevNode.Next; //The node i want to delete
                Node<T> nextNode = node.Next; // The next pointer of the node i want to delete
                prevNode.Next = nextNode; //Set the next of previous node with the next node
                _count--;

                return true;
            }
            return wasFound;            
        }

        public void Clear()
        {
            if (_count == 0) return;

            Node<T> firstNode = _first;
            Node<T> nextNode = firstNode.Next;

            //Removing pointers
            while(nextNode is not null)
            {
                Node<T> tempNode = firstNode;
                firstNode = firstNode.Next;
                tempNode = null;
                nextNode = nextNode.Next ?? null;
                _count--;
            }

            firstNode = null;
            _first= null;
            _last = null;
            _count--;
        }

        private (bool, int) findItem(Node<T> currentNode, T value)
        {
            int index = 0;

            for(int i = 0; i < _count; i++)
            {
                if(currentNode.Value.Equals(value))
                {
                    index = i;

                    if(index == 0)
                    {
                        RemoveFirst();
                        return (true, index);
                    }
                    else if(index == _count-1)
                    {
                        RemoveLast();
                        return (true, index);
                    }
                    else
                    {
                        return (true, index);
                    }
                }
                currentNode = currentNode.Next;
            }
            return (false, index);
        }

        private bool isAValidIndex(int index)
        {
            return index >= 0 && index < _count;
        }
    }
}