using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.HashTable
{
    /// <summary>
    /// Separate Chaining hash table
    /// </summary>
    public class HashMap<TKey, TValue> : IEnumerable<TKey>
    {
        /// <summary>
        /// Initizl table size
        /// </summary>
        private const int INITIAL_SIZE = 4;
        /// <summary>
        /// Number of key value pairs
        /// </summary>
        private int _elementsCount;

        private LinkedList<HashMapKeyValue<TKey, TValue>>[] _chains;

        private class HashMapKeyValue<TKey, TValue>
        {
            public HashMapKeyValue(TKey key)
            {
                Key = key;
            }

            public HashMapKeyValue(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }

            public TKey Key { get; }
            public TValue Value { get; set; }

            public override bool Equals(object obj)
            {
                var value = obj as HashMapKeyValue<TKey, TValue>;
                return value != null && value.Key.Equals(Key);
            }
        }

        public HashMap() : this(INITIAL_SIZE) { }

        public HashMap(int chainsCount)
        {
            _chains = new LinkedList<HashMapKeyValue<TKey, TValue>>[chainsCount];
            for (int i = 0; i < chainsCount; i++)
                _chains[i] = new LinkedList<HashMapKeyValue<TKey, TValue>>();
        }

        /// <summary>
        /// hash value between 0 and chainsCount-1
        /// </summary>
        private int GetHash(TKey key)
        {
            // int - 32 bits
            // 0x7ffffff = 0111 1111 1111 1111 1111 1111 1111 1111
            return (key.GetHashCode() & 0x7ffffff) % _chains.Length; 
        }

        private void resize(int numberOfChains)
        {
            var temp = new HashMap<TKey, TValue>(numberOfChains);

            HashMapKeyValue<TKey, TValue> node;
            for (int i = 0; i < _chains.Length; i++)
            {
                node = _chains[i].First.Next.Value;
                while (node != null)
                {
                    temp.Put(node.Key, node.Value);
                }
            }

            _chains = temp._chains;
            _elementsCount = temp._elementsCount;
        }

        public void Put(TKey key, TValue value)
        {
            if (key == null) throw new ArgumentException("key can't be null");

            // double table size if average length of list >= 10
            if (_elementsCount >= 10 * _chains.Length)
                resize(2 * _chains.Length);

            var node = new HashMapKeyValue<TKey, TValue>(key, value);
            int i = GetHash(key); // get hash of key
            if (!_chains[i].Contains(node))
            {
                _chains[i].AddLast(node);
                _elementsCount++;
            }
            else
                _chains[i].Find(node).Value.Value = value;
        }

        public void Delete(TKey key)
        {
            if (key == null) throw new ArgumentException("key can't be null");

            // divide table size if average length of list >= 10
            if (_elementsCount >= INITIAL_SIZE && _elementsCount <= 2 * _chains.Length)
                resize(_chains.Length / 2);

            int i = GetHash(key);
            var node = new HashMapKeyValue<TKey, TValue>(key);
            if (_chains[i].Contains(node))
                _chains[i].Remove(node);
        }

        public IEnumerator<TKey> GetEnumerator()
        {
            for (int i = 0; i < _chains.Length; i++)
                foreach (var item in _chains[i])
                    yield return item.Key;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
