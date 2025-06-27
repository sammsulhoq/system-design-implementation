// See https://aka.ms/new-console-template for more information
using ConsistentHashingCache;

var nodes = new List<CacheNode>()
{
    new("Node-A"),
    new("Node-B"),
    new("Node-C")
};

var cache = new DistributedCache(nodes);
cache.Put("apple", "red");
cache.Put("banana", "yellow");
cache.Put("grape", "purple");

Console.WriteLine(cache.Get("banana"));
cache.Delete("banana");
Console.WriteLine(cache.Get("banana"));
