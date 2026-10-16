
namespace EyadLinkedList
{
    public class EyadLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int _Length;

        public bool IsEmpty => head == null && tail == null;

        public int Length
        {
            get
            {
                return _Length;
            }
        }

        // Last valid index; -1 when the list is empty.
        private int index
        {
            get
            {
                return _Length - 1;
            }
        }

        public T this[int index]
        {
            get
            {
                return FindByIndex(index).value;
            }
            set
            {
                ReplaceAt(value, index);
            }
        }

        public EyadLinkedList()
        {
            _Length = 0;
            head = null;
            tail = null;
        }

        public void DeleteFromBegining()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("List is empty.");
            }

            head = head.next;
            _Length--;

            if (_Length == 0)
            {
                tail = head = null;
            }
            else
            {
                head.previous = null;
            }
        }

        public void DeleteFromEnd()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("List is empty.");
            }

            tail = tail.previous;
            _Length--;

            if (_Length == 0)
            {
                tail = head = null;
            }
            else
            {
                tail.next = null;
            }
        }

        public void insertAtBegining(T value)
        {
            if (IsEmpty)
            {
                InsertAtEnd(value);
            }
            else
            {
                var newNode = new Node<T>(value);
                newNode.next = head;
                head.previous = newNode;
                head = newNode;
                _Length++;
            }
        }

        public void InsertAtEnd(T value)
        {
            var newNode = new Node<T>(value);

            if (head is null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.next = newNode;
                newNode.previous = tail;
                tail = newNode;
            }

            _Length++;
        }

        public void PrintList()
        {
            Console.Write("[");

            var node = head;
            while (node != null)
            {
                if (node.next != null)
                {
                    Console.Write($"{node.value},");
                }
                else
                {
                    Console.Write($"{node.value}");
                }

                node = node.next;
            }

            Console.WriteLine("]");
        }

        private Node<T> FindByIndex(int index)
        {
            if (index < 0 || index > this.index)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(index), "Index is out of range.");
            }

            var node = head;
            var start = 0;

            while (node != null && start <= index)
            {
                if (start == index)
                {
                    return node;
                }

                start++;
                node = node.next;
            }

            return null;
        }

        public void InsertAfter(T value, int index)
        {
            if (index < 0 || index > this.index)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(index), "Index is out of range.");
            }

            if (index == this.index)
            {
                InsertAtEnd(value);
                return;
            }

            var newNode = new Node<T>(value);
            var nodeToInsertAfter = FindByIndex(index);

            newNode.next = nodeToInsertAfter.next;
            newNode.previous = nodeToInsertAfter;
            nodeToInsertAfter.next.previous = newNode;
            nodeToInsertAfter.next = newNode;

            _Length++;
        }

        // Replaces the node at the specified index without changing Length.
        //need a look

        public void ReplaceAt(T value, int index)
        {
            var newNode = new Node<T>(value);

            if (index == 0 && this.IsEmpty)
            {
                insertAtBegining(value);
                return;
            }
            if (index < 0 || index > this.index)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(index), "Index is out of range.");
            }

 
            var nodeToInsertAt = FindByIndex(index);

            newNode.next = nodeToInsertAt.next;
            newNode.previous = nodeToInsertAt.previous;

            if (nodeToInsertAt.previous is not null)
            {
                nodeToInsertAt.previous.next = newNode;
            }

            if (nodeToInsertAt.next is not null)
            {
                nodeToInsertAt.next.previous = newNode;
            }

            if (index == this.index)
            {
                tail = newNode;
            }
         
            else if (index == 0)
            {
                head = newNode;
            }

            nodeToInsertAt.next = null;
            nodeToInsertAt.previous = null;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > this.index)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(index), "Index is out of range.");
            }

            if (index == 0)
            {
                DeleteFromBegining();
                return;
            }

            if (index == this.index)
            {
                DeleteFromEnd();
                return;
            }

            var nodeToDelete = FindByIndex(index);
            nodeToDelete.previous.next = nodeToDelete.next;
            nodeToDelete.next.previous = nodeToDelete.previous;

            nodeToDelete.next = nodeToDelete.previous = null;
            _Length--;
        }
    }
}