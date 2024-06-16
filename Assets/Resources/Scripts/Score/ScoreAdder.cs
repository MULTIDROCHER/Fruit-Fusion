using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

namespace FoodFusion
{
    public class ScoreAdder
    {
        public int Score { get; private set; }

        public event Action<int> ScoreChanged;

        public ScoreAdder()
        {
            Score = YandexGame.savesData.Score;
            ScoreChanged?.Invoke(Score);
        }

        public void AddScore(int amount)
        {
            Score += amount;
            ScoreChanged?.Invoke(amount);
        }
    }
}