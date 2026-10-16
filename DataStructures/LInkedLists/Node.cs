namespace DataStructures
{
    public class Node<T>
    {
        public T value;

        public Node<T> previous;
        public Node<T> next;

        public Node(T value, Node<T> previous = null, Node<T> next = null)
        {
            this.value = value;
            this.previous = previous;
            this.next = next;
        }
    }
}
