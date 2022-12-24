namespace DataStructuresLib
{
    public class Node<T>
    {
        public Node<T> Next{get; set;}
        public T Value {get; set;}

        public Node(T value)
        {
            this.Value = value;
        }

        public Node(Node<T>  next, T value)
        {
            this.Next = next;
            this.Value = value;
        }
    }
}