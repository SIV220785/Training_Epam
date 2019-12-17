using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomQueue.DLL
{
    /// <summary>
    /// Generic class of queue.
    /// </summary>
    /// <typeparam name="T">The generic type parameter.</typeparam>
    public class Queue<T>
    {
        private T[] array;
        private int head;
        private int tail;

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class.
        /// Constructor for queue instance that accepts capacity.
        /// </summary>
        /// <param name="capacity"> Capacity array.</param>
        public Queue(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            this.array = new T[capacity];
            this.head = 0;
            this.tail = 0;
            this.Count = 0;
        }

        /// <summary>
        /// Gets number of queue elements.
        /// </summary>
        /// <value>
        /// Number of queue elements.
        /// </value>
        public int Count { get; private set; }

        /// <summary>
        /// Method for adding element to the end of queue.
        /// </summary>
        /// <param name="item">Element to add.</param>
        public void Enqueue(T item)
        {
            this.array[this.tail] = item;
            this.tail = (this.tail + 1) % this.array.Length;
            this.Count++;
        }

        /// <summary>
        /// Method for removing and returning the object at the beginning of the queue.
        /// </summary>
        /// <returns>The object that is removed from the beginning of the queue.</returns>
        public T Dequeue()
        {
            T result = this.array[this.head];
            this.array[this.head] = default;
            this.head = (this.head + 1) % this.array.Length;
            this.Count--;
            return result;
        }

        /// <summary>
        /// Method for returning the object at the beginning of the queue.
        /// </summary>
        /// <returns> The object at the beginning of the queue.</returns>
        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return this.array[this.head];
        }

        /// <summary>
        /// Returns an enumerator that iterates through the queue.
        /// </summary>
        /// <returns>Instance of structure for iterating.</returns>
        public QueueIterator GetEnumerator()
        {
            return new QueueIterator(this);
        }

        /// <summary>
        /// Struct that contains methods for supporting <see langword="foreach"/> operator.
        /// </summary>
        public struct QueueIterator
        {
            private readonly Queue<T> queue;
            private int currentIndex;

            /// <summary>
            /// Initializes a new instance of the <see cref="QueueIterator"/> struct.
            /// </summary>
            /// <param name="collection"> Queue.</param>
            public QueueIterator(Queue<T> collection)
            {
                this.currentIndex = -1;
                this.queue = collection;
            }

            /// <summary>
            /// Gets the element in the queue at the current position of the enumerator.
            /// </summary>
            /// <value>
            /// The element in the queue at the current position of the enumerator.
            /// </value>
            public T Current
            {
                get
                {
                    if (this.currentIndex == -1 || this.currentIndex == this.queue.Count)
                    {
                        throw new InvalidOperationException();
                    }

                    return this.queue.array[this.currentIndex];
                }
            }

            /// <summary>
            /// Sets the enumerator to its initial position, which is before the first element in the collection.
            /// </summary>
            public void Reset() => this.currentIndex = -1;

            /// <summary>
            /// Advances the enumerator to the next element of the queue.
            /// </summary>
            /// <returns>True if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the queue.</returns>
            public bool MoveNext()
            {
                return ++this.currentIndex < this.queue.Count;
            }
        }
    }
}
