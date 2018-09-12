using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Heap
{
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
