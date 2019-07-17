using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Heap
{
    // Note: if we start from 1 indexx of array
    // left element 2*i , rigth element 2*i+1, parent element i/2
    // If we start from 0: 
    // left element 2*i+1, right element 2*i+2, parent element (i - 1)/2
    public class MinHeap<T> where T : IComparable<T>
    {
        private List<T> arr;
        private Dictionary<T, int> elementToIndex;

        public MinHeap() {
            arr = new List<T>();
            elementToIndex = new Dictionary<T, int>();
        }

        public int length() {
            return arr.Count;
        }

        public void add(T element) {
            arr.Add(element);
            elementToIndex[element] = arr.Count - 1;

            // bubble up element if it is less than parent
            int i = arr.Count - 1;
            int parent = (i - 1) / 2;
            while (i > 0 && arr[i].CompareTo(arr[parent]) < 0)
            {
                swap(i, parent);
                i = parent;
                parent = (i - 1) / 2;
            }
        }

        public T pop() {
            T topNode = remove(0);
            heapify(0);
            return topNode;
        }

        public void remove(T element) {
            int index = getIndex(element);
            if (index < 0) return;
            remove(index);
            heapify(index);
        }

        public bool contains(T element) {
            return elementToIndex.ContainsKey(element);
        }

        public void heapify(int i)
        {
            if (i < 0) throw new ArgumentException("i");

            // drop down element if it is bigger than childs
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            for ( ;left<=arr.Count - 1; left = 2*i + 1, right = 2*i + 2)
            {
                int smallest = i;
                if (arr[left].CompareTo(arr[smallest]) < 0)
                    smallest = left;
                if(right < arr.Count - 1 && arr[right].CompareTo(arr[smallest]) < 0)
                    smallest = right;

                if (smallest == i)
                    break;

                swap(smallest, i);
                i = smallest;
            }
        }

        public int getIndex(T element)
        {
            if (!elementToIndex.ContainsKey(element))
                return -1;

            return elementToIndex[element];
        }

        private T remove(int index)
        {
            swap(index, arr.Count - 1);
            T nodeToRemove = arr[arr.Count - 1];
            arr.Remove(nodeToRemove);
            elementToIndex.Remove(nodeToRemove);
            return nodeToRemove;
        }

        private void swap(int i, int j)
        {
            T temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
            elementToIndex[arr[i]] = i;
            elementToIndex[arr[j]] = j;
        }
    }
}
