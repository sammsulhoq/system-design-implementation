using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConsistentHashingCache
{
    internal class ConsistentHashRing<T>
    {
        private readonly SortedDictionary<int, T> _circle = new();
        private readonly int _replicas;

        public ConsistentHashRing(int capacity = 100)
        {
            _replicas = capacity;
        }

        public void AddNode(T node)
        {
            for (int i = 0; i < _replicas; i++) {
                int hash = GetHash(node.ToString() + i);
                _circle[hash] = node;
            }
        }

        public void RemoveNode(T node)
        {
            for (int i = 0; i < _replicas; ++i)
            {
                int hash = GetHash(node.ToString() + i);
                _circle.Remove(hash);
            }
        }

        public T GetNode(string key)
        {
            if (_circle.Count == 0)
            {
                throw new InvalidOperationException("Hashring is empty!");
            }

            int hash = GetHash(key);
            foreach (var h in _circle.Keys)
            {
                if (hash <= h) 
                    return _circle[h];
            }

            return _circle.First().Value;
        }

        private int GetHash(string input) => input.GetHashCode();
    }
}
