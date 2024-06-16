using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FoodFusion
{
    public class AddScoreCommand : MatchCommand
    {
        private readonly int _bonusMultiplier = 100;
        private readonly ScoreAdder _scoreAdder;

        private int _bonus;

        public AddScoreCommand(MatchInvoker invoker, ScoreAdder scoreAdder)
        : base(invoker)
        {
            _scoreAdder = scoreAdder;
        }

        public override void Execute()
        {
            _bonus = (Match.Item1.Data.Level + Match.Item2.Data.Level) * _bonusMultiplier;
            _scoreAdder.AddScore(_bonus);
        }
    }
}