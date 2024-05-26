using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FoodFusion;
using UnityEngine;

namespace FoodFusion
{
    public class ObjectsAssets
    {
        private const string FruitsPath = "ScriptableObjects/Fruits";

        private readonly List<FoodData> _datas;

        public ObjectsAssets()
        {
            _datas = Resources.LoadAll<FoodData>(FruitsPath).ToList();
            Debug.Log(_datas.Count + "datas loaded");
        }

        public FoodData GetRandomData()
        {
            return _datas[Random.Range(0, _datas.Count / 2)];
        }

        public FoodData GetNextData(FoodData data)
        {
            var level = data.Level + 1;

            if (level < _datas.Count)
                return _datas.FirstOrDefault(x => x.Level == level);
            else
                return _datas[0];
        }
    }
}