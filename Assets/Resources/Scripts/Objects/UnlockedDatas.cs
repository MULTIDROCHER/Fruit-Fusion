using System.Collections.Generic;
using UnityEngine;

namespace FoodFusion
{
    public class UnlockedDatas
    {
        private readonly List<FoodData> _openedItems;
        private readonly int _totalItemCount;
        public int SpawnRange { get; private set; }

        public UnlockedDatas(int totalItemCount)
        {
            _openedItems = new List<FoodData>();
            _totalItemCount = totalItemCount;
            UpdateSpawnRange();
        }

        public void OpenItem(FoodData item)
        {
            if (_openedItems.Contains(item) == false)
            {
                _openedItems.Add(item);
                UpdateSpawnRange();
            }
        }

        private void UpdateSpawnRange()
        {
            if (_openedItems.Count == _totalItemCount)
            {
                SpawnRange = (int)(_totalItemCount * 0.6f);
            }
            else
            {
                SpawnRange = _openedItems.Count / 2;
            }

            Debug.Log(SpawnRange + " spawnrange");
        }
    }
}