using System;

namespace FoodFusion
{
    public abstract class MergeCommand : IDisposable
    {
        protected readonly MergeInvoker Invoker;

        public MergeCommand(MergeInvoker invoker)
        {
            Invoker = invoker;
            Invoker.OnMerge += Execute;
        }

        protected abstract void Execute((FoodObject, FoodObject) mergePair);

        public void Dispose() => Invoker.OnMerge -= Execute;
    }
}
