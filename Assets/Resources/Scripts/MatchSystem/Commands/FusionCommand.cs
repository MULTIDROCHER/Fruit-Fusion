using UnityEngine;
using Zenject;

namespace FoodFusion
{
    public class FusionCommand : MatchCommand
    {
        private readonly ObjectPool _pool;
        private readonly DataAssets _assets;

        public FusionCommand(MatchInvoker invoker, ObjectPool pool, DataAssets assets)
        : base(invoker)
        {
            _assets = assets;
            _pool = pool;
        }

        public override void Execute()
        {
            if (Match.Item1.Physics.IsFree == false || Match.Item2.Physics.IsFree == false)
                return;

            Match.Item1.Initialize(_assets.GetNextData(Match.Item1.Data));
            _pool.Return(Match.Item2);
        }
    }
}