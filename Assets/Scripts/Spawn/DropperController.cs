using UnityEngine;
using Zenject;

namespace FoodFusion
{
    public class DropperController : MonoBehaviour
    {
        [SerializeField] private Dropper _dropper;
        private Blender _blender;

        [Inject]
        private void Construct(Blender blender) => _blender = blender;

        private void Awake()
        {
            _blender.Activated += Disable;
            _blender.Deactivated += Enable;
        }

        private void OnDestroy()
        {
            _blender.Activated -= Disable;
            _blender.Deactivated -= Enable;
        }

        private void Disable() => _dropper.gameObject.SetActive(false);

        private void Enable() => _dropper.gameObject.SetActive(true);
    }
}
