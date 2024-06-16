using Zenject;

namespace FoodFusion
{
    public class ScoreSystemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindScoreAdder();
        }

        private void BindScoreAdder()
        {
            Container
            .Bind<ScoreAdder>()
            .FromNew()
            .AsSingle()
            .NonLazy();
        }
    }
}