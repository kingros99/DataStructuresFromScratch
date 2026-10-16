using EyadLinkedList;

namespace StackLinkedList
{
    public class EyadStackLinkedList<T>
    {
        public int Capacity { private set; get; }

        private bool hasSize;

        private EyadLinkedList<T> Stack;

        public EyadStackLinkedList(int Capacity = -1)
        {
            if (Capacity <= 0 && Capacity != -1)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(Capacity),
                    Capacity,
                    "Capacity must be greater than zero."
                );
            }

            this.Capacity = Capacity;
            hasSize = Capacity != -1;

            Stack = new EyadLinkedList<T>();
        }

        public T Peek()
        {
            if (Stack.IsEmpty)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return Stack[0];
        }

        public void Pop()
        {
            if (Stack.IsEmpty)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            Stack.RemoveAt(0);
        }

        public void Push(T Value)
        {
            if (hasSize && Stack.Length >= Capacity)
            {
                throw new InvalidOperationException("Stack is full.");
            }

            Stack.insertAtBegining(Value);
        }

        public void Print()
        {
            int width = 0;

            for (int i = 0; i <= Stack.Length; i++)
            {
                int length = Stack[i]?.ToString()?.Length ?? 4;
                width = Math.Max(width, length);
            }

            width += 2;

            // To print it in a well-padded way, we get the tallest element
            // to determine the width.
            for (int i = Stack.Length; i >= 0; i--) // Creative printing like the visuals online.
            {
                string value = Stack[i]?.ToString() ?? "null";

                Console.WriteLine($"|{value.PadLeft(width - 1).PadRight(width)}|");
            }

            Console.WriteLine(new string('-', width + 2));
        }
    }
}