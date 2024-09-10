using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using YG;

namespace FoodFusion
{
    [Serializable]
    public class FoodDatasPack
    {
        [field: SerializeField] private FoodData[] _datas;

        private FoodData _foodData;

        public event Action<int> DataOpened;

        public Dictionary<FoodData, bool> Datas { get; private set; } = new();

        public void Initialize()
        {
            for (int i = 0; i < _datas.Length; i++)
                if (i == 0)
                    Datas.Add(_datas[i], true);
                else
                    Datas.Add(_datas[i], false);

            YandexGame.savesData.DataPack = this;
        }

        private void OpenData(FoodData data)
        {
            Datas[data] = true;
        }

        public FoodData GetNext(FoodData current)
        {
            int index = Datas.Keys.ToList().IndexOf(current) + 1;

            if (index <= Datas.Count - 1)
            {
                _foodData = Datas.Keys.ElementAt(index);
                OpenData(_foodData);
                DataOpened?.Invoke(index);
                return _foodData;
            }
            else
            {
                return _datas[0];
            }
        }

        public FoodData GetRandom()
        {
            var amount = Datas.Count(x => x.Value == true);

            return Datas.Keys.ElementAt((int)UnityEngine.Random.Range(0, amount/ 2f));
        }
    }
}
