using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using YG;
using Zenject;

namespace FoodFusion
{
    public class DataAssets : MonoBehaviour
    {
        [SerializeField] private FoodDatasPack _pack;

        public Dictionary<FoodData, bool> Datas => _pack.Datas;
        public event Action<int> DataOpened;

        [Inject]
        private void Construct()
        {
            if (YandexGame.savesData.DataPack != null)
                _pack = YandexGame.savesData.DataPack;
            else
                _pack.Initialize();
        }

        private void Start()
        => _pack.DataOpened += (int index) => DataOpened?.Invoke(index);

        private void OnDestroy()
        => _pack.DataOpened -= (int index) => DataOpened?.Invoke(index);

        public FoodData GetRandom()
        => _pack.GetRandom();

        public FoodData GetNext(FoodData current)
        => _pack.GetNext(current);
    }
}
