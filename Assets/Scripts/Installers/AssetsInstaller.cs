using UnityEngine;
using Zenject;

namespace FoodFusion
{
    public class AssetsInstaller : MonoInstaller
    {
        [SerializeField] private InputHandler _inputHandler;
        [SerializeField] private NextFoodHolder _nextFoodHolder;
        [SerializeField] private ObjectPool _objectPool;
        [SerializeField] private DataAssets _dataAssets;

        public override void InstallBindings()
        {
            Container.Bind<InputHandler>().FromInstance(_inputHandler).AsSingle().NonLazy();

            Container.Bind<DataAssets>().FromInstance(_dataAssets).AsSingle().NonLazy();

            Container.Bind<NextFoodHolder>().FromInstance(_nextFoodHolder).AsSingle().NonLazy();

            Container.Bind<ObjectPool>().FromInstance(_objectPool).AsSingle().NonLazy();

            Container.Bind<ScoreCounter>().FromNew().AsSingle().NonLazy();
        }
    }
}
