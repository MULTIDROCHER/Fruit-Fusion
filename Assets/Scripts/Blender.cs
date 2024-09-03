using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace FoodFusion
{
    public class Blender : MonoBehaviour
    {
        [SerializeField] private BuoyancyEffector2D _water;

        [SerializeField] private BlenderCap _cap;
        [SerializeField] private WaterLevel _waterLevel;

        private float _magnitude = 500;
        private float _timer;
        private WaitForSeconds _magnitudeChangeDelay = new(.25f);

        //private float _timer;
        //private float _delay = 300;
        public event Action Activated;
        public event Action Deactivated;

        public void BlenderOn(float duration)
        {
            Activated?.Invoke();
            Debug.Log("BlenderOn for " + duration);

            DOTween.Sequence()
            .Append(_cap.Close())
            .Join(_waterLevel.Raise(duration / 4))
            .OnComplete(() => StartCoroutine(Blend(duration)));
        }

        private IEnumerator Blend(float duration)
        {
            _timer = 0;
            _water.flowMagnitude = _magnitude;

            while (_timer <= duration)
            {
                _timer += Time.unscaledDeltaTime;

                yield return _magnitudeChangeDelay;
                _water.flowMagnitude = -_water.flowMagnitude;
            }

            BlenderOff(duration);
            Debug.Log("completed");
        }

        public void BlenderOff(float duration)
        {
            DOTween.Sequence()
            .Append(DOTween.To(() => _water.flowMagnitude, magnitude => _water.flowMagnitude = magnitude, 0, duration))
            .Join(_cap.Open())
            .OnComplete(() =>
            {
                Deactivated?.Invoke();
                _waterLevel.Lower(duration);
            });
        }
    }
}
