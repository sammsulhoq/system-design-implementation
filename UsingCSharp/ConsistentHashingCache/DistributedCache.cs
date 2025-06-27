using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsistentHashingCache
{
    internal class DistributedCache
    {
        private readonly ConsistentHashRing<CacheNode> _hashRing;

        public DistributedCache(List<CacheNode> nodes)
        {
            _hashRing = new ConsistentHashRing<CacheNode>();
            foreach (var node in nodes)
            {
                _hashRing.AddNode(node);
            }
        }

        public void Put(string key, string value)
        {
            var node = _hashRing.GetNode(key);
            node.Put(key, value);
            Console.WriteLine($"PUT '{key}' on {node.Name}");
        }

        public string? Get(string key)
        {
            var node = _hashRing.GetNode(key);
            Console.WriteLine($"GET '{key}' on {node.Name}");
            return node.Get(key);
        }

        public void Delete(string key)
        {
            var node = _hashRing?.GetNode(key);
            node.Delete(key);
            Console.WriteLine($"DELETE '{key}' on {node.Name}");
        }
    }
}
