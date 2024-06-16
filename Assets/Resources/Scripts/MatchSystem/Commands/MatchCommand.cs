using System;

namespace FoodFusion
{
    public abstract class MatchCommand
    {
        protected MatchInvoker Invoker;
        protected (Food, Food) Match => Invoker.Match;

        public MatchCommand(MatchInvoker invoker) => Invoker = invoker;

        public abstract void Execute();
    }
}