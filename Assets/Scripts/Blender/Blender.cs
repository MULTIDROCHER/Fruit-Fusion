using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace FoodFusion
{
    public class Blender : MonoBehaviour
    {
        [SerializeField] private BuoyancyEffector2D _water;
        [SerializeField] private BlenderCap _cap;
        [SerializeField] private WaterLevel _waterLevel;

        private const float Magnitude = 500;

        public event Action Activated;
        public event Action Deactivated;

        public void BlenderOn(float duration)
        {
            Activated?.Invoke();

            DOTween.Sequence()
                .Append(_cap.Close())
                .Join(_waterLevel.Raise(duration / 4))
                .OnComplete(() => Blending(duration));
        }

        private void Blending(float duration)
        {
            Debug.Log("BlenderOn for " + duration);
            int repeats = Mathf.FloorToInt(duration / 0.5f);
            float remainingDuration = duration - (repeats * 0.5f); // остаток времени после переключений

            _water.flowMagnitude = Magnitude;

            Sequence blendingSequence = DOTween.Sequence();

            // Переключаем значение flowMagnitude каждую 0.5 секунды
            for (int i = 0; i < repeats; i++)
            {
                blendingSequence.AppendInterval(0.5f)
                    .AppendCallback(() =>
                    {
                        _water.flowMagnitude = _water.flowMagnitude == Magnitude ? -Magnitude : Magnitude;
                    });
            }

            blendingSequence.AppendInterval(remainingDuration / 2)
                .OnComplete(() => BlenderOff(2));
        }

        public void BlenderOff(float duration)
        {
            Debug.Log("BlenderOff for " + duration);
            DOTween.Sequence()
                .Append(DOTween.To(() => _water.flowMagnitude, magnitude => _water.flowMagnitude = magnitude, 0, duration))
                .OnComplete(() =>
                {
                    _cap.Open();
                    Deactivated?.Invoke();
                    _waterLevel.Lower(duration);
                });
        }
    }
}