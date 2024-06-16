using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using MoreMountains.Feedbacks;
using UnityEngine;
using Zenject;

namespace FoodFusion
{
    public class MatchInvoker : MonoBehaviour
    {
        private readonly Queue<(Food, Food)> _matchQueue = new();

        [SerializeField] private MMFeedbacks _feedbacks;

        private List<MatchCommand> _commands;
        private bool _isProcessing = false;

        public (Food, Food) Match { get; private set; }

        [Inject]
        private void Construct(ObjectPool pool, DataAssets assets, ScoreAdder scoreAdder)
        {
            _commands = new List<MatchCommand>()
            {
                new FusionCommand(this, pool, assets),
                new AddScoreCommand(this, scoreAdder),
                new EffectCommand(this, _feedbacks),
                new FeedbacksCommand(this,_feedbacks)
            };
        }

        public void OnSpawned(Food food)
        {
            food.Matched += AddMatch;
        }

        private void AddMatch(Food food1, Food food2)
        {
            _matchQueue.Enqueue((food1, food2));

            if (!_isProcessing)
                StartCoroutine(ProcessQueue());
        }

        private IEnumerator ProcessQueue()
        {
            _isProcessing = true;

            while (_matchQueue.Count > 0)
            {
                Match = _matchQueue.Dequeue();

                if (Match.Item1.Data.Level == Match.Item2.Data.Level)
                {
                    _commands.ForEach(command => command.Execute());
                    Match.Item2.Matched -= AddMatch;
                }


                yield return new WaitForSeconds(.2f);
            }

            _isProcessing = false;
        }
    }
}