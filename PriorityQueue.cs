using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djikstra
{
    public class PriorityQueue<T> where T : IComparable
    {
        private List<T> data;

        public PriorityQueue()
        {
            this.data = new List<T>();
        }

        public PriorityQueue(List<T> data)
        {
            this.data = new List<T>(data);
            BuildPrioriyQueue();
        }

        // Build the priority queue
        private void BuildPrioriyQueue()
        {
            for (int i = ((data.Count - 1) / 2); i >= 0; i--)
            {
                MinHeapify(data, i);
            }
        }

        private void MinHeapify(List<T> data, int i)
        {
            int leftNodeIndex = (2 * i) + 1;
            int rightNodeIndex = (2 * i) + 2;

            T smallerNode = default(T);
            int smallerNodeIndex = 0;

            if ((leftNodeIndex < data.Count) && (rightNodeIndex < data.Count))
            {
                if (data[leftNodeIndex].CompareTo(data[rightNodeIndex]) == -1)
                {
                    smallerNode = data[leftNodeIndex];
                    smallerNodeIndex = leftNodeIndex;
                }
                else if (data[leftNodeIndex].CompareTo(data[rightNodeIndex]) == 1)
                {
                    smallerNode = data[rightNodeIndex];
                    smallerNodeIndex = rightNodeIndex;
                }

                if ((smallerNode != null) && (smallerNode.CompareTo(data[i]) == -1))
                {
                    // SwapNodeValues(smallerNode, data[i]);
                    SwapNodes(smallerNodeIndex, i);


                    MinHeapify(data, smallerNodeIndex);
                }
            }
            else if (leftNodeIndex < data.Count)
            {
                if (data[leftNodeIndex].CompareTo(data[i]) == -1)
                {
                    SwapNodeValues(data[leftNodeIndex], data[i]);
                }
            }
            else if (rightNodeIndex < data.Count)
            {
                throw new Exception("This min-heap is not contructed correctly");
            }
        }

        private void SwapNodes(int smallerNodeIndex, int i)
        {
            T item = data[smallerNodeIndex];
            data[smallerNodeIndex] = data[i];
            data[i] = item;
        }

        // This may not work
        private void SwapNodeValues(T Node1, T Node2)
        {
            T temp = Node1;
            Node1 = Node2;
            Node2 = temp;
        }

        public void Enqueue(T item)
        {
            data.Add(item);

            int indexAddedItem = data.Count - 1;

            int indexParentAddedItem = (indexAddedItem - 1) / 2;

            while (indexParentAddedItem >= 0 && indexParentAddedItem < data.Count)
            {
                // If parent is bigger than child then swap else stop
                if (data[indexParentAddedItem].CompareTo(data[indexAddedItem]) == 1)
                {
                    SwapNodeValues(data[indexParentAddedItem], data[indexAddedItem]);
                }
                else
                {
                    break;
                }
            }
        }

        public T Dequeue()
        {
            T topItem = default(T);

            if (!Empty())
            {
                topItem = data[0];
                data.Remove(topItem);
            }

            if (!Empty())
            {
                T lastItem = data.Last();
                data.Remove(lastItem);
                data.Insert(0, lastItem);
            }
    

            BuildPrioriyQueue();

            return topItem;
        }

        public T Peek()
        {
            T frontItem = data[0];
            return frontItem;
        }

        public bool Empty()
        {
            return (data.Count == 0);
        }

        public bool Contains(T item)
        {
            return data.Contains(item);
        }
    }
}
