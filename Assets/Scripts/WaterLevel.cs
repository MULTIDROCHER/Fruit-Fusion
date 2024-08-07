using DG.Tweening;
using UnityEngine;
using Zenject;

namespace FoodFusion
{
    public class WaterLevel : MonoBehaviour
    {
        private readonly float _maxPosY = -1.3f;
        private readonly float _minPosY = -3.8f;
        private readonly float _maxScaleY = 5;
        private readonly float _minScaleY = 0;

        [SerializeField] private float _changesDuration = 4;
        
        private Blender _blender;

        [Inject]
        private void Construct(Blender blender)
        {
            _blender = blender;
        }

        private void Start()
        {
            _blender.Activated += Raise;
            _blender.Deactivated += Lower;
        }

        private void OnDestroy()
        {
            _blender.Activated -= Raise;
            _blender.Deactivated -= Lower;
        }

        private void Raise()
        {
            transform.DOMoveY(_maxPosY, _changesDuration);
            transform.DOScaleY(_maxScaleY, _changesDuration);
        }

        private void Lower()
        {
            transform.DOMoveY(_minPosY, _changesDuration);
            transform.DOScaleY(_minScaleY, _changesDuration);
        }
    }
}