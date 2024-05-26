using Zenject;

namespace FoodFusion
{
    public class UpgradeCommand
    {
        private readonly ObjectPool _pool;
        private ObjectsAssets _assets;

        public UpgradeCommand(ObjectPool pool, ObjectsAssets assets)
        {
            _pool = pool;
            _assets = assets;
        }

        public void Execute(Food food1, Food food2)
        {
            // Ваш код для обновления уровня одного объекта и возвращения другого в пул
            _pool.Return(food1);
            food2.Initialize(_assets.GetNextData(food2.Data));
        }
    }
}