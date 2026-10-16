using System.Runtime.CompilerServices;

namespace DataStructures
{
    public class EyadStackArray<T>
    {

        public int Capacity { private set; get; }

        public int Top { private set; get; }

        private T[] Stack;


        public EyadStackArray(int Capacity = 4)
        {
            if (Capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(Capacity),
                    Capacity,
                    "Capacity must be greater than zero."
                );
            }

            this.Capacity = Capacity;
            this.Stack = new T[Capacity];
            this.Top = -1;
        }
        public T Peek()
        {
            if (Top == -1)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return Stack[Top];
        }
        public void Pop()
        {
            if (Top == -1)
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            Stack[Top] = default(T);
            Top--;
        }
        public void Push(T Value)
        {
            if (Top == Capacity - 1)
            {
                throw new InvalidOperationException("Stack is full.");
            }
            Top++;
            Stack[Top] = Value;

        }
        public void Print()
        {
            int width = 0;

            for (int i = 0; i <= Top; i++)
            {
                int length = Stack[i]?.ToString()?.Length ?? 4;
                width = Math.Max(width, length);
            }

            width += 2;
            //to print it in well padded way we get the tallest element to pad upon it's width
            for (int i = Top; i >= 0; i--) // creative printing like the visuals online
            {
                string value = Stack[i]?.ToString() ?? "null";

                Console.WriteLine($"|{value.PadLeft(width - 1).PadRight(width)}|");
            }

            Console.WriteLine(new string('-', width + 2));

        }

    }
}
