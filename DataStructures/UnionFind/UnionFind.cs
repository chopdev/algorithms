using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class Point
    {
        public Point(int row, int col)
        {
            RowInd = row;
            ColInd = col;
        }

        public int RowInd { get; set; }
        public int ColInd { get; set; }
    }

    /// <summary>
    /// Union find is used to combine subsets together if two elements of this subsets 
    /// are related to each other by some specific mark
    /// 
    /// Then UnionFind could be used to quickly detect if two elements are related to each other
    /// </summary>
    public class UnionFind
    {
        private int[] _parents;
        private int[] _ranks;

        private int _rowLen;

        public UnionFind(int[][] field)
        {
            if (field == null || field.Length == 0)
                throw new ArgumentException("field is empty");

            int colLen = field.Length;
            _rowLen = field[0].Length;
            _parents = new int[_rowLen * colLen];
            _ranks = new int[_rowLen * colLen];
        }

        /// <summary>
        /// Finds parent index of current element
        /// </summary>
        public int Find(int index)
        {
            // if parent of current index is 0, there are no parent for current element
            if (_parents[index] == 0) return index; 
            // findind parent of current index parent and assign it 
            // in order to make tree lower
            _parents[index] = Find(_parents[index]);
            return _parents[index];
        }

        /// <summary>
        /// Unions two points in one subset
        /// </summary>
        /// <returns>
        /// False - if points are connected
        /// True - if points were not connected
        /// </returns>
        public bool Union(Point first, Point second)
        {
            int firstId = GetId(first.RowInd, first.ColInd);
            int secondId = GetId(second.RowInd, second.ColInd);

            int parentFirst = Find(firstId);
            int parentSecond = Find(secondId);
            if (parentFirst == parentSecond) return false;

            if (_ranks[parentFirst] >= _ranks[parentSecond])
            {
                _parents[parentSecond] = parentFirst;
                _ranks[parentFirst]++;
            }
            else
            {
                _parents[parentFirst] = parentSecond;
                _ranks[parentSecond]++;
            }
                
            return true;
        }

        public int GetId(int rowInd, int colInd)
        {
            return rowInd * _rowLen + colInd;
        }
    }
}
