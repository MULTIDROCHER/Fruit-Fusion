using UnityEngine;

namespace FoodFusion
{
    public class UpgradeCommand : MergeCommand
    {
        private readonly ObjectPool _pool;
        private FoodObject _upgradedObject;

        public UpgradeCommand(MergeInvoker invoker, ObjectPool pool)
        : base(invoker)
        {
            _pool = pool;
        }

        protected override void Execute((FoodObject, FoodObject) mergePair)
        {
            RemoveOld(mergePair);
            SetNew(mergePair);
        }

        private void SetNew((FoodObject, FoodObject) mergePair)
        {
            _upgradedObject = _pool.GetObject(mergePair.Item1.Data);
            _upgradedObject.transform.position = mergePair.Item1.transform.position;
            _upgradedObject.gameObject.SetActive(true);
            _upgradedObject.Drop(Vector3.one);
            _upgradedObject.Bounce();
        }

        private void RemoveOld((FoodObject, FoodObject) mergePair)
        {
            _pool.ReturnObject(mergePair.Item1);
            _pool.ReturnObject(mergePair.Item2);
        }
    }
}
