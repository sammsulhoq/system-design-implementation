using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsistentHashingCache
{
    internal class CacheNode
    {
        private readonly Dictionary<string, string> _store = new();
        public string Name { get; }

        public CacheNode(string name) => Name = name;

        public void Put(string key, string value) => _store[key] = value;
        public string? Get(string key) => _store.TryGetValue(key, out var value) ? value : null;

        public void Delete(string key) => _store.Remove(key);
    }
}
