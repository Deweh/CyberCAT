using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace CyberCAT.Core.Classes.Mapping
{
    public class TypeCache
    {
        private List<TypeCacheEntry> _tmpList;
        private TypeCacheEntry[] _cache;
        private ConcurrentDictionary<string, Type> _typeCache;
        private ConcurrentDictionary<Type, string> _nameCache;

        public TypeCache()
        {
            _tmpList = new List<TypeCacheEntry>();
            _typeCache = new ConcurrentDictionary<string, Type>();
            _nameCache = new ConcurrentDictionary<Type, string>();
        }

        public void Add(string name, Type type)
        {
            _tmpList.Add(new TypeCacheEntry(name, type));
        }

        public void FinalizeCache()
        {
            _cache = _tmpList.ToArray();
            _tmpList = null;

            for (var i = 0; i < _cache.Length; i++)
            {
                _typeCache.TryAdd(_cache[i].Name, _cache[i].Type);
                _nameCache.TryAdd(_cache[i].Type, _cache[i].Name);
            }
        }

        public int Length => _cache.Length;

        public TypeCacheEntry this[int index]
        {
            get => _cache[index];
            set => _cache[index] = value;
        }

        public string GetKey(Type value)
        {
            if (_nameCache.TryGetValue(value, out string cached))
            {
                return cached;
            }

            return null;
        }

        public Type GetValue(string key)
        {
            if (_typeCache.TryGetValue(key, out Type cached))
            {
                return cached;
            }

            return null;
        }

        public class TypeCacheEntry
        {
            public string Name;
            public Type Type;

            public TypeCacheEntry(string name, Type type)
            {
                Name = name;
                Type = type;
            }
        }
    }
}