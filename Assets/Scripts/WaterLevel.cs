using System.Collections;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace FoodFusion
{
    public class WaterLevel : MonoBehaviour
    {
        private readonly float _maxPosY = .8f;
        private readonly float _minPosY = -4;
        private readonly float _maxScaleY = 4.7f;
        private readonly float _minScaleY = 0;

        private ZippyWater2D _water;

        private void Awake() => _water = GetComponent<ZippyWater2D>();

        private void Start() => Lower(.01f).Play();

        public Tween Raise(float duration)
        {
            return DOTween.Sequence()
            .Append(transform.DOMoveY(_maxPosY, duration))
            .Join(DOTween.To(() => _water.height, height => _water.height = height, _maxScaleY, duration));
        }

        public Tween Lower(float duration)
        {
            return DOTween.Sequence()
            .Append(transform.DOMoveY(_minPosY, duration))
            .Join(DOTween.To(() => _water.height, height => _water.height = height, _minScaleY, duration));
        }
    }
}