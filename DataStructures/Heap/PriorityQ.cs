using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Heap
{
    //In computer science, a priority queue is an abstract data type which
    // is like a regular queue or stack data structure, but where 
    // additionally each element has a "priority" associated with it.
    // In a priority queue, an element with high priority is served before 
    // an element with low priority.
    // Priority Queue can be implemented using different data structures. 
    // Here min heap is used by default
    public class PriorityQ<T> where T : IComparable<T>
    {
        private List<T> _arr;
        private IComparer<T> _comparer;

        public PriorityQ()
        {
            _arr = new List<T>();
        }

        public PriorityQ(IComparer<T> comparer) : this()
        {
            _comparer = comparer;
        }

        public bool empty()
        {
            return _arr.Count <= 0;
        }

        // add in the end and then bubble up the element until heap rule is correct
        public void insert(T val)
        {
            _arr.Add(val);
            int currInd = _arr.Count - 1;

            // while current element less than parent
            while (currInd > 0 && compare(_arr[currInd], _arr[(currInd - 1) / 2]) < 0)
            {
                swap(currInd, currInd / 2);
                currInd = currInd / 2;
            }
        }

        public T peek()
        {
            if (empty()) throw new InvalidOperationException("Queue is empty");
            return _arr[0];
        }

        //removes elemetn with biggest priotiry
        // swaps left most element with the highest priority element
        // removes highest priority element and heapifies the element on the top
        public T pop()
        {
            if (empty()) throw new InvalidOperationException("Queue is empty");
            int lastIndex = _arr.Count - 1;
            T result = _arr[0];
            swap(lastIndex, 0);
            _arr.RemoveAt(lastIndex);

            int currInd = 0;
            lastIndex = lastIndex - 1;

            for (int leftInd = 2 * currInd + 1, rightInd = 2 * currInd + 2;
                leftInd <= lastIndex;
                leftInd = 2 * currInd + 1, rightInd = 2 * currInd + 2)
            {

                if (compare(_arr[currInd], _arr[leftInd]) < 0 &&
                    (rightInd > lastIndex || compare(_arr[currInd], _arr[rightInd]) < 0))
                    break;

                if (rightInd > lastIndex  || compare(_arr[leftInd], _arr[rightInd]) < 0)
                {
                    swap(leftInd, currInd);
                    currInd = leftInd;
                }
                else
                {
                    swap(rightInd, currInd);
                    currInd = rightInd;
                }
            }

            return result;
        }

        private int compare(T val1, T val2)
        {
            if (_comparer == null)
                return val1.CompareTo(val2);

            return _comparer.Compare(val1, val2);
        }

        private void swap(int i, int j)
        {
            T temp = _arr[i];
            _arr[i] = _arr[j];
            _arr[j] = temp;
        }
    }
}
