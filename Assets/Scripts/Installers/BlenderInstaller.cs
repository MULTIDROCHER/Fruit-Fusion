using UnityEngine;
using Zenject;

namespace FoodFusion
{
    public class BlenderInstaller : MonoInstaller
    {
        [SerializeField] private Blender _blender;
        [SerializeField] private WaterLevel _water;
        [SerializeField] private FeedbacksContainer _feedbacks;

        public override void InstallBindings()
        {
            Container.Bind<Blender>().FromInstance(_blender).AsSingle().NonLazy();

            Container.Bind<FeedbacksContainer>().FromInstance(_feedbacks).AsSingle().NonLazy();

            Container.Bind<WaterLevel>().FromInstance(_water).AsSingle().NonLazy();
        }
    }
}