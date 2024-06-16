using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FoodFusion
{
    public class DataAssets
    {
        private const string FruitsPath = "ScriptableObjects"; ///Fruits

        private readonly List<FoodData> _datas;
        private readonly UnlockedDatas _unlockedDatas;

        public DataAssets()
        {
            _datas = Resources.LoadAll<FoodData>(FruitsPath).ToList();
            Debug.Log(_datas.Count + "datas loaded");
            _unlockedDatas = new UnlockedDatas(_datas.Count);
        }

        public FoodData GetRandomData()
        {
            return _datas[UnityEngine.Random.Range(0, _unlockedDatas.SpawnRange + 1)];
        }

        public FoodData GetNextData(FoodData data)
        {
            _unlockedDatas.OpenItem(data);
            var level = data.Level + 1;

            if (level < _datas.Count)
                return _datas.FirstOrDefault(x => x.Level == level);
            else
                return _datas[0];
        }
    }
}