namespace DataStructures.Queues
{
    public class CircularQueue<T>
    {
        private T[] queue;

        int Capacity;
        int front;
        int rear;

        public bool IsEmpty
        {
            get
            {
                return (front == -1 && rear == -1);
            }
        }
        public bool IsFull
        {
            get
            {
                return (front == 0 && rear == Capacity - 1) || (front == rear + 1);
            }
        }
        public void CheckEmptyErrorIf()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Cannot dequeue from an empty queue.");
            }
        }

        public CircularQueue(int Capacity = 4)
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
            bool full = (front == 0 && rear == Capacity - 1) || (front == rear + 1);

            if (full)
            {
                throw new InvalidOperationException("Queue is full.");

            }

            if (firstTime)
            {
                front = rear = 0;
                queue[front] = Value;
                return;
            }
            if (rear == Capacity - 1)
            {
                rear = -1;
            }
            queue[++rear] = Value;



        }

        public void Dequeue()
        {
            CheckEmptyErrorIf();

            if (rear == front && front != -1 && rear != -1)
            {
                queue[front] = default(T);
                front = -1;
                rear = -1;
            }
            else
            {
                queue[front++] = default(T);
            }

            if (front == Capacity)
            {
                front = 0;
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
            if (front <= rear)
            {
                for (int i = front; i <= rear; i++)
                {
                    if (i == rear)
                        Console.Write($"{queue[i]}");
                    else
                        Console.Write($"{queue[i]},");

                }
            }
            else
            {

                for (int i = front; i < Capacity; i++)
                {
                    if (i == Capacity - 1)
                        Console.Write($"{queue[i]}");
                    else
                        Console.Write($"{queue[i]},");

                }
                for (int i = 0; i <= rear; i++)
                {
                    if (i == 0)
                    {
                        Console.Write(",");
                    }
                    if (i == rear)
                        Console.Write($"{queue[i]}");
                    else
                        Console.Write($"{queue[i]},");

                }
            }

            Console.Write($"]");
        }
    }
}
