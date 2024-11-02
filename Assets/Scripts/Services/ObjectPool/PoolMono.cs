using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Services.ObjectPool
{
    public class PoolMono<T> where T : MonoBehaviour //todo EcsPool есть в leoecs lite так что поменяй библеотеку с тандарта на лайт
    {
        private List<T> _pool;
        
        private readonly T _prefab;
        private readonly bool _autoExpand;

        public PoolMono(T prefab, int count, bool autoExpand)
        {
            _prefab = prefab;
            _autoExpand = autoExpand;
            
            CreatePool(count);
        }
        
        private void CreatePool(int count)
        {
            _pool = new List<T>();

            for (int i = 0; i < count; i++)
            {
                CreateObject();
            }
        }

        private T CreateObject(bool isActiveBeDefault = false)
        {
            var createdObject = Object.Instantiate(_prefab);
            createdObject.gameObject.SetActive(isActiveBeDefault);
            
            _pool.Add(createdObject);

            return createdObject;
        }

        public bool HasFreeElement(out T element)
        {
            foreach (var mono in _pool)
            {
                if (!mono.gameObject.activeInHierarchy)
                {
                    element = mono;
                    mono.gameObject.SetActive(true);

                    return true;
                }
            }

            element = null;
            return false;
        }

        public T GetFreeElement()
        {
            if (HasFreeElement(out var element)) return element;
            if (_autoExpand) return CreateObject(true);
            
            throw new Exception($"There is no free element in pool of type {typeof(T)}");
        }
    }
}