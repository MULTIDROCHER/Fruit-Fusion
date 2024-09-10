using DG.Tweening;
using UnityEngine;

namespace FoodFusion
{
    public class WaterLevel : MonoBehaviour
    {
        private readonly float _maxPosY = .8f;
        private readonly float _minPosY = -4;
        private readonly float _maxScaleY = 4.7f;
        private readonly float _minScaleY = 0;

        [SerializeField] private float _fillDuration;

        private ZippyWater2D _water;

        private void Awake() => _water = GetComponent<ZippyWater2D>();

        private void Start() => Lower(.01f).Play();

        private float SetDuration(float value) => value < 0 ? _fillDuration : value;

        public Tween Raise(float duration = -1)
        {
            duration = SetDuration(duration);

            return DOTween.Sequence()
            .Append(transform.DOMoveY(_maxPosY, duration))
            .Join(DOTween.To(() => _water.height, height => _water.height = height, _maxScaleY, duration));
        }

        public Tween Lower(float duration = -1)
        {
            duration = SetDuration(duration);

            return DOTween.Sequence()
            .Append(transform.DOMoveY(_minPosY, duration))
            .Join(DOTween.To(() => _water.height, height => _water.height = height, _minScaleY, duration));
        }
    }
}