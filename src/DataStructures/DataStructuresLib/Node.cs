namespace DataStructuresLib
{
    public class Node<T>
    {
        private Node<T> next{get; set;}
        private T _value {get; set;}
        public T Value{get{return _value;}}

        public Node(Node<T>  next, T value)
        {
            this.next = next;
            this._value = value;
        }
    }
}