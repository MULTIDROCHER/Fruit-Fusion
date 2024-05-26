using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace FoodFusion
{
    public class MatchInvoker : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _matchEffect;
        [SerializeField] private ObjectPool _pool;
        private Queue<(Food, Food)> _matchQueue = new();
        private bool _isProcessing = false;
        private UpgradeCommand _upgradeCommand;
        private PlayEffectCommand _effectCommand;

        [Inject]
        private void Construct(ObjectsAssets assets)
        {
            _upgradeCommand = new UpgradeCommand(_pool, assets);
            _effectCommand = new PlayEffectCommand(_matchEffect);
        }

        public void AddMatch(Food food1, Food food2)
        {
            _matchQueue.Enqueue((food1, food2));
            if (!_isProcessing)
            {
                StartCoroutine(ProcessQueue());
            }
        }

        private IEnumerator ProcessQueue()
        {
            _isProcessing = true;

            while (_matchQueue.Count > 0)
            {
                var match = _matchQueue.Dequeue();

                _effectCommand.Execute(Vector3.zero);
                _upgradeCommand.Execute(match.Item1, match.Item2);

                yield return new WaitForSeconds(1);
            }

            _isProcessing = false;
        }
    }
}