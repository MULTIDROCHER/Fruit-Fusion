using FoodFusion;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private MatchInvoker _invoker;

    public override void InstallBindings()
    {
        BindInputHandler();

        BindPool();
        BindObjectAssets();
        BindMatchInvoker();
    }

    private void BindPool()
    {
        Container.Bind<ObjectPool>()
        .FromInstance(_pool)
        .AsSingle()
        .NonLazy();
    }

    private void BindInputHandler()
    {
        Container
        .Bind<InputHandler>()
        .FromNew()
        .AsSingle()
        .NonLazy();
    }

    private void BindObjectAssets()
    {
        Container
        .Bind<DataAssets>()
        .FromNew()
        .AsSingle()
        .NonLazy();
    }

    private void BindMatchInvoker()
    {
        Container.Bind<MatchInvoker>()
        .FromInstance(_invoker)
        .AsSingle()
        .NonLazy();
    }
}