namespace FoodFusion
{
    public class CalculateBonusCommand : MergeCommand
    {
        private ScoreCounter _counter;
        private int _amount;
        private int _multiplier = 10;

        public CalculateBonusCommand(MergeInvoker invoker, ScoreCounter counter)
        : base(invoker)
        {
            _counter = counter;
        }

        protected override void Execute((FoodObject, FoodObject) mergePair)
        {
            _amount = (mergePair.Item1.Data.BonusScore + mergePair.Item2.Data.BonusScore) * _multiplier;
            _counter.Add(_amount);
        }
    }
}