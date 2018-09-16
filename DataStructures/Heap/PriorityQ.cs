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
    // Priority Queue can be implemented using different data structures. Here max heap used
    public class PriorityQ
    {
        private List<int> arr;

        public PriorityQ() {
            arr = new List<int>();
            arr.Add(default(int)); // fill redundant cell
        }

        public bool empty()
        {
            return arr.Count <= 1;
        }

        // add in the end and then bubble up the element until heap rule is correct
        public void insert(int val) {
            arr.Add(val);
            int currInd = arr.Count - 1;

            while (currInd > 1 && arr[currInd] > arr[currInd / 2]) {
                swap(currInd, currInd / 2);
                currInd = currInd / 2;
            }
        }

        public int peek() {
            if (empty()) throw new InvalidOperationException("Queue is empty");
            return arr[1];
        }

        //removes elemetn with biggest priotiry
        // swaps left most element with the highest priority element
        // removes highest priority element and heapifies the element on the top
        public int pop() {
            if (empty()) throw new InvalidOperationException("Queue is empty");
            int lastIndex = arr.Count - 1;
            int result = arr[1];
            swap(lastIndex, 1);
            arr.RemoveAt(lastIndex);

            int currInd = 1;
            lastIndex = lastIndex - 1;

            for (int leftInd = 2 * currInd, rightInd = 2 * currInd + 1;
                leftInd <= lastIndex;
                leftInd = 2 * currInd, rightInd = 2 * currInd + 1)
            {
                int left = leftInd <= lastIndex ? arr[leftInd] : int.MinValue;
                int right = rightInd <= lastIndex ? arr[rightInd] : int.MinValue;

                if (arr[currInd] > left && arr[currInd] > right) break;
                if (left > right)
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

        private void swap(int i, int j) {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
