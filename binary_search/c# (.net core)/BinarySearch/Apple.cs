using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearch
{
    public class Apple : IComparable<Apple>
    {
        public double Weight { get; set; }
        public string Color { get; set; }

        public int CompareTo(Apple other)
        {
            if (Weight > other.Weight)
                return 1;

            if (Weight < other.Weight)
                return -1;

            return 0;
        }
    }
}
