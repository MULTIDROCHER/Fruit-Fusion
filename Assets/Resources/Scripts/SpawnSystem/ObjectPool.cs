using System.Collections.Generic;
using UnityEngine;

namespace FoodFusion
{
    public class ObjectPool : MonoBehaviour
    {
        private readonly Queue<Food> _pool = new Queue<Food>();

        [SerializeField] private Food _prefab;
        [SerializeField] private int _poolSize;

        private void Awake()
        {
            for (int i = 0; i < _poolSize; i++)
            {
                var food = CreateNew();
                Return(food);
            }
        }

        public Food GetObject()
        {
            return _pool.Count > 0 ? GetExisting() : CreateNew();
        }

        public void Return(Food obj)
        {
            obj.gameObject.SetActive(false);
            _pool.Enqueue(obj);
        }

        private Food CreateNew()
        {
            return Instantiate(_prefab, transform);
        }

        private Food GetExisting()
        {
            var food = _pool.Dequeue();
            food.gameObject.SetActive(true);

            return food;
        }
    }
}