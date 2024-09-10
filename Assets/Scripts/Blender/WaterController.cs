using System.Collections;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace FoodFusion
{
    public class WaterController : MonoBehaviour
    {
        [SerializeField] private float _stateDuration;
        [SerializeField] private float _fillingDelay;

        private Blender _blender;
        private WaterLevel _water;
        private WaitForSeconds _duration;
        private WaitForSeconds _delay;
        private bool _autofilling = true;

        [Inject]
        private void Construct(Blender blender, WaterLevel water)
        {
            _blender = blender;
            _water = water;

            _duration = new(_stateDuration);
            _delay = new(_fillingDelay);
        }

        private void Awake() => StartFilling();

        private void Start()
        {
            _blender.Activated += StopFilling;
            _blender.Deactivated += StartFilling;
        }

        private void OnDestroy()
        {
            _blender.Activated -= StopFilling;
            _blender.Deactivated -= StartFilling;
        }

        private void StartFilling()
        {
            _autofilling = true;
            StartCoroutine(AutoFill());
        }

        private void StopFilling() => _autofilling = false;

        private IEnumerator AutoFill()
        {
            while (_autofilling)
            {
                yield return _delay;
                _water.Raise().Play();
                yield return _duration;
                _water.Lower().Play();
            }
        }
    }
}
