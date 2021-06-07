using System;
using System.Collections.Generic;
using UnityEngine;

namespace MathGame.Minigames.FirstPersonShooter
{
    public abstract class RuntimeSet<T> : ScriptableObject
    {
        private readonly List<T> _items = new List<T>();

        public void Add(T t)
        {
            if (!_items.Contains(t))
                _items.Add(t);
        }

        public void Remove(T t)
        {
            if (_items.Contains(t)) _items.Remove(t);
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