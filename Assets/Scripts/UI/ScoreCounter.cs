using System;
using YG;

namespace FoodFusion
{
    public class ScoreCounter
    {
        public event Action<int> ScoreChanged;

        public int Score { get; private set; }

        public ScoreCounter() => Score = YandexGame.savesData.Score;

        public void Add(int amount)
        {
            if (amount <= 0)
                return;

            Score += amount;
            ScoreChanged?.Invoke(amount);
        }
    }
}