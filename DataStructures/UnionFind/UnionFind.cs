using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.UnionFind
{
    // https://algs4.cs.princeton.edu/15uf/WeightedQuickUnionUF.java.html

    public class UnionFind
    {
        private int[] _parent;
        private int[] _size;

        public int Count { get; private set; }

        public UnionFind(int elementsCount)
        {
            Count = elementsCount;
            _parent = new int[elementsCount];
            _size = new int[elementsCount];
            for (int i = 0; i < elementsCount; i++)
            {
                _parent[i] = i;
                _size[i] = 1;
            }
        }

        public int Find(int element)
        {
            if (element == _parent[element]) return element;

            return _parent[element] = Find(_parent[element]);
        }

        public void Union(int first, int second)
        {
            int parentFirst = Find(first);
            int parentSecond = Find(second);

            if (parentFirst == parentSecond) return;

            if (_size[parentFirst] <= _size[parentSecond])
            {
                _parent[parentFirst] = parentSecond;
                _size[parentSecond] += _size[parentFirst];
            }
            else
            {
                _parent[parentSecond] = parentFirst;
                _size[parentFirst] += _size[parentSecond];
            }

            Count--;
        }

        public bool Connected(int first, int second)
        {
            return Find(first) == Find(second);
        }
    }
}
