namespace DataStructures.Queues
{
    public class SimpleQueue<T>
    {
        private T[] queue;

        int Capacity;
        int front;
        int rear;

        public bool IsEmpty
        {
            get
            {
                return (front > rear) || (front == -1 && rear == -1);
            }
        }

        public void CheckEmptyErrorIf()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Cannot dequeue from an empty queue.");
            }
        }

        public SimpleQueue(int Capacity = 4)
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
            this.queue = new T[Capacity];
            front = rear = -1;

        }


        public void Enqueue(T Value)
        {
            bool firstTime = front == -1 && rear == -1;
            bool restTimes = front <= rear && rear != Capacity - 1;
            bool hasSpace = firstTime || restTimes || (front == rear + 1);

            if (!hasSpace)
            {
                throw new InvalidOperationException("Queue is full.");
      
            }

            if (firstTime)
            {
                queue[++front] = Value;
                rear++;
                return;
            }

            queue[++rear] = Value;
        }

        public void Dequeue()
        {
            CheckEmptyErrorIf();

            queue[front++] = default(T);

            if (front == Capacity)
            {
                front = -1;
                rear = -1;
            }
        }

        public T Peek()
        {
            CheckEmptyErrorIf();


            return queue[front];
        }

        public void Display()
        {
            


            Console.Write("Queue elements: ");


            Console.Write($"[");

            for (int i = rear; i <= front; i--)
            {
                if (i == front)
                    Console.Write($"{queue[i]}");
                else
                    Console.Write($"{queue[i]},");

            }

            Console.Write($"]");
        }
    }
}
