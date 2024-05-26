using System;
using FoodFusion;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindInputHandler();
        BindObjectAssets();
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
        .Bind<ObjectsAssets>()
        .FromNew()
        .AsSingle()
        .NonLazy();
    }
}
