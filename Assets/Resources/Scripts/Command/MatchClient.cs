namespace FoodFusion
{
    public class MatchClient
    {
        private readonly MatchInvoker _invoker;

        public MatchClient(MatchInvoker invoker)
        {
            _invoker = invoker;
        }

        public void OnMatched(Food food1, Food food2)
        {
            _invoker.AddMatch(food1, food2);
        }
    }
}