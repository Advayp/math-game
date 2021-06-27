using System;
using System.Collections.Generic;
using UnityEngine;

namespace Discovery.Minigames.CardGame
{
    public abstract class RuntimeSet<T> : ScriptableObject
    {
        private readonly List<T> _items = new List<T>();

        public List<T> Items => _items;
        
        public void Add(T item)
        {
            if (!_items.Contains(item)) _items.Add(item);
        }

        public void Remove(T item)
        {
            if (_items.Contains(item)) _items.Remove(item);
        }

        public void ForEach(Action<T> action)
        {
            foreach (var item in _items)
            {
                action(item);
            }
        }
    }
}