using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace FoodFusion
{
    public class MatchesHandler
    {
        private readonly ObjectsAssets _assets;
        private readonly MatchClient _matchClient;

        public MatchesHandler(MatchClient matchClient, ObjectsAssets assets)
        {
            _matchClient = matchClient;
            _assets = assets;
        }

        public void OnSpawned(Food food)
        {
            if (food == null)
            {
                Debug.Log("Food is null");
                return;
            }
            else if (_assets == null)
            {
                Debug.Log("_assets is null");
                return;
            }

            SetFood(food, _assets.GetRandomData());
        }

        private void OnMatched(Food food1, Food food2)
        {
            _matchClient.OnMatched(food1, food2);
        }

        private void SetFood(Food food, FoodData data)
        {
            food.Initialize(data);
            food.Matched += OnMatched;
        }
    }
}