using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace FoodFusion
{
    public class ObjectPool : MonoBehaviour
    {
        private readonly Queue<FoodObject> _pool = new();

        [SerializeField] private FoodObject _fruitPrefab;
        [SerializeField] private int _poolSize = 50;

        private DataAssets _assets;

        [Inject]
        private void Construct(DataAssets assets)
        {
            _assets = assets;
            Initialize(_poolSize);
        }

        public FoodObject GetObject(FoodData data = null)
        {
            if (_pool.Count < 0)
                Initialize(_poolSize);

            return SetFood(data);
        }

        public void ReturnObject(FoodObject obj)
        {
            obj.gameObject.SetActive(false);
            _pool.Enqueue(obj);
        }

        private void Initialize(int amount)
        {
            for (int i = 0; i < amount; i++)
                ReturnObject(Instantiate(_fruitPrefab, transform));
        }

        private FoodObject SetFood(FoodData data)
        {
            var food = _pool.Dequeue();

            if (data != null)
                food.Initialize(_assets.GetNext(data));
            else
                food.Initialize(_assets.GetRandom());

            return food;
        }
    }
}
