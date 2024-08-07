using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;
using Zenject;

namespace FoodFusion
{
    public class MergeInvoker : MonoBehaviour
    {
        private readonly Queue<(FoodObject, FoodObject)> _mergeQueue = new();
        private readonly WaitForSeconds _delay = new(0.1f);

        private MergeCommand[] _commands;
        private bool _isBusy = false;

        private (FoodObject, FoodObject) _mergePair;

        public event Action<(FoodObject, FoodObject)> OnMerge;

        [Inject]
        private void Construct(ObjectPool pool, ScoreCounter scoreCounter, FeedbacksContainer feedbacks)
        {
            _commands = new MergeCommand[]
            {
                new UpgradeCommand(this, pool),
                new FeedbacksCommand(this, feedbacks),
                new CalculateBonusCommand(this, scoreCounter)
            };
        }

        private void Start() => FoodObject.OnCollision += AddMatch;

        private void OnDestroy() => FoodObject.OnCollision -= AddMatch;

        private void AddMatch(FoodObject food)
        {
            _mergeQueue.Enqueue((food, food.PotentialPair));

            if (_mergeQueue.Count > 0 && _isBusy == false)
                StartCoroutine(ProcessQueue());
        }

        private IEnumerator ProcessQueue()
        {
            _isBusy = true;

            while (_mergeQueue.Count > 0)
            {
                Merge();
                yield return _delay;
            }

            _isBusy = false;
            _mergePair = (null, null);
        }

        private void Merge()
        {
            _mergePair = _mergeQueue.Dequeue();

            if (_mergePair.Item1.CanBeMerged && _mergePair.Item2.CanBeMerged
            && _mergePair.Item1.Data.Level == _mergePair.Item2.Data.Level)
                OnMerge?.Invoke(_mergePair);
        }
    }
}
